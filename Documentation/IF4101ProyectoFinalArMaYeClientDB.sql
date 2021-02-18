--create database IF4101ProyectoFinalArMaYe
use IF4101ProyectoFinalArMaYe

CREATE TABLE Client(
	client_Id int identity(1,1) primary key,
	[name] nvarchar(30) not null,
	first_Surname nvarchar(40) not null,
	second_Surname nvarchar(50) not null,
	adress nvarchar(200),
	phone nvarchar(8),
	email nvarchar(40) unique not null,
	[password] VARBINARY(8000),
	[state] bit, 
    creation_Date DATETIME Default GETDATE() not null,
    modify_Date DATETIME,
    created_By int ,
	modified_By int
)


CREATE TABLE ServiceT(
    service_Id int IDENTITY(1,1) PRIMARY KEY,
    [name] VARCHAR(20),
	[state] bit, 
	creation_Date DATETIME Default GETDATE(),
    modify_Date DATETIME,
    created_By int ,
	modified_By int
)


CREATE TABLE Client_Services(
	[client_Id] int foreign key references Client(client_Id),
	service_Id int foreign key references ServiceT(service_Id),
	[state] bit, 
	creation_Date DATETIME Default GETDATE() not null,
    modify_Date DATETIME,
    created_By int ,
	modified_By int,
	primary key(client_Id,service_Id),
)


CREATE TABLE Issue(
	report_Number int identity(1,1) primary key,
	[description] nvarchar(300) not null,
	register_Timestamp datetime default GETDATE(),
	adress nvarchar(200),
	contact_Phone nvarchar(8),
	contact_Email nvarchar(40) unique not null,
	[status] Char CHECK([status] in('I','A','P','R')),
	supporter_Assigned int,
	service_Id int foreign key references ServiceT(service_Id),
	client_Id int foreign key references Client(client_Id),
	[state] bit, 
    creation_Date DATETIME Default GETDATE() not null,
    modify_Date DATETIME,
    created_By int ,
	modified_By int
)


CREATE TABLE Comment(
    comment_Id int IDENTITY(1,1) PRIMARY KEY,
    [description] nvarchar(200),
    comment_Timestamp DATETIME default GETDATE(),
    report_Number int FOREIGN KEY REFERENCES Issue(report_Number),
	[state] bit, 
	creation_Date DATETIME Default GETDATE() not null,
    modify_Date DATETIME,
    created_By int ,
	modified_By int
)



