--CREATE DATABASE ProyectoFinal_IF4101_ArMaYe
--Use ProyectoFinal_IF4101_ArMaYe



CREATE TABLE Employee(
    Employee_ID int IDENTITY(1,1) PRIMARY KEY,
    DNI VARCHAR(10) UNIQUE,
    Employee_Name VARCHAR(20),
    First_Surname VARCHAR(30),
    Second_Surname VARCHAR(30),
    Email VARCHAR(20),
    Employee_State BIT DEFAULT 1,
    Employee_Type int,
    Creation_Date DATETIME Default GETDATE() not null,
    Modify_Date DATETIME,
    Created_By int ,
	Modified_by int,
	Supervised int foreign key references Employee(Employee_ID)
)



CREATE TABLE Issue(
    Report_Number int PRIMARY KEY,
    [Classification] CHAR CHECK([Classification] in('A','M','B')),
    [Status] Char CHECK(Status in('I','A','P','R')),
    Report_Timestamp DATETIME default GETDATE(),
	Resolution_Comment Varchar(200),
	[Service] int foreign key references Service(Service_Id),
	Creation_Date DATETIME Default GETDATE() not null,
    Modify_Date DATETIME,
    Created_By int ,
	Modified_by int,
	Employee_Assigned int foreign key references Employee(Employee_Id),
)



CREATE TABLE Notes(
    Note_Id int IDENTITY(1,1) PRIMARY KEY,
    Description VARCHAR(200),
    Note_Timestamp TIMESTAMP,
    Report_Number int FOREIGN KEY REFERENCES Issue(Report_Number),
	Creation_Date DATETIME Default GETDATE() not null,
    Modify_Date DATETIME,
    Created_By int ,
	Modified_by int
)



CREATE TABLE Employee_Services(
	Employee_Id int foreign key references Employee(Employee_Id),
	Service_Id int foreign key references Service(Service_Id),
	Creation_Date DATETIME Default GETDATE() not null,
    Modify_Date DATETIME,
    Created_By int ,
	Modified_by int,
	primary key(Employee_Id,Service_Id),
)


CREATE TABLE Service(
    Service_Id int IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(20),
	Creation_Date DATETIME Default GETDATE(),
    Modify_Date DATETIME,
    Created_By int ,
	Modified_by int
)