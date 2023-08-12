create procedure sp_registration
@Name varchar(100),
@Email varchar(100),
@Mobile varchar(100),
@Gender varchar(100),
@Profile varchar(100),
@Qualification varchar(100),
@DOB date,
@State varchar(100),
@City varchar(100),	
@Address varchar(100),
@Pincode varchar(100),
@Password varchar(100),
@CreatedDate datetime,
@UpdatedDate datetime,
@IsActive bit,
@RoleId int,
@IsDeleted bit
as
begin
insert into Registration (Name,Email,Mobile,Gender,Profile,Qualification,DOB,State,City,Address,PinCode,Password,CreatedDate,UpdatedDate,IsActive,RoleId,IsDeleted) values(@Name,@Email,@Mobile,@Gender,@Profile,@Qualification,@DOB,@State,@City,@Address,@Pincode,@Password,Getdate(),getdate(),1,1,0)

end

