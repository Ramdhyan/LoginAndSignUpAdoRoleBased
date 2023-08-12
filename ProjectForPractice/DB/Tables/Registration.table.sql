create table Registration
(
Id int identity primary Key,
Name varchar(100),
Email varchar(100),
Mobile nvarchar(100),
Gender varchar(100),
Profile varchar(100),
Qualification varchar(100),
DOB varchar(100),
State varchar(100),
City varchar(100),
Address varchar(100),
PinCode int,
Password nvarchar(max),
RoleId int ,
IsActive bit,
CreatedDate datetime,
UpdatedDate datetime,
IsDeleted bit
);
 