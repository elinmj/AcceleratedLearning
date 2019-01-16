use Chinook
--2
--Select*from artist

--3
--Select Artist.Name
--From Artist
--order by Artist.Name

--4
--Select top 10 Artist.Name
--from Artist
--order by Artist.Name

--5
Select Artist.Name
from Artist
where Artist.Name like


--10
--select top 10 Artist.Name, COUNT(*) AS NumberOfAlbums 
--FROM Album
--join Artist on Album.ArtistId = Artist.ArtistId
--group by artist.Name
--ORDER BY NumberOfAlbums DESC

--11
--select distinct Album.Title as AlbumTitle, Genre.Name 
--from Album 
--join Track on Album.AlbumId=Track.AlbumId
--join Genre on Track.GenreId=Genre.GenreId
--where Genre.GenreId = 2 or Genre.GenreId = 6

--12
--select Track.Name, Album.Title, Artist.Name, Track.TrackId, Track.TrackNumber
--from Track 
--join Album on Album.AlbumId=Track.AlbumId
--join Artist on Artist.ArtistId=Album.ArtistId
----where album.Title = 'Let There Be Rock'

--Alter table Track add TrackNumber int;

--Update Track set TrackNumber=1 where Track.TrackId=15
--Update Track set TrackNumber=2 where Track.TrackId=16
--Update Track set TrackNumber=3 where Track.TrackId=17
--Update Track set TrackNumber=4 where Track.TrackId=18
--Update Track set TrackNumber=5 where Track.TrackId=19
--Update Track set TrackNumber=6 where Track.TrackId=20
--Update Track set TrackNumber=7 where Track.TrackId=21
--Update Track set TrackNumber=8 where Track.TrackId=22

--select Track.Name, Album.Title, Artist.Name, Track.TrackId, Track.TrackNumber
--from Track 
--join Album on Album.AlbumId=Track.AlbumId
--join Artist on Artist.ArtistId=Album.ArtistId

--13
--select Genre.Name as GenreName, count (*) as NrOfTracks
--from Track
--join genre on genre.Genreid=track.genreid
--group by Genre.Name
--having count(*) > 100
--order by count(*) DESC

----14
--declare @mycostumer int =
--(
--	select costumerId
--	from Costumer
--	where firstname = 'Leonie' and lastname = 'Köhler'
--)

--select Customer.FirstName, Customer.LastName, Invoice.InvoiceDate as InvoiceDate
--from Invoice
--join Customer on customer.CustomerId=Invoice.CustomerId
--where Customer.FirstName = 'Leonie'

--15
--Select Customer.FirstName AS CustomerFirstName,
--Customer.LastName as CustomerLastName,
--Employee.FirstName as SupportFirstName,
--Employee.LastName as SupportLastName
--into CustomerWithSupport
--from Customer, Employee

--select * from CustomerWithSupport


--16
--SELECT A.FirstName +' '+ A.LastName as EmployeeName, B.FirstName +' '+ B.LastName as BossName
--FROM Employee A, Employee B
--where A.Reportsto=B.Employeeid


--17
--select top 1 max(len(Customer.Email))
--from Customer


--18
--select Track.Name as Name,Track.Milliseconds/60000 as Minutes
--from Track
--order by Minutes DESC


--19
--ALTER TABLE Customer
--ADD UNIQUE (Phone);

--20
--select year(Invoice.InvoiceDate) as Year, sum(Invoice.Total) as Sum
--from Invoice
--group by year(Invoice.InvoiceDate)
--order by year(Invoice.InvoiceDate) DESC

--21
--select top 1 Playlist.Name as Name, sum(Track.Milliseconds/3600000.0) as TotalLenghtInHours
--from Playlist
--join PlaylistTrack on PlaylistTrack.PlaylistId=Playlist.PlaylistId 
--join Track on Track.Trackid=PlaylistTrack.TrackId
--group by Playlisttrack.PlaylistId, Playlist.Name

--22
--SELECT A.FirstName +' '+ A.LastName as EmployeeName, B.FirstName +' '+ B.LastName as BossName, C.FirstName +' '+ C.LastName as BossBossName
--FROM Employee A, Employee B, Employee C
--where A.Reportsto=B.Employeeid and B.ReportsTo=C.Employeeid

--23
--select Album.AlbumId, Album.Title into Review
--from Album

--alter table Review
--add Review varchar

--update Review 
--set Review='5' 
--where Review.Title='Black Sabbath'

--select*from Review

--insert value 'asdasd' into Review.Review
--select Review
--from Review
--where Title = 'Black Sabbath'



--select*from Review where Review.Review is not null


--3
--backup database Chinook
--to disk='C:\Project\AcceleratedLearning\Chinook.sql'

--alter table PlaylistTrack
--drop FK_PlaylistTrackPlaylistId

--truncate table Playlist

--select*from Playlist

--restore database Chinook from disk='C:\Project\AcceleratedLearning\Chinook.sql'
--select*from Playlist

--4

--begin transaction
--insert into Artist Values('a')
--insert into Artist Values('b')
--insert into Artist Values('c')
--insert into Artist Values('d')
--insert into Artist Values('e')
--rollback transaction

--select*from Artist