USE master
GO

CREATE DATABASE JobsBg;
GO

USE JobsBg
GO

CREATE TABLE Towns(
	TownId int IDENTITY NOT NULL,
	Name nvarchar(50) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED (TownId ASC)
)
GO

CREATE TABLE Addresses(
  AddressId int IDENTITY NOT NULL,
  AddressText nvarchar(100) NOT NULL,
  TownId int NOT NULL,
  CONSTRAINT PK_Addresses PRIMARY KEY CLUSTERED (AddressId ASC),
  CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns(TownId)
)
GO

CREATE TABLE Users(
	UserId int IDENTITY NOT NULL,
	Email nvarchar(50) NOT NULL,
	FirstName nvarchar(50) NULL,
	LastName nvarchar(50) NULL,
	CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserId ASC),
)
GO

CREATE TABLE Contacts(
	ContactsId int IDENTITY NOT NULL,
	Email nvarchar(50) NOT NULL,
	PhoneNumber nvarchar(50) NOT NULL,
	CONSTRAINT PK_Contacts PRIMARY KEY CLUSTERED (ContactsId),
)
GO

CREATE TABLE Companies(
	CompanyId int IDENTITY NOT NULL,
	BusinessInfo text NULL,
	ContactsId int NOT NULL,
	CONSTRAINT PK_Companies PRIMARY KEY CLUSTERED (CompanyId ASC),
	CONSTRAINT FK_Companies_Contacts FOREIGN KEY (ContactsId) REFERENCES Contacts(ContactsId),
	CONSTRAINT UC_Companies UNIQUE (ContactsId)
)
GO

CREATE TABLE JobTypes(
	JobTypeId int IDENTITY NOT NULL,
	TypeName nvarchar(50) NOT NULL,
	CONSTRAINT PK_JobTypes PRIMARY KEY (JobTypeId)
)
GO

CREATE TABLE JobCategories(
	JobCategoryId int IDENTITY NOT NULL,
	CategoryName nvarchar(50) NOT NULL,
	CONSTRAINT PK_JobCategories PRIMARY KEY (JobCategoryId)
)
GO

CREATE TABLE JobOffers(
	JobOfferId int IDENTITY NOT NULL,
	Possition nvarchar(255) NOT NULL,
	Description text NULL,
	Payment decimal NULL,
	JobTypeId int NULL,
	JobCategoryId int NULL,
	CompanyId int NOT NULL,
	CONSTRAINT PK_JobOffers PRIMARY KEY (JobOfferId),
	CONSTRAINT FK_JobOffers_JobTypes FOREIGN KEY (JobTypeId) REFERENCES JobTypes(JobTypeId),
	CONSTRAINT FK_JobOffers_JobCategories FOREIGN KEY (JobCategoryId) REFERENCES JobCategories(JobCategoryId),
	CONSTRAINT FK_JobOffers_Companies FOREIGN KEY (CompanyId) REFERENCES Companies(CompanyId)
)
GO

CREATE TABLE UsersDesiredJobTypes(
	UserId int NOT NULL,
	JobTypeId int NOT NULL,
	CONSTRAINT PK_UsersDesiredJobTypes PRIMARY KEY NONCLUSTERED(UserId, JobTypeId),
	CONSTRAINT FK_UsersDesiredJobTypes_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
	CONSTRAINT FK_UsersDesiredJobTypes_JobTypes FOREIGN KEY (JobTypeId) REFERENCES JobTypes(JobTypeId),
)
GO

CREATE TABLE UsersDesiredJobCategories(
	UserId int NOT NULL,
	JobCategoryId int NOT NULL,
	CONSTRAINT FK_UsersDesiredJobCategories PRIMARY KEY NONCLUSTERED(UserId, JobCategoryId),
	CONSTRAINT FK_UsersDesiredJobCategories_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
	CONSTRAINT FK_UsersDesiredJobCategories_JobCategories FOREIGN KEY (JobCategoryId) REFERENCES JobCategories(JobCategoryId),
)
GO