CREATE DATABASE Placemejobs
GO
USE Placemejobs
GO
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
GO
CREATE TABLE Region (
	RegionID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)
GO
CREATE TABLE Profession (
	ProfessionID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)
GO	
CREATE TABLE Skillset (
	SkillsetID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID)
	)

GO
CREATE TABLE JobPosting (
	JobPostingID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(3000),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID),
	RegionID INT CHECK (RegionID > 0) FOREIGN KEY REFERENCES Region(RegionID),
	[Date] DATE,
	Active BIT
	)
ALTER TABLE JobPosting
	ADD EmployerPhone VARCHAR(10), CompanyName VARCHAR(30)

GO
CREATE TABLE UserProfession (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	ProfessionID INT CHECK (ProfessionID > 0),
	PRIMARY KEY (UserID, ProfessionID)
	)

GO
CREATE TABLE UserSkillset (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (UserID, SkillsetID)
	)
GO
CREATE TABLE UserRegion(
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	RegionID INT CHECK (RegionID > 0) FOREIGN KEY REFERENCES Region(RegionID),
	PRIMARY KEY (UserID, RegionID))
GO
CREATE TABLE UserJobPosting(
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	Status VARCHAR(20),
	StatusDate DATE,
	PRIMARY KEY (UserID, JobPostingID))

GO
CREATE TABLE JobPostingSKillSet(
	JobPostingID INT CHECK (JobPostingID > 0) FOREIGN KEY REFERENCES JobPosting(JobPostingID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (JobPostingID, SKillsetID))
GO
CREATE PROCEDURE AddCandidateAsAdmin (
	@Email VARCHAR(100) = NULL,
	@FirstName VARCHAR(15) = NULL,
	@LastName VARCHAR(15) = NULL,
	@Phone	VARCHAR(10) = NULL,
	@Resume VARCHAR(100) = NULL,
	@CoverLetter VARCHAR(100) = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		INSERT INTO Users
		(
			Email,
			FirstName,
			LastName,
			Phone,
			Resume,
			CoverLetter,
			ActiveInactive,
			Roles
		)
		VALUES
		(
			@Email,
			@FirstName,
			@LastName,
			@Phone,
			@Resume,
			@CoverLetter,
			1,
			'Candidate'
		)
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('AddCandidateAsAdmin error: Insert error.',16,1)
	RETURN @ReturnCode
GO
CREATE PROCEDURE AddCandidates (
	@Email varchar(100),
	@Phone VARCHAR(10),
	@FirstName VARCHAR(15),
	@LastName VARCHAR(15),
	@Resume VARCHAR(100),
	@CoverLetter VARCHAR(100),
	@Password VARCHAR(100)
	)
	AS
	SET NOCOUNT ON
	INSERT INTO Users (Email, Phone, FirstName, LastName, Resume, CoverLetter, Password, ActiveInactive, Roles)
		VALUES(@Email,@Phone,@FirstName,@LastName,@Resume,@CoverLetter,@Password,1,'Candidate')

GO
CREATE PROCEDURE AddCandidateToJobPosting(
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

    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('AddCandidateToJobPosting Error: Insert error.',16,1)
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
CREATE PROCEDURE AddJobPosting (@Description VARCHAR(3000) = NULL, @CompanyName VARCHAR(30), @ProfessionID INT = NULL, @RegionID INT = NULL, @Date Date = NULL, @EmployerPhone VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Description IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @Description',16,1)
	ELSE IF @CompanyName IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @CompanyName',16,1)
	ELSE IF @ProfessionID IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @ProfessionID',16,1)
	ELSE IF @RegionID IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @RegionID',16,1)
	ELSE IF @Date IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @Date',16,1)
	ELSE IF @EmployerPhone IS NULL
		RAISERROR('AddJobPosting - Required Parameter: @EmployerPhone',16,1)
	ELSE
		BEGIN
			INSERT INTO JobPosting
			(
				Description,
				CompanyName,
				ProfessionID,
				RegionID,
				Date,
				EmployerPhone,
				Active
			)
			VALUES
			(
				@Description,
				@CompanyName,
				@ProfessionID,
				@RegionID,
				@Date,
				@EmployerPhone,
				1
			)
			IF @@ERROR = 0
				SET @ReturnCode = (SELECT Distinct JobPostingID FROM JobPosting WHERE EmployerPhone = @EmployerPhone)			
			ELSE
				RAISERROR('AddJobPosting - INSERT error in UserProfession Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE PROCEDURE AddJobSkillset (@JobID INT = NULL, @SkillID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobID IS NULL
		RAISERROR('AddJobSkillset - Required Parameter: @JobID',16,1)
	ELSE IF @SkillID IS NULL
		RAISERROR('AddJobSkillset - Required Parameter: @SkillID',16,1)
	ELSE
		BEGIN
			INSERT INTO JobPostingSKillSet
			(
				JobPostingID,
				SkillsetID
			)
			VALUES
			(
				@JobID,
				@SkillID
			)
			IF @@ERROR = 0
				SET @ReturnCode = 0			
			ELSE
				RAISERROR('AddJobSkillset - INSERT error in JobPostingSKillSet Table',16,1)
		END
			RETURN @ReturnCode

GO
	CREATE PROCEDURE AddRegion
	@description VARCHAR(20)
	AS
	SET NOCOUNT ON
	INSERT INTO Region VALUES(@description)

GO
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
CREATE PROCEDURE AddUser @Email VARCHAR(100), @Password VARCHAR(100) ,@FirstName VARCHAR(15), @LastName VARCHAR(15)
	AS
		INSERT INTO Users (Email, [Password], FirstName, LastName, Roles)
		VALUES (@Email, @Password, @FirstName, @LastName, 'Candidate')

GO
CREATE PROCEDURE AddUserProfession (@UserID INT = NULL, @ProfessionID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @UserID IS NULL
		RAISERROR('AddUserProfession - Required Parameter: @UserID',16,1)
	ELSE IF @ProfessionID IS NULL
		RAISERROR('AddUserProfession - Required Parameter: @ProfessionID',16,1)
	ELSE
		BEGIN
			INSERT INTO UserProfession
			(
				UserID,
				ProfessionID
			)
			VALUES
			(
				@UserID,
				@ProfessionID
			)
			IF @@ERROR = 0
				SET @ReturnCode = 0			
			ELSE
				RAISERROR('AddUserProfession - INSERT error in UserProfession Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE PROCEDURE AddUserRegion (@UserID INT = NULL, @RegionID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @UserID IS NULL
		RAISERROR('AddUserRegion - Required Parameter: @UserID',16,1)
	ELSE IF @RegionID IS NULL
		RAISERROR('AddUserRegion - Required Parameter: @RegionID',16,1)
	ELSE
		BEGIN
			INSERT INTO UserRegion
			(
				UserID,
				RegionID
			)
			VALUES
			(
				@UserID,
				@RegionID
			)
			IF @@ERROR = 0
				SET @ReturnCode = 0			
			ELSE
				RAISERROR('AddUserRegion - INSERT error in UserRegion Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE PROCEDURE AddUserSkillset (@UserID INT = NULL, @SkillID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @UserID IS NULL
		RAISERROR('AddUserSkillset - Required Parameter: @UserID',16,1)
	ELSE IF @SkillID IS NULL
		RAISERROR('AddUserSkillset - Required Parameter: @SkillID',16,1)
	ELSE
		BEGIN
			INSERT INTO UserSkillset
			(
				UserID,
				SkillsetID
			)
			VALUES
			(
				@UserID,
				@SkillID
			)
			IF @@ERROR = 0
				SET @ReturnCode = 0			
			ELSE
				RAISERROR('AddUserSkillset - INSERT error in UserSkillset Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE PROCEDURE ChangeCoverLetter(
	@UserID INT,
	@CoverLetter VARCHAR(100)
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('ChangeCoverLetter Error: All parameters required @UserID.',16,1)
    ELSE IF @CoverLetter IS NULL
        RAISERROR('ChangeCoverLetter Error: All parameters required @CoverLetter.',16,1)
    ELSE
    BEGIN
		Update Users
		SET CoverLetter=@CoverLetter
		WHERE UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('ChangeCoverLetter Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE ChangeEmail(
	@UserID VARCHAR(100),
	@NewEmail VARCHAR(100)
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('ChangeEmail Error: All parameters required @UserID.',16,1)
    ELSE IF @NewEmail IS NULL
        RAISERROR('ChangeEmail Error: All parameters required @NewEmail.',16,1)
    ELSE
    BEGIN
		Update Users
		SET Email=@NewEmail
		WHERE UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('ChangeEmail Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE ChangePassword(
	@UserID INT,
	@NewPassword VARCHAR(100)
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('ChangePassword Error: All parameters required @UserID.',16,1)
    ELSE IF @NewPassword IS NULL
        RAISERROR('ChangeEmail Error: All parameters required @NewPassword.',16,1)
    ELSE
    BEGIN
		Update Users
		SET Password=@NewPassword
		WHERE UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('ChangePassword Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE ChangeResume(
	@UserID INT,
	@Resume VARCHAR(100)
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('ChangeResume Error: All parameters required @UserID.',16,1)
    ELSE IF @Resume IS NULL
        RAISERROR('ChangeResume Error: All parameters required @Resume.',16,1)
    ELSE
    BEGIN
		Update Users
		SET Resume=@Resume
		WHERE UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('ChangeResume Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE procedure DeleteCandidates
	as
	set nocount on
	delete from Users

GO
CREATE procedure DeleteJobPosting(@JobPostingID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('DeleteJobPosting - Required Parameter: @JobPostingID',16,1)
	ELSE
		BEGIN
			UPDATE JobPosting
			SET Active = 0
			WHERE JobPostingID = @JobPostingID

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('DeleteJobPostingSkills - Delete error from JobPosting Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE PROCEDURE DeleteJobPostingSkills(@JobPostingID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('DeleteJobPostingSkills - Required Parameter: @JobPostingID',16,1)
	ELSE
		BEGIN
			DELETE FROM JobPostingSKillSet						
			WHERE JobPostingID = @JobPostingID

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('DeleteJobPostingSkills - Delete error from JobPostingSkillSet Table',16,1)
		END
			RETURN @ReturnCode

GO
CREATE procedure DeleteProfession
	as
	set nocount on
	delete from Profession

GO
CREATE procedure DeleteRegion
	as
	set nocount on
	delete from Region

GO
CREATE procedure DeleteSkillset
	as
	set nocount on
	delete from Skillset
GO
CREATE PROCEDURE DeleteUserCategories(
	@UserID INT = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('DeleteUserCategories Error: All parameters required @UserID.',16,1)
    ELSE
    BEGIN
		DELETE FROM UserProfession
		WHERE UserID=@UserID
		DELETE FROM UserRegion
		WHERE UserID=@UserID
		DELETE FROM UserSkillset
		WHERE UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('DeleteUserCategories Error: Insert error.',16,1)
    RETURN @ReturnCode
GO
CREATE PROCEDURE GetAllCandidates
	AS
		SELECT Users.UserID,FirstName,LastName,Phone, Email, Profession.Description AS Profession, Region.Description AS Region, Skillset.Description AS Skillset ,[Resume], CoverLetter
		FROM Users	INNER JOIN UserProfession ON UserProfession.UserID=Users.UserID
					INNER JOIN UserSkillset ON UserSkillset.UserID=Users.UserID
					INNER JOIN UserRegion ON UserRegion.UserID=Users.UserID
					INNER JOIN Profession ON UserProfession.ProfessionID=Profession.ProfessionID
					INNER JOIN Skillset ON Skillset.SkillsetID=UserSkillset.SkillsetID
					INNER JOIN Region ON Region.RegionID=UserRegion.RegionID
		ORDER BY UserID

GO
CREATE PROCEDURE GetAllJobPostings
	AS 
		SELECT JobPosting.JobPostingID,CompanyName,JobPosting.[Description]
		FROM JobPosting
		WHERE Active = 1
GO
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
CREATE PROCEDURE GetJobPosting(@JobPostingID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('GetJobPosting - Required Parameter: @JobPostingID',16,1)
	ELSE
		BEGIN
			select	JobPostingID,
					Description,
					ProfessionID,
					RegionID,
					Date,
					EmployerPhone,
					CompanyName
			FROM JobPosting
			Where JobPostingID = @JobPostingID AND
				Active = 1
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GetJobPosting - SELECT error from JobPosting Table',16,1)
		END
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
		SELECT JobPostingID, CompanyName, Description
		FROM JobPosting
		WHERE JobPostingID = @JobPostingID
			AND Active = 1
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetJobPostingDetails Error: Select error.',16,1)
	RETURN @ReturnCode
GO
CREATE PROCEDURE GetJobSkillsets(@JobPostingID INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @JobPostingID IS NULL
		RAISERROR('GetJobSkillsets - Required Parameter: @JobPostingID',16,1)
	ELSE
		BEGIN
			SELECT	Skillset.SkillsetID,
					[Description]
			FROM JobPostingSKillSet
			inner join Skillset ON Skillset.SkillsetID = JobPostingSKillSet.SkillsetID
			WHERE JobPostingID = @JobPostingID

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GetJobSkillsets - SELECT error from JobPosting Table',16,1)
		END
			RETURN @ReturnCode
GO
CREATE PROCEDURE GetProfessions
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		SELECT	ProfessionID,
				Description
		FROM	Profession
		ORDER BY Description ASC
			
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetProfessions - SELECT error from Profession Table',16,1)
	END
		RETURN @ReturnCode
GO
CREATE PROCEDURE GetProfile @Email VARCHAR(100)
	AS 
		SELECT * 
		FROM Users
		WHERE Email=@Email
GO
CREATE PROCEDURE GetRegions
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		SELECT	RegionID,
				Description
		FROM	Region
		ORDER BY Description ASC
			
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetRegions - SELECT error from Region Table',16,1)
	END
		RETURN @ReturnCode
GO
CREATE PROCEDURE GetRoles @Email VARCHAR(100)
	AS 
		SELECT Roles FROM Users
		WHERE Email=@Email
GO
CREATE PROCEDURE GetSkillsets
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		SELECT	SkillsetID,
				Description
		FROM	Skillset
		ORDER BY Description ASC
			
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('GetSkillsets - SELECT error from Skillset Table',16,1)
	END
		RETURN @ReturnCode
GO
CREATE PROCEDURE GetUser @Email VARCHAR(100) 
	AS
		SELECT [Password] FROM Users
		WHERE Email=@Email
GO
CREATE PROCEDURE GetUserCVByEmail(
	@Email VARCHAR(100) = NULL
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		SELECT UserID, Resume, CoverLetter
		FROM Users
		WHERE Email = @Email
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetUserCVByEmail error: Select error.',16,1)
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
CREATE PROCEDURE GetUserIDByEmail(
	@Email VARCHAR(100)
)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	BEGIN
		SELECT UserID
		FROM Users
		WHERE Email = @Email
	END
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetUserIDByEmail error: Select error.',16,1)
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
CREATE PROCEDURE GetUserProfessions(
	@UserID INT = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('GetUserProfessions Error: All parameters required @UserID.',16,1)
    ELSE
    BEGIN
		SELECT Profession.ProfessionID, Profession.Description 
		FROM Users
		INNER JOIN UserProfession ON Users.UserID=UserProfession.UserID
		INNER JOIN Profession ON Profession.ProfessionID = UserProfession.ProfessionID
		WHERE Users.UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetUserProfessions Error: Insert error.',16,1)
    RETURN @ReturnCode
GO
CREATE PROCEDURE GetUserRegions(
	@UserID INT = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('GetUserRegions Error: All parameters required @UserID.',16,1)
    ELSE
    BEGIN
		SELECT Region.RegionID, Region.Description 
		FROM Users
		INNER JOIN UserRegion ON Users.UserID=UserRegion.UserID
		INNER JOIN Region ON Region.RegionID = UserRegion.RegionID
		WHERE Users.UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetUserRegions Error: Insert error.',16,1)
    RETURN @ReturnCode

GO
CREATE PROCEDURE GetUserSkills(
	@UserID INT = NULL
)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1

    IF @UserID IS NULL
        RAISERROR('GetUserSkills Error: All parameters required @UserID.',16,1)
    ELSE
    BEGIN
		SELECT Skillset.SkillsetID, Skillset.Description 
		FROM Users
		INNER JOIN UserSkillset ON Users.UserID=UserSkillset.UserID
		INNER JOIN Skillset ON Skillset.SkillsetID = UserSkillset.SkillsetID
		WHERE Users.UserID=@UserID
    END
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetUserSkills Error: Insert error.',16,1)
    RETURN @ReturnCode
GO
CREATE PROCEDURE JobMatch @JobID INT
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
		WHERE JobPosting.JobPostingID=@JobID AND UserJobPosting.UserID IS NULL AND ActiveInactive=0
GO
	CREATE procedure PopulateJobPostingSkillset
	@jobpostingid int, @skillsetid int
	as
	set nocount on  
	insert into JobPostingSKillSet values(@jobpostingid,@skillsetid)
GO
CREATE procedure PopulateProfession
	@Description VARCHAR(30)
	as 
	set nocount on
	insert into Profession values(@Description)
GO
CREATE procedure PopulateRegion
	@Description varchar(30)
	as
	set nocount on
	insert into Region values(@Description)
GO
CREATE procedure PopulateSkillSet
	@Description  VARCHAR(30)
	as
	set nocount on
	insert into Skillset(Description) values(@Description)

GO
	CREATE procedure PopulateUserJobPosting
	@UserID int, @Jobpostingid  int
	as 
	set nocount on
	insert into UserJobPosting (UserID, JobPostingID) values (@UserID,@Jobpostingid)
GO
CREATE procedure PopulateUserProfession
	@userid int, @professionid int
	as
	set nocount on
	insert into UserProfession values(@userid,@professionid)
GO
CREATE procedure PopulateUserRegion
	@UserID int, @Regionid  int
	as 
	set nocount on
	insert into UserRegion values(@UserID,@Regionid)
GO
	CREATE procedure PopulateUserSkillset
	@userid int, @skillsetid int
	as
	set nocount on
	insert into UserSkillset values(@userid,@skillsetid)
GO
CREATE PROCEDURE UpdateAccount @UserID INT, @FirstName VARCHAR(15), @LastName VARCHAR(15), @Status BIT, @Phone VARCHAR(10)
	AS	
		UPDATE Users
		SET FirstName=@FirstName, LastName=@LastName, ActiveInactive=@Status, @Phone=Phone
		WHERE UserID=@UserID
GO
CREATE PROCEDURE UpdateJobPosting (@JobPostingID INT = NULL, @Description VARCHAR(3000) = NULL, @CompanyName VARCHAR(30), @ProfessionID INT = NULL, @RegionID INT = NULL, @Date Date = NULL, @EmployerPhone VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Description IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @Description',16,1)
	ELSE IF @CompanyName IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @CompanyName',16,1)
	ELSE IF @ProfessionID IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @ProfessionID',16,1)
	ELSE IF @RegionID IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @RegionID',16,1)
	ELSE IF @Date IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @Date',16,1)
	ELSE IF @EmployerPhone IS NULL
		RAISERROR('UpdateJobPosting - Required Parameter: @EmployerPhone',16,1)
	ELSE
		BEGIN
			UPDATE JobPosting
			SET
				Description = @Description,
				CompanyName = @CompanyName,
				ProfessionID = @ProfessionID,
				RegionID = @RegionID,
				Date = @Date,
				EmployerPhone = @EmployerPhone
			WHERE JobPostingID = @JobPostingID
			IF @@ERROR = 0
				SET @ReturnCode = (SELECT Distinct JobPostingID FROM JobPosting WHERE EmployerPhone = @EmployerPhone)			
			ELSE
				RAISERROR('AddJobPosting - INSERT error in UserProfession Table',16,1)
		END
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
CREATE procedure UpdateProfession
	@UpdatedDescription VARCHAR(30),	@ProfessionID int
	as 
	set nocount on
	update Profession set [Description] = @UpdatedDescription where ProfessionID= @ProfessionID
GO
	CREATE procedure UpdateRegion
	@updatedRegionDescription VARCHAR(30),	@RegionID int
	as 
	set nocount on
	update Region set [Description] = @updatedRegionDescription where RegionID= @RegionID
GO

	CREATE procedure UpdateSkillSet
	@UpdatedDescription VARCHAR(30),	@ProfessionID int, @SkillSetID int
	as 
	set nocount on
	update Skillset set [Description] = @UpdatedDescription where ProfessionID= @ProfessionID and SkillsetID = @SkillSetID
