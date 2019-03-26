--CREATE DATABASE Placemejobs
USE Placemejobs
CREATE TABLE Users (
	UserID INT IDENTITY (1,1) PRIMARY KEY,
	Email VARCHAR(100) UNIQUE,
	Phone VARCHAR(10) NULL,
	FirstName VARCHAR(15),
	LastName VARCHAR(15),
	[Resume] VARCHAR(100) NULL,
	CoverLetter VARCHAR(100) NULL,
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
	Status VARCHAR(20)
	PRIMARY KEY (UserID, JobPostingID))
ALTER TABLE UserJobPosting
	ADD StatusDate Date NULL



CREATE TABLE JobPostingSKillSet(
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (JobPostingID, SKillsetID))

GO
/*** User Procedures***/
CREATE PROCEDURE AddUser @Email VARCHAR(100), @Password VARCHAR(100) ,@FirstName VARCHAR(15), @LastName VARCHAR(15)
	AS
		INSERT INTO Users (Email, [Password], FirstName, LastName, Roles)
		VALUES (@Email, @Password, @FirstName, @LastName, 'Candidate')


GO
CREATE PROCEDURE GetUser @Email VARCHAR(100) 
	AS
		SELECT [Password] FROM Users
		WHERE Email=@Email

GO
CREATE PROCEDURE GetRoles @Email VARCHAR(100)
	AS 
		SELECT Roles FROM Users
		WHERE Email=@Email

/*** Job Search Procedures***/
GO
CREATE PROCEDURE GetAllJobPostings 
	AS 
		SELECT JobPosting.JobPostingID,CompanyName,JobPosting.[Description]
		FROM JobPosting

GO
CREATE PROCEDURE GetAllSkillsets
	AS
		SELECT [Description]
		FROM Skillset

GO
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
					LEFT JOIN UserJobPosting ON Users.UserID = UserJobPosting.UserID
		WHERE JobPosting.JobPostingID=@JobID AND UserJobPosting.UserID IS NULL
-- SELECT * FROM UserJobPosting 

GO
CREATE PROCEDURE MatchProfession @JobID INT, @ProfessionID INT
	AS
		SELECT DISTINCT Users.UserID, (FirstName + LastName) AS Name, Phone, [Resume]
		FROM Users	INNER JOIN UserProfession ON Users.UserID=UserProfession.UserID
					INNER JOIN Profession ON Profession.ProfessionID=UserProfession.ProfessionID
					INNER JOIN JobPosting ON JobPosting.ProfessionID=Profession.ProfessionID
		WHERE JobPosting.JobPostingID=@JobID AND JobPosting.ProfessionID=@ProfessionID

GO
CREATE PROCEDURE MatchRegion @JobID INT, @RegionID INT
	AS
		SELECT DISTINCT Users.UserID, (FirstName + LastName) AS Name, Phone, [Resume]
		FROM Users	INNER JOIN UserRegion ON Users.UserID=UserRegion.UserID
					INNER JOIN Region ON UserRegion.RegionID=Region.RegionID
					INNER JOIN JobPosting ON JobPosting.RegionID= Region.RegionID
		WHERE JobPosting.JobPostingID=@JobID AND JobPosting.RegionID=@RegionID

GO
CREATE PROCEDURE MatchSkillset @JobID INT, @SkillsetID INT 
	AS 
		SELECT DISTINCT Users.UserID, (FirstName + ' ' + LastName) AS Name, Phone, Email,[Resume]
		FROM Users	INNER JOIN UserSkillset ON Users.UserID=UserSkillset.UserID
					INNER JOIN Skillset ON UserSkillset.SkillsetID=Skillset.SkillsetID
					INNER JOIN JobPostingSKillSet ON Skillset.SkillsetID=JobPostingSKillSet.SkillsetID
					INNER JOIN JobPosting ON JobPostingSKillSet.JobPostingID=JobPosting.JobPostingID
		WHERE JobPosting.JobPostingID=@JobID AND Skillset.SkillsetID=@SkillsetID

GO
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
GO
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
GO
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

-- Assign Candidate to a job posting
CREATE TABLE UserJobPosting(
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	PRIMARY KEY (UserID, JobPostingID))

GO
ALTER PROCEDURE AddCandidateToJobPosting(
	@UserID INT = NULL,
	@JobPostingID INT = NULL,
	@Date DATE = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('AddCandidateToJobPosting Error: All parameters required @UserID.',16,1)
    ELSE IF @JobPostingID IS NULL
        RAISERROR('AddCandidateToJobPosting Error: All parameters required @JobPostingID.',16,1)
    ELSE
    BEGIN
		INSERT INTO UserJobPosting
		(
			UserID,
			JobPostingID,
			Status,
			StatusDate
		)
		VALUES
		(
			@UserID,
			@JobPostingID,
			'Interviewing',
			@Date
		)
  --      UPDATE UserJobPosting
		--SET Status = 'Interviewing'
		--WHERE UserID = @UserID AND JobPostingID = @JobPostingID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('AddCandidateToJobPosting Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE GetUserDetails (
	@UserID INT = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @UserID IS NULL
		RAISERROR('GetUserDetails Error: All parameters are required @UserID.',16,1)
	ELSE
	BEGIN
		SELECT UserID, Email, Phone, FirstName, LastName
		FROM Users
		WHERE UserID = @UserID
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetUserDetails Error: Select error.',16,1)
	RETURN @ReturnCode

GO
CREATE PROCEDURE GetJobPostingDetails (
	@JobPostingID INT = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('GetJobPostingDetails Error: All parameters are required @JobPostingID.',16,1)
	ELSE
	BEGIN
		SELECT JobPostingID, Description
		FROM JobPosting
		WHERE JobPostingID = @JobPostingID
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetJobPostingDetails Error: Select error.',16,1)
	RETURN @ReturnCode

GO
CREATE PROCEDURE GetJobCandidates(
	@JobPostingID INT
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @JobPostingID IS NULL
        RAISERROR('Error: Please provide a job ID.',16,1)
    ELSE
    BEGIN
		SELECT * 
		FROM UserJobPosting INNER JOIN Users ON Users.UserID=UserJobPosting.UserID
		WHERE JobPostingID=@JobPostingID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('Error: Unable to retrieve data.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE UpdateJobStatus(
	@JobPostingID INT,
	@UserID INT,
	@Status VARCHAR(20),
	@StatusDate DATE
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @JobPostingID IS NULL
        RAISERROR('Error: Please provide a job ID.',16,1)
	ELSE IF @UserID IS NULL
        RAISERROR('Error: Please provide a User ID.',16,1)
	ELSE IF @Status IS NULL
        RAISERROR('Error: Please provide a status descprition.',16,1)
    BEGIN
		UPDATE UserJobPosting
		SET [Status] = @Status, StatusDate=@StatusDate
		WHERE UserID=@UserID AND JobPostingID=@JobPostingID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('Error: Unable to retrieve data.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE GetUserJobPostingByStatus (
	@Status VARCHAR(20) = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Status IS NULL
		RAISERROR('GetUserJobPostingByStatus Error: All parameters are required @Status.',16,1)
	ELSE
	BEGIN
		SELECT UserID, JobPostingID, StatusDate
		FROM UserJobPosting
		WHERE Status = @Status
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetUserJobPostingByStatus Error: Select error.',16,1)
	RETURN @ReturnCode

GO
CREATE PROCEDURE GetUserIDByJobPostingStatus (
	@JobPostingID INT = NULL,
	@Status VARCHAR(20) = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('GetUserIDByJobPostingStatus Error: All parameters are required @JobPostingID.',16,1)
	ELSE
	BEGIN
		SELECT UserID
		FROM UserJobPosting
		WHERE	Status = @Status AND
				JobPostingID = @JobPostingID
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetUserIDByJobPostingStatus Error: Select error.',16,1)
	RETURN @ReturnCode

-- SELECT UserID, JobPostingID, StatusDate FROM UserJobPosting WHERE Status = 'Interviewing'
-- SELECT * FROM Users
-- SELECT * FROM UserJobPosting
-- DELETE FROM UserJobPosting
-- UPDATE UserJobPosting SET Status = 'On-Hold' WHERE UserID=41

/*
/*** View All Tables and Table Entries***/
DECLARE @sqlText VARCHAR(MAX)
SET @sqlText = ''
SELECT @sqlText = @sqlText + ' SELECT * FROM ' + QUOTENAME(name) + CHAR(13) FROM sys.tables
EXEC(@sqlText)

INSERT INTO UserRegion (UserID, RegionID) VALUES ('1', '4')
SELECT * FROM UserRegion

UPDATE Userskillset SET SkillsetID='5' WHERE UserID='1' AND SkillsetID='3'
UPDATE UserRegion SET RegionID='4' WHERE UserID='1' AND RegionID='1'
UPDATE UserProfession SET ProfessionID='5' WHERE UserID='1'
EXEC JobMatch '4'

Alter PROCEDURE GetAllCandidates
	AS
		SELECT FirstName, LastName, Email, Phone, Resume, CoverLetter
		FROM Users
*/