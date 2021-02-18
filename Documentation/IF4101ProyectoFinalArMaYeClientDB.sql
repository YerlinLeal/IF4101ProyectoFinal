--create database IF4101ProyectoFinalArMaYe
use IF4101ProyectoFinalArMaYe

CREATE TABLE [User](
	[user_id] int identity(1,1) primary key,
	[name] nvarchar(30) not null,
	first_surname nvarchar(40) not null,
	second_surname nvarchar(50) not null,
	adress nvarchar(200),
	phone nvarchar(8),
	email nvarchar(40) unique not null,
	[password] VARBINARY(8000),
	[state] bit, 
    creation_date DATETIME Default GETDATE() not null,
    modify_date DATETIME,
    created_by int ,
	modified_by int
)

CREATE TABLE [Service](
    service_id int IDENTITY(1,1) PRIMARY KEY,
    [name] VARCHAR(20),
	[state] bit, 
	creation_date DATETIME Default GETDATE(),
    modify_date DATETIME,
    created_by int ,
	modified_by int
)

CREATE TABLE user_services(
	[user_id] int foreign key references [User]([user_id]),
	service_id int foreign key references [Service](service_id),
	[state] bit, 
	creation_date DATETIME Default GETDATE() not null,
    modify_date DATETIME,
    created_by int ,
	modified_by int,
	primary key([user_id],service_id),
)

CREATE TABLE Issue(
	report_number int identity(1,1) primary key,
	[description] nvarchar(300) not null,
	register_timestamp datetime default GETDATE(),
	adress nvarchar(200),
	contact_phone nvarchar(8),
	contact_email nvarchar(40) unique not null,
	[status] Char CHECK([status] in('I','A','P','R')),
	supporter_assigned int,
	[service_id] int foreign key references [service](service_id),
	[user_id] int foreign key references [user]([user_id]),
	[state] bit, 
    creation_date DATETIME Default GETDATE() not null,
    modify_date DATETIME,
    created_by int ,
	modified_by int
)

CREATE TABLE Comment(
    comment_id int IDENTITY(1,1) PRIMARY KEY,
    [description] nvarchar(200),
    comment_timestamp DATETIME default GETDATE(),
    report_number int FOREIGN KEY REFERENCES Issue(report_number),
	[state] bit, 
	creation_date DATETIME Default GETDATE() not null,
    modify_date DATETIME,
    created_by int ,
	modified_by int
)



