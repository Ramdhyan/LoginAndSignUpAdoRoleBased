create table login
(
Id int identity primary key ,
UserName varchar(100),
Password nvarchar(100),
RoleId int
);