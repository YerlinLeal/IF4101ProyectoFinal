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
	[password] nvarchar(200) not null ,
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
-------------------------------------------------------------------Select------------------------------------------------------------------------
select * from Issue
select * from client
select * from ServiceT
select * from Client_Services
--------------------------------------------------------------------insert------------------------------------------------------
insert into ServiceT([name],state,creation_Date,modify_Date,created_By,modified_By)
values('Internet',1,GETDATE(),GETDATE(),4,4)
insert into issue([description],register_Timestamp,adress,contact_Phone,contact_Email,[status],
	supporter_Assigned,service_Id,client_Id,[state], creation_Date,modify_Date,created_By,modified_By)values
	('prueba',GETDATE(),'asddsa','22556974','maikel@gmail.com','R',4,3,9,1,GETDATE(),GETDATE(),4,4)

------------------------------------------------------------------------------procedure-----------------------------------------------
create procedure listIssue @id int
as
begin
	select * from Issue where Issue.client_Id=@id
	
end

exec listIssue 9
drop procedure listIssue

create procedure loadByName @email nvarchar(40)
as
begin
	select * from client where client.email=@email
end

exec loadByName 'maikesl@gmail.com'
drop procedure loadByName