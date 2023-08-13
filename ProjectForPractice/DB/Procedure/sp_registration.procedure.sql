alter procedure sp_registration
@Name varchar(100) =null,
@Email varchar(100) =null,
@Mobile varchar(100) =null,
@Gender varchar(100) =null,
@Profile varchar(100) =null,
@Qualification varchar(100) =null,
@DOB date =null,
@State varchar(100) =null,
@City varchar(100) =null,	
@Address varchar(100) =null,
@Pincode varchar(100) =null,
@Password varchar(100) =null,
@CreatedDate datetime =null,
@UpdatedDate datetime =null,
@IsActive bit =null,
@RoleId int =null,
@IsDeleted bit =null
as
begin
insert into Registration (Name,Email,Mobile,Gender,Profile,Qualification,DOB,State,City,Address,PinCode,Password,CreatedDate,UpdatedDate,IsActive,RoleId,IsDeleted) values(@Name,@Email,@Mobile,@Gender,@Profile,@Qualification,@DOB,@State,@City,@Address,@Pincode,@Password,Getdate(),getdate(),1,1,0)
insert into login (UserName,Password,RoleId) values(@Email,@Password,1)
end

select* from login
select* from Registration