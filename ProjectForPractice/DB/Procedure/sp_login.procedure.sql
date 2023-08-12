alter procedure sp_login
@UserName nvarchar(100),
@Password nvarchar(100)
as
begin
select UserName,Password,RoleId from login where username=@UserName and password=@Password
end
--insert into login values('admin@gmail.com','Admin',2) 