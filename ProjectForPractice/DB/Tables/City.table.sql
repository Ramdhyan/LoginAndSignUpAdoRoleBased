Create table City
(City_Id int identity,
CityName varchar(100),
State_Id int foreign key references State(State_Id)
)


--select* from state
--select* from city