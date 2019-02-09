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

-- inner join: Endast de personer som har en favoritf�rg kommer med
select * 
from Person 
join Color 
on Person.FavoriteColor = Color.Id

-- left join: "Ava" kommer med �ven om hon inte har en favoritf�rg
select * 
from Person 
left join Color 
on Person.FavoriteColor = Color.Id

-- right join: Purple och Indigo kommer med �ven om ingen person har det som favoritf�rg (Ava �r inte med)
select * 
from Person 
right join Color 
on Person.FavoriteColor = Color.Id

-- full join: Allt �r med �ven de rader som inte matchar. Ex Ava �r med. Purple och Indigo �r med.
select * 
from Person 
full join Color 
on Person.FavoriteColor = Color.Id

