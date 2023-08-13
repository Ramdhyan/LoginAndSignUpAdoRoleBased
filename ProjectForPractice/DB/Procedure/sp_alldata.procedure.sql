create proc sp_alldata
as
begin
select*from Registration where RoleId=1
end