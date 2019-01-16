-- :connect (localdb)\mssqllocaldb
if DB_ID('DemoIds') is null
	create database DemoIds
go

use DemoIds

drop table if exists Person1 
drop table if exists Person2 
drop table if exists Person3

create table Person1(
	Id int identity(1,1),
	Name varchar(50),
)

create table Person2(
	Id uniqueidentifier default newid(), -- måste inte ha "default", men då slipper man skicka in ett eget id
	Name varchar(50),
)

create table Person3(
	Id uniqueidentifier default newsequentialid(),
	Name varchar(50),
)

delete from Person1
delete from Person2
delete from Person3

insert into Person1(Name) values('A1');
insert into Person1(Name) values('A2');
insert into Person1(Name) values('A3');

insert into Person2(Id, Name) values(newid(), 'B1');
insert into Person2(Id, Name) values('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'B2');
insert into Person2(Name) values('B3');
insert into Person2(Name) values('B4');

insert into Person3(Name) values('C1');
insert into Person3(Name) values('C2');
insert into Person3(Name) values('C3');

select * from Person1
select * from Person2
select * from Person3

/*

Global Unique IDentifier
Fördelar

- Minimal risk att två GUIDS är lika => kan slå ihop data från flera tabeller t.o.m från helt olika databaser/maskiner
- Klienten kan generera id't utan att vara i kontakt med servern (där databasen är)
- (säkrare eftersom det är mycket svårt att gissa)

Nackdelar
- Tar mycket plats (16 bytes)  
- (jobbigare att läsa vid debuggning)

Unikt?

Guid är på 32 hexadecimala tal (128 bits)
16^32 = 3.4 * 10^38

10^22 atomer på ett papper
10^6  papper
10^10 personer

Referenser

https://betterexplained.com/articles/the-quick-guide-to-guids/

*/



