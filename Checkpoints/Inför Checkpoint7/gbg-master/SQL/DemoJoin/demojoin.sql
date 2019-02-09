if DB_ID('DemoJoin') is null
	create database DemoJoin
go

use DemoJoin

drop table if exists Person
drop table if exists Color

create table Person(
	Name varchar(50),
	FavoriteColor int,
)

create table Color(
	Id int,
	Name varchar(50),
)

insert into Person
values
('Mia', 91),
('Olivia', 91),
('James', 92),
('Liam',	93),
('Ava',	null)

insert into Color 
values
(91, 'Red'),
(92, 'Green'),
(93, 'Blue'),
(94, 'Purple'),
(95, 'Indigo')

select * from Person
select * from Color

-- inner join: Endast de personer som har en favoritfärg kommer med
select * 
from Person 
join Color 
on Person.FavoriteColor = Color.Id

-- left join: "Ava" kommer med även om hon inte har en favoritfärg
select * 
from Person 
left join Color 
on Person.FavoriteColor = Color.Id

-- right join: Purple och Indigo kommer med även om ingen person har det som favoritfärg (Ava är inte med)
select * 
from Person 
right join Color 
on Person.FavoriteColor = Color.Id

-- full join: Allt är med även de rader som inte matchar. Ex Ava är med. Purple och Indigo är med.
select * 
from Person 
full join Color 
on Person.FavoriteColor = Color.Id

