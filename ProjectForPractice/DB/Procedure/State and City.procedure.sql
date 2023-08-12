create procedure BindState
as
begin
select*from [State]
end

create procedure BindCity
@State_Id int
as
begin
select*from City where State_Id=@State_Id
end
