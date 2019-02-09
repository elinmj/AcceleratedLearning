level1
select City.City, ChurchInfo.Year, Churches.Church
from ChurchInfo
join Churches on Churches.ChuchId=ChurchInfo.ChurchId
join City on City.CityId=ChurchInfo.CityId

--level2
--select Person.FirstName, City.City
--from Person
--join City on City.CityId=Person.CityId

