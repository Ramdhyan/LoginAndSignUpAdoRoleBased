create proc sp_userdata
@UserName varchar(100),
@RoleId int
as
begin
select* from Registration where Email=@UserName and RoleId=@RoleId
end