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
	select * from Users
	insert into Users values('mickeyhere@gmail.com','7809514242','Mickey','Mouse',Null,Null,'mick671',1,'Admin')

	create procedure AddCandidates 
	@Email varchar(100), 
	@Phone VARCHAR(10),
	@FirstName VARCHAR(15),
	@LastName VARCHAR(15),
	@Resume VARBINARY(MAX)=Null,
	@CoverLetter VARBINARY(MAX)=Null,
	@Password VARCHAR(100),
	@ActiveInactive BIT,
	@Roles VARCHAR (10)
	as
	set nocount on
	insert into Users values(@Email,@Phone,@FirstName,@LastName,@Resume,@CoverLetter,@Password,@ActiveInactive,@Roles)

	exec AddCandidates 'nickhere@gmail.com',' ','Nick','Mouse',Null,Null,'nick665',0,'Candidate'
	exec AddCandidates 'bob123@gmail.com',' ','Bob',' ',Null,Null,'bob8090',0,'Candidate'

	create procedure DeleteCandidates
	as
	set nocount on
	delete from Users

CREATE TABLE Region (
	RegionID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)

	create procedure PopulateRegion
	@Description varchar(30)
	as
	set nocount on
	insert into Region values(@Description)

	exec PopulateRegion 'Mumbai'
	exec PopulateRegion 'Navi Mumbai'
	exec PopulateRegion 'Thane'
	exec PopulateRegion 'Ghatkopar'

	create procedure DeleteRegion
	as
	set nocount on
	delete from Region

	select * from Region

CREATE TABLE Profession (
	ProfessionID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30)
	)

	create procedure PopulateProfession
	@Description VARCHAR(30)
	as 
	set nocount on
	insert into Profession values(@Description)

	exec PopulateProfession 'Accountant'
	exec PopulateProfession 'IT Engineer'
	exec PopulateProfession 'Business Analyst'
	exec PopulateProfession 'SalesPerson'

	create procedure DeleteProfession
	as
	set nocount on
	delete from Profession

	select * from Profession

CREATE TABLE Skillset (
	SkillsetID INT IDENTITY(1,1) PRIMARY KEY,
	[Description] VARCHAR(30),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID)
	)

	create procedure PopulateSkillSet
	@Description  VARCHAR(30),
	@ProfessionID int
	as
	set nocount on
	insert into Skillset values(@Description,@ProfessionID)

	exec PopulateSkillSet 'Java',6
	exec PopulateSkillSet '.Net',6
	exec PopulateSkillSet 'Spring MVC',6
	exec PopulateSkillSet 'Kpo',8
	exec PopulateSkillSet 'Bpo',8
	
	create procedure DeleteSkillset
	as
	set nocount on
	delete from Skillset

CREATE TABLE JobPosting (
	JobPostingID INT IDENTITY (1,1) PRIMARY KEY,
	[Description] VARCHAR(3000),
	ProfessionID INT CHECK(ProfessionID > 0) FOREIGN KEY REFERENCES Profession(ProfessionID),
	RegionID INT CHECK (RegionID > 0) FOREIGN KEY REFERENCES Region(RegionID),
	[Date] DATE,
	[Status] VARCHAR(10)
	)

	create procedure AddJobPosting
	@Description VARCHAR(3000),
	@ProfessionID INT ,
	@RegionID INT ,
	@Date DATE,
	@Status VARCHAR(10)
	as
	set nocount on
	insert into JobPosting values(@Description,@ProfessionID,@RegionID,@Date,@Status)

	exec AddJobPosting '.net developer at Brickcube with 2 year experience',6,1,'2/12/2019',interested
	exec AddJobPosting 'java developer at Brickcube with 2 year experience',6,1,'2/12/2019',interested
	exec AddJobPosting 'salesperson at Brickcube with 0-1 year experience',8,1,'2/12/2019',interested
	exec AddJobPosting 'Senior Accountant at Here Solutions',5,3,'6/12/2019',interested

	create procedure DeleteJobPosting
	as
	set nocount on
	delete from JobPosting

	select * from Users
	select * from JobPosting
	select * from JobPostingSKillSet
	select * from UserJobPosting
	select * from Region
	select * from Profession
	select * from Skillset
	select * from UserProfession
	select * from UserSkillset
	select * from UserRegion


	CREATE TABLE UserProfession (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	ProfessionID INT CHECK (ProfessionID > 0),
	PRIMARY KEY (UserID, ProfessionID)
	)
	
	insert into UserProfession (UserID,ProfessionID) values (1,6)

	create procedure PopulateUserProfession
	@userid int, @professionid int
	as
	set nocount on
	insert into UserProfession values(@userid,@professionid)

	exec PopulateUserProfession 1,5
	exec PopulateUserProfession 3,5


CREATE TABLE UserSkillset (
	UserID INT CHECK (UserID > 0) FOREIGN KEY REFERENCES Users(UserID),
	SkillsetID INT CHECK(SkillsetID > 0) FOREIGN KEY REFERENCES Skillset(SkillsetID),
	PRIMARY KEY (UserID, SkillsetID)
	)

	create procedure PopulateUserSkillset
	@userid int, @skillsetid int
	as
	set nocount on
	insert into UserSkillset values(@userid,@skillsetid)

	exec PopulateUserSkillset 1,2
	exec PopulateUserSkillset 1,3
	exec PopulateUserSkillset 1,4

	create procedure PopulateJobPostingSkillset
	@jobpostingid int, @skillsetid int
	as
	set nocount on  
	insert into JobPostingSKillSet values(@jobpostingid,@skillsetid)

	exec PopulateJobPostingSkillset 1,3
	exec PopulateJobPostingSkillset 1,4
	exec PopulateJobPostingSkillset 1,2

	create procedure PopulateUserJobPosting
	@UserID int, @Jobpostingid  int
	as 
	set nocount on
	insert into UserJobPosting values(@UserID,@Jobpostingid)

	exec PopulateUserJobPosting 2,3
	exec PopulateUserJobPosting 2,4
	exec PopulateUserJobPosting 4,3
	
	create procedure PopulateUserRegion
	@UserID int, @Regionid  int
	as 
	set nocount on
	insert into UserRegion values(@UserID,@Regionid)

	exec PopulateUserRegion 2,3
	exec PopulateUserRegion 2,1
	exec PopulateUserRegion 1,4
