CREATE DATABASE Placemejobs

CREATE TABLE Users (
	UserID INT IDENTITY (1,1) PRIMARY KEY,
	Email VARCHAR(100),
	Phone VARCHAR(10),
	FirstName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	[Resume] VARBINARY(MAX),
	CoverLetter VARBINARY(MAX),
	[Password] VARCHAR(100),
	ActiveInactive BIT,
	Roles VARCHAR (10)
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


CREATE PROCEDURE AddUser @Email VARCHAR(100), @Password VARCHAR(100) 
	AS
		INSERT INTO Users (Email, [Password], Roles)
		VALUES (@Email, @Password, 'Candidate')


CREATE PROCEDURE GetUser @Email VARCHAR(100) 
	AS
		SELECT [Password] FROM Users
		WHERE Email=@Email


CREATE PROCEDURE GetRoles @Email VARCHAR(100)
	AS 
		SELECT Roles FROM Users
		WHERE Email=@Email
