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
	contact_Email nvarchar(40),
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
	creation_Date DATETIME Default GETDATE(),
    modify_Date DATETIME,
    created_By int ,
	modified_By int
)


CREATE PROCEDURE Insert_Client_Services(@c_id int, @s_id int)
as 
begin
	insert into Client_Services(Client_Id,Service_Id, State) values(@c_id,@s_id,1);
end

CREATE PROCEDURE GetCommentByReport @r_id int
as
begin
	select * from Comment where report_Number=@r_id and state=1;
end

CREATE PROCEDURE [dbo].[Get_Services_By_Client] @c_id int
as
begin
	select ServiceT.service_Id, ServiceT.name from ServiceT where ServiceT.service_Id in 
	(select s.service_Id from ServiceT as s join Client_Services as cs on s.service_Id = cs.service_Id where cs.client_Id = @c_id and cs.state = 1 and s.state = 1)
end

CREATE PROCEDURE [dbo].[GetReportData] @r_id int
as
begin
	select i.report_Number,
	concat(c.name , ' ' , c.first_Surname) as name_Client,
	c.email as email_Client,
	c.phone as phone_Client,
	c.adress as address,
	i.contact_Email as email_Second_Contact,
	i.contact_Phone as phone_Second_Contact
	from Issue as i join Client as c on i.client_Id = c.client_Id
	where i.report_Number = @r_id
end

