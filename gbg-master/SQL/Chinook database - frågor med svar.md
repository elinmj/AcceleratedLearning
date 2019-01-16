# SQL - Chinook database

Det som står inom parantes är de kolumner som ska hämtas. T.ex i fråga 3 så ska bara ArtistName-kolumnen hämtas.

## 1)

Öppna databasservern på din dator:

 	(localdb)\mssqllocaldb

Detta kan du göra från Visual Studio och välja *SQL Server Object Explorer*.

Alternativ: använd programmet *SQL Management Studio*. Välj File => Connect Object Explorer. 

Kör Chinook-scriptet för att skapa musik-databasen

## 2)

Lista all info om alla artister

    select * from Artist


## 3)

Lista alla artisters namn. Sortera på namn. (ArtistName)

    select Name as ArtistName 
    from Artist 
    order by Name

## 4)

Lista de 10 första artisterna, sorterat på namn. (ArtistId, Name)

    select top 10 ArtistId, Name 
    from Artist 
    order by Name

## 5)

Lista alla artister som börjar på "Academy" (Name)

    select Name 
    from Artist 
    where Name like 'Academy%'

## 6)

Lista alla album där den andra bokstaven i titeln är “a” och den tredje bokstaven är “r”
(Title)

    select Name 
    from Album 
    where Name like '_ar%'

## 7)

Lista alla album där första bokstaven på titeln är en vokal

    select Name 
    from Album 
    where Name like '[aoueiy]%'

## 8)

Lista alla album tillsammans med artister för albumen (ArtistName, AlbumTitle)

    select Artist.Name ArtistName, Album.Title AlbumTitle 
    from Album inner join Artist  
    on Album.ArtistId = Artist.ArtistId
    order by Artist.Name


## 9)

Förklara skillnaden mellan
- inner join
- left join
- right join
- full join

        Inner join ger bara rader där matchningen är uppfylld
        Left join ger alltid alla rader från vänster tabell (även om det inte blir match)
        Right join ger alltid alla rader från höger tabell (även om det inte blir match)
        Full join ger alltid alla rader från både vänster och höger tabell


## 10)

Lista de 10 artister som släppt flest album (NrOfAlbums, ArtistName)

    select top 10 Count(*) NrOfAlbums, Artist.Name 
    from Artist join Album on Artist.ArtistId=Album.ArtistId
    group by Artist.name
    order by NrOfAlbums desc

    (kan även använda “with tie”)

## 11)

Lista namn på alla album som är Jazz eller Blues. Ett album ska bara finnas i listan en gång. (AlbumTitle)

    select distinct Album.Title AlbumTitle
    from Album  
    join Track on Album.AlbumId = Track.AlbumId
    where GenreId in (2,6)

alternativ om man inte vet ID’s i förväg:

    select distinct Album.Title AlbumTitle, Genre.Name Genre
    from Track
    inner join Album on Album.AlbumId = Track.AlbumId
    inner join Genre on Genre.GenreId = Track.GenreId
    where Genre.Name in ('Jazz', 'Blues')

## 12)

Albumet "Let There Be Rock" (av AC/DC) innehåller 8 låtar. Modifiera databasen så det går att ordna låtar i nummerordning. 

Uppdatera sedan databasen så låtarna i "Let There Be Rock" är numrerade från 1 till 8.

    alter table Track add OrderInAlbum tinyint;
    go
    update Track set OrderInAlbum=1 where TrackId=15;
    update Track set OrderInAlbum=2 where TrackId=16;
    update Track set OrderInAlbum=3 where TrackId=17;
    update Track set OrderInAlbum=4 where TrackId=18;
    update Track set OrderInAlbum=5 where TrackId=19;
    update Track set OrderInAlbum=6 where TrackId=20;
    update Track set OrderInAlbum=8 where TrackId=21;
    update Track set OrderInAlbum=7 where TrackId=22;

    select * 
    from Track 
    WHERE AlbumId=4

(kan även automatisera numreringen, men det är rätt svårt)

Alternativ lösning, som automatiserar uppdateringen 


    DECLARE @trackid INT
    DECLARE @cursor CURSOR
    DECLARE @tracknumber INT = 1

    SET @cursor = CURSOR FOR

	    SELECT TrackId
        FROM Track join Album
	    ON Track.AlbumId = Album.AlbumId 
	    WHERE Album.Title='Let There Be Rock'

    OPEN @cursor
    FETCH NEXT FROM @cursor INTO @trackid
    WHILE @@FETCH_STATUS = 0
    BEGIN

	    --PRINT CONCAT('update Track set OrderInAlbum=',@tracknumber,' where TrackId=',@trackid);
	    UPDATE Track SET OrderInAlbum=@tracknumber where TrackId=@trackid
	    SET @tracknumber = @tracknumber + 1
        FETCH NEXT FROM @cursor INTO @trackid
    END

    CLOSE @cursor
    DEALLOCATE @cursor

Alternativ med *common table expression*

    WITH t1 AS
 	    (
		    SELECT TrackId, row_number() over(order by TrackId) as RowNumber
		    FROM Track join Album
		    ON Track.AlbumId = Album.AlbumId 
		    WHERE Album.Title='Let There Be Rock'
	    )
    UPDATE Track 
    SET OrderInAlbum=t1.RowNumber 
    FROM t1
    WHERE Track.TrackId=t1.TrackId 

## 13)

Skriv en sqlfråga som visar de genres som är mest populära. 

Lista genre och antal tracks i den genren. Visa den genre som har flest tracks först och sedan i nedåtstigande ordning. Visa endast de genres som har fler än 100 tracks.
(GenreName, NrOfTracks)

    select Genre.Name GenreName, Count(Genre.Name) as NrOfAlbums
    from Genre 
    join Track on Genre.GenreId = Track.GenreId
    group by Genre.Name
    having Count(*) >100 
    order by NrOfAlbums desc


## 14)

Skapa en variabel som sparar CustomerId utifrån kunden "Leonie Köhler"

Använd denna variabel för att lista alla datum när en faktura till Leonie Köhler gått iväg
(InvoiceDate)

    declare @MyCustomer int = 
    (
	    select CustomerId 
	    from Customer 
	    where FirstName='Leonie' and LastName='Köhler'
    )

    select cast(InvoiceDate as date) 
    from Invoice 
    where CustomerId=@MyCustomer


## 15)

Skapa en temporär tabell #CustomerWithSupport som innehåller förnamn och efternamn på en kund och dess supportpersonal 
(CustomerFirstName, CustomerLastName, SupportFirstName, SupportLastName)

    drop table #CustomerWithSupport 

    select c.FirstName CustomerFirstName, c.LastName CustomerLastName, e.FirstName SupportFirstName, e.LastName SupportLastName
    into #CustomerWithSupport
    from 
    Customer c join Employee e on c.SupportRepId=e.EmployeeId

    select * from #CustomerWithSupport

Alternativ med variabel (fördel: slipper ha en tabell som ligger och skvalpar):

    declare @CustomerWithSupport table
    (
      CustomerFirstName varchar(30), 
      CustomerLastName varchar(30),
      SupportFirstName varchar(30),
      SupportLastName varchar(30)
    )
    insert into @CustomerWithSupport

    select Customer.FirstName, Customer.LastName, Employee.FirstName, Employee.LastName 
	from Customer
    join Employee on Employee.EmployeeId=Customer.SupportRepId;

    select * from @CustomerWithSupport;

## 16)

Lista alla anställda som har en chef och deras chef.

Resultatet ska vara två kolumner (ej 4) med den anställdes och chefens fullständiga namn

(EmployeeName, BossName)

    select e1.FirstName + ' ' + e1.LastName as EmployeeName, e2.FirstName + ' ' + e2.LastName as BossName
    from 
    Employee e1 join Employee e2 on e1.ReportsTo=e2.EmployeeId

## 17)

Ta reda på hur många tecken den längsta epostadressen har bland alla kunder
(LongestMail)

    select Max(Len(Email)) LongestMail 
    from Customer

..om du vill få ut epostadressen

	select top 1 Email, Len(Email) EmailLength 
    from Customer
	order by EmailLength desc

... om det finns flera epostadresser som är lika jättelånga och du vill lista alla:

	select top 1 with ties Email , Len(Email) EmailLength 
    from Customer
	order by EmailLength desc

## 18)

Ta reda på den eller de låtar som pågår längst tid
Resultatet ska vara en rad med låttitel och längden på låten
(Name, Minutes)

    select Name, Milliseconds/60000 Minutes
    from Track t where t.Milliseconds = 
	    (select Max(Milliseconds) from Track) 

Alternativ:


    select top 1 with ties Name, Milliseconds/60000 Minutes
    from Track t order by Milliseconds desc


## 19)

Gör en av kolumner i Customer unique. Motivera ditt val 

    alter table Customer 
    add unique(Email);  

Motivering

    Det är liten risk att två kunder har samma epostadress



## 20)

Lista hur mycket som har fakturerat för varje år (2009-2013). Sortera så senaste åren visas först (2013)
(Year, Sum)

    select year(InvoiceDate) as [Year], sum(total) as [Sum] 
    from Invoice
    group by year(InvoiceDate) order by year(InvoiceDate) desc


## 21)
 
Ta fram längsta spellistan. (Name, TotalLengthInHours)

    SELECT TOP 1 WITH TIES PlayList.Name as Name, SUM(track.Milliseconds)/(1000*60*60) AS TotalLengthInHours
    FROM PlayListTrack
    JOIN Playlist ON PlaylistTrack.PlaylistId=PlayList.PlaylistId
    JOIN Track ON Track.TrackId=PlaylistTrack.TrackId
    GROUP BY Playlist.Name
    ORDER BY TotalLengthInHours DESC

## 22)

Lista alla anställda som har en chef och deras chefs chef. (EmployeeName, BossesBossName)

    SELECT emp.FirstName + ' ' + emp.LastName AS EmployeeName, bossesboss.FirstName + ' ' + bossesboss.LastName AS BossesBossName
    FROM Employee emp
    JOIN Employee boss ON emp.ReportsTo=boss.EmployeeId
    JOIN Employee bossesboss ON boss.ReportsTo=bossesboss.EmployeeId

## 23)

Skapa en ny tabell så varje album kan ha en recension

    CREATE TABLE Review 
    (
        ReviewId int IDENTITY(1,1) PRIMARY KEY,
        AlbumId int NOT NULL FOREIGN KEY REFERENCES Album(AlbumID),
        ReviewText nvarchar(1000),
    )

Lägg till en review på albumet "Black Sabbath"

    INSERT INTO Review (AlbumId, ReviewText)
    VALUES ((SELECT AlbumId FROM ALBUM WHERE TITLE LIKE 'Black Sabbath'),'Kanske en av de bästa någonsin...')


## Extra

## 1)

Hitta på en egen uppgift som bygger på att data ska hämtas (via SELECT)

Lös uppgiften.

Visa för din lärare.

## 2)

Hitta på en egen uppgift som bygger på att data ska modifieras (via UPDATE, DELETE)

Alternativ: hitta på en egen uppgift som kräver att en eller flera tabeller skapas.

Lös uppgiften.

Visa för din lärare.

## 3)

Gör en backup av databasen Chinook till en fil. Ta bort alla spellistor.
Skriv en sql-fråga för att visa att spellistorna är borta

Gör sedan en restore av databasen så spellistorna kommer tillbaka.
Skriv en sql-fråga för att visa att spellistorna är tillbaka


    ---- backup

    use Chinook
    backup database Chinook to disk='c:\TMP\Chinook.bak'

    delete from PlaylistTrack
    delete from Playlist 

    select * from PlaylistTrack
    select * from Playlist

    ---- restore 

    use master
    alter database Chinook set single_user with rollback immediate
    -- eller ALTER DATABASE Chinook SET OFFLINE WITH ROLLBACK AFTER 10
    -- eller ALTER DATABASE Chinook SET RECOVERY SIMPLE
    restore database Chinook from disk='c:\TMP\Chinook.bak'

    ----
    use Chinook
    select * from PlaylistTrack
    select * from Playlist


## 4)

Använd transaktioner för att lösa denna uppgift.

Lägg till 5 artister i Artist-tabellen.

Ångra sedan transaktionen så de 5 artisterna inte läggs in. (använd alltså inte "delete" i denna uppgift)


    begin transaction

    insert into Artist(Name) values ('Kalle1')
    insert into Artist(Name) values ('Kalle2')
    insert into Artist(Name) values ('Kalle3')
    insert into Artist(Name) values ('Kalle4')
    insert into Artist(Name) values ('Kalle5')

    select * from Artist

    rollback transaction

    select * from Artist

## 5) 

(Svår!)

Kolumnen AlbumId har datatypen int, vilket kan vara onödigt generöst.

Välj en annan datatyp som är mer begränsande.

Skriv ett script som ändrar datatypen (och tar hänsyn till index och nycklar)

    ---- ta bort contraint

    ALTER TABLE [Track] DROP CONSTRAINT [FK_TrackAlbumId]
    ALTER TABLE [Album] DROP CONSTRAINT [PK_Album]

    DROP INDEX [IFK_TrackAlbumId] ON [Track]

    ---- modifiera kolumn

    ALTER TABLE Track
    ALTER COLUMN AlbumId smallint

    ALTER TABLE Album
    ALTER COLUMN AlbumId smallint

    ---- lägg till contraint

    ALTER TABLE [Album] 
    ADD CONSTRAINT [PK_Album] PRIMARY KEY  ([AlbumId]) 

    ALTER TABLE [Track]
    ADD CONSTRAINT [FK_TrackAlbumId] FOREIGN KEY([AlbumId])
    REFERENCES [Album] ([AlbumId])

    CREATE INDEX [IFK_TrackAlbumId] 
    ON [Track]([AlbumId])

## 6)

(Svår!)

Lista alla artister och hur många spellistor de är med i.

    select Artist.Name, count(distinct Playlist.PlaylistId) as PlaylistCount
    from Artist 
    join Album on Artist.ArtistId = Album.ArtistId
    join Track on Album.AlbumId=Track.AlbumId
    join PlaylistTrack on PlaylistTrack.TrackId = track.TrackId
    join Playlist on playlist.PlaylistId = PlaylistTrack.PlaylistId
    group by Artist.Name

## 7)

Beräkna vilken mediatyp som bidragit mest till den ekonomiska omsättningen (Magnus Tidqvist)

    select MediaType.Name as MediaType, format(sum ( InvoiceLine.Quantity * InvoiceLine.UnitPrice), 'C', 'se-se') as Omsättning
    from InvoiceLine
    inner join Track on InvoiceLine.TrackId = Track.TrackId
    inner join MediaType on MediaType.MediaTypeId = track. MediaTypeId
    group by MediaType.Name
    order by sum ( InvoiceLine.Quantity * InvoiceLine.UnitPrice) desc

## 8)

Listar alla låtar en person köpt (Tobias Persson)

    SELECT Customer.FirstName+ ' ' +Customer.LastName, Track.Name
    FROM Customer
    JOIN Invoice on Customer.CustomerId = Invoice.CustomerId
    JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId
    JOIN Track on Track.TrackId = InvoiceLine.TrackId WHERE Customer.FirstName = 'Dan' AND Customer.LastName = 'Miller'

