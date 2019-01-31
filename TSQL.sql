CREATE DATABASE Placemejobs

CREATE TABLE Users (
	Email VARCHAR(100) PRIMARY KEY,
	[Password] VARCHAR(100),
	Roles VARCHAR (10)
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
