
if DB_ID('DemoGroupBy') is null
	create database DemoGroupBy
go

use DemoGroupBy

drop table if exists Person

create table Person(
	Name varchar(50),
	Country varchar(50),
	Income int
)

insert into Person
values
('Mia', 'Sweden', 20000),
('Olivia', 'Island', 50000),
('James', 'Sweden', 25000),
('Liam',	'Sweden', 28000),
('Ava',	'Island', 60000),
('Lisa', 'Spain', 10000)


select * from Person

-- Ger 2 och 1 och 3 (inte s� intressant)
select count(*) 
from Person 
group by Country

-- Ger landsnamn + antal person i gruppen
select Country, count(*) 
from Person 
group by Country

-- Ge snittinkomsten inom gruppen (bara "Income" hade inte funkat)
select Country, avg(Income), count(*) 
from Person 
group by Country

-- Filtrera grupper med "having" (detta g�r inte att g�ra med "where")
select Country, count(*) 
from Person 
group by Country 
having count(*)>=2

-- Kan filtrera rader med "where" innan grupperingen sker (detta fall funkar �ven med "having")
select Country, count(*) 
from Person 
where Country like 'S%'
group by Country 

-- Filtera f�rst de namn som b�rjar p� "L". Gruppera efter det
select Country, count(*) 
from Person 
where Name like 'L%'
group by Country 

-- Funkar inte f�r Name kan vara olika inom gruppen
--select Country, count(*) 
--from Person 
--group by Country 
--having Name like 'L%'

-- Funkar inte f�r Income kan vara olika inom gruppen
--select count(*), Income 
--from Person 
--group by Country
