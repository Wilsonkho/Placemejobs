CREATE DATABASE Placemejobs

CREATE TABLE Users (
	UserID INT IDENTITY (1,1) PRIMARY KEY,
	Email VARCHAR(100) UNIQUE,
	Phone VARCHAR(10) NULL,
	FirstName VARCHAR(15),
	LastName VARCHAR(15),
	[Resume] VARBINARY(MAX) NULL,
	CoverLetter VARBINARY(MAX) NULL,
	[Password] VARCHAR(100) NULL,
	ActiveInactive BIT NULL,
	Roles VARCHAR (10) NOT NULL
	)

CREATE TABLE Region (
	RegionID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)

CREATE TABLE Profession (
	ProfessionID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)
	
CREATE TABLE Skillset (
	SkillsetID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID)
	)

CREATE TABLE JobPosting (
	JobPostingID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(3000),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID),
	RegionID INT CHECK (RegionID > 0) FOREIGN KEY REFERENCES Region(RegionID),
	[Date] DATE,
	[Status] VARCHAR(10)
	)
ALTER TABLE JobPosting
	ADD EmployerPhone VARCHAR(10), CompanyName VARCHAR(30)


CREATE TABLE UserProfession (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	ProfessionID INT CHECK (ProfessionID > 0),
	PRIMARY KEY (UserID, ProfessionID)
	)


CREATE TABLE UserSkillset (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (UserID, SkillsetID)
	)

CREATE TABLE UserRegion(
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	RegionID INT CHECK (RegionID > 0) FOREIGN KEY REFERENCES Region(RegionID),
	PRIMARY KEY (UserID, RegionID))

CREATE TABLE UserJobPosting(
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	PRIMARY KEY (UserID, JobPostingID))

CREATE TABLE JobPostingSKillSet(
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (JobPostingID, SKillsetID))

/*** User Procedures***/
CREATE PROCEDURE AddUser @Email VARCHAR(100), @Password VARCHAR(100) ,@FirstName VARCHAR(15), @LastName VARCHAR(15)
	AS
		INSERT INTO Users (Email, [Password], FirstName, LastName, Roles)
		VALUES (@Email, @Password, @FirstName, @LastName, 'Candidate')



CREATE PROCEDURE GetUser @Email VARCHAR(100) 
	AS
		SELECT [Password] FROM Users
		WHERE Email=@Email


CREATE PROCEDURE GetRoles @Email VARCHAR(100)
	AS 
		SELECT Roles FROM Users
		WHERE Email=@Email

/*** Job Search Procedures***/
CREATE PROCEDURE GetAllJobPostings 
	AS 
		SELECT JobPosting.JobPostingID,CompanyName,JobPosting.[Description]
		FROM JobPosting


SELECT * FROM JobPosting

CREATE PROCEDURE GetAllSkillsets
	AS
		SELECT [Description]
		FROM Skillset

ALTER PROCEDURE JobMatch @JobID INT
	AS 
		SELECT DISTINCT Users.UserID,FirstName,LastName,Phone, Email, Profession.Description AS Profession, Region.Description AS Region, CoverLetter ,[Resume]
		FROM Users	INNER JOIN UserProfession ON UserProfession.UserID=Users.UserID
					INNER JOIN UserSkillset ON UserSkillset.UserID=Users.UserID
					INNER JOIN UserRegion ON UserRegion.UserID=Users.UserID
					INNER JOIN Profession ON UserProfession.ProfessionID=Profession.ProfessionID
					INNER JOIN Skillset ON Skillset.SkillsetID=UserSkillset.SkillsetID
					INNER JOIN Region ON Region.RegionID=UserRegion.RegionID
					INNER JOIN JobPostingSKillSet ON Skillset.SkillsetID=JobPostingSKillSet.SkillsetID
					INNER JOIN JobPosting ON JobPosting.ProfessionID=Profession.ProfessionID
					AND JobPosting.JobPostingID=JobPostingSKillSet.JobPostingID
					AND JobPosting.RegionID=UserRegion.RegionID
		WHERE JobPosting.JobPostingID=@JobID
--EXEC JobMatch 2
-- EXEC GetAllJobPostings
-- SELECT * FROM JobPosting


CREATE PROCEDURE MatchProfession @JobID INT, @ProfessionID INT
	AS
		SELECT DISTINCT Users.UserID, (FirstName + LastName) AS Name, Phone, [Resume]
		FROM Users	INNER JOIN UserProfession ON Users.UserID=UserProfession.UserID
					INNER JOIN Profession ON Profession.ProfessionID=UserProfession.ProfessionID
					INNER JOIN JobPosting ON JobPosting.ProfessionID=Profession.ProfessionID
		WHERE JobPosting.JobPostingID=@JobID AND JobPosting.ProfessionID=@ProfessionID

CREATE PROCEDURE MatchRegion @JobID INT, @RegionID INT
	AS
		SELECT DISTINCT Users.UserID, (FirstName + LastName) AS Name, Phone, [Resume]
		FROM Users	INNER JOIN UserRegion ON Users.UserID=UserRegion.UserID
					INNER JOIN Region ON UserRegion.RegionID=Region.RegionID
					INNER JOIN JobPosting ON JobPosting.RegionID= Region.RegionID
		WHERE JobPosting.JobPostingID=@JobID AND JobPosting.RegionID=@RegionID

CREATE PROCEDURE MatchSkillset @JobID INT, @SkillsetID INT 
	AS 
		SELECT DISTINCT Users.UserID, (FirstName + ' ' + LastName) AS Name, Phone, Email,[Resume]
		FROM Users	INNER JOIN UserSkillset ON Users.UserID=UserSkillset.UserID
					INNER JOIN Skillset ON UserSkillset.SkillsetID=Skillset.SkillsetID
					INNER JOIN JobPostingSKillSet ON Skillset.SkillsetID=JobPostingSKillSet.SkillsetID
					INNER JOIN JobPosting ON JobPostingSKillSet.JobPostingID=JobPosting.JobPostingID
		WHERE JobPosting.JobPostingID=@JobID AND Skillset.SkillsetID=@SkillsetID
SELECT * FROM JobPosting
UPDATE JobPosting
SET CompanyName = ''
WHERE JobPostingID = 1
-- Upload Resume and Cover Letter
CREATE PROCEDURE AddResume(
    @Resume VARCHAR(100) = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    BEGIN
        INSERT INTO Users
        (
            Resume
        )
        VALUES
        (
            @Resume
        )
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('AddResume Error: Insert error.',16,1)
    RETURN @ReturnCode

CREATE PROCEDURE AddCoverLetter(
    @CoverLetter VARCHAR(100) = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    BEGIN
        INSERT INTO Users
        (
            CoverLetter
        )
        VALUES
        (
            @CoverLetter
        )
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('AddCoverLetter Error: Insert error.',16,1)
    RETURN @ReturnCode

-- Get Resume and Cover Letter
CREATE PROCEDURE GetCV(
    @UserID INT = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('GetCV Error: All parameters required @UserID.',16,1)
    ELSE
    BEGIN
        SELECT Resume, CoverLetter
        FROM Users
        WHERE UserID = @UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetCV Error: Select error.',16,1)
    RETURN @ReturnCode




/*** View All Tables and Table Entries***/
DECLARE @sqlText VARCHAR(MAX)
SET @sqlText = ''
SELECT @sqlText = @sqlText + ' SELECT * FROM ' + QUOTENAME(name) + CHAR(13) FROM sys.tables
EXEC(@sqlText)

INSERT INTO UserRegion (UserID, RegionID) VALUES ('1', '4')
SELECT * FROM UserRegion

UPDATE Userskillset SET SkillsetID='5' WHERE UserID='2' AND SkillsetID='3'
UPDATE UserRegion SET RegionID='4' WHERE UserID='2' AND RegionID='1'
UPDATE UserProfession SET ProfessionID='5' WHERE UserID='2'
EXEC JobMatch '4'

Alter PROCEDURE GetAllCandidates
	AS
		SELECT FirstName, LastName, Email, Phone, Resume, CoverLetter
		FROM Users