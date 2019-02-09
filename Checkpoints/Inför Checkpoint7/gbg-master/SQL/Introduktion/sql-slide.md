
## Diskussion

- Vad �r en databas?
- Varf�r beh�vs databaser?
- Varf�r inte bara spara i en textfil?

## Vad �r SQL?

SQL �r ett standardiserat dataprogramspr�k f�r att spara, f�r�ndra och h�mta data i databaser

SQL st�r f�r Structured Query Language

SQL �r det standardiserade s�ttet att kommunicera med en relationsdatabas 

## Historik

1970 Dr. Edgar F. "Ted" Codd fr�n IBM kom p� konceptet kring relationsdatabaser

1974 SQL utvecklades av forskare fr�n IBM (Chamberlin och Raymond Boyce)

1986 IBM tog fram den f�rsta prototypen f�r en relationsdatabas. SQL blev en ANSI-standard 1986. Den f�rsta relationsdatabasen togs fram av *Relational Software* som senare blev *Oracle*.

1987 SQL blev ISO-standard 

## SQL Server historik

1989: SQL Server 1.0 sl�pps f�r OS/2

2000: SQL Server 2000.

2005: SQL Server 2005 

2008: SQL Server 2008

2010: Azure SQL database

2012: SQL Server 2012

2014: SQL Server 2014

2016: SQL Server 2016

2017: SQL Server 2017


## Vad kan SQL g�ra?

Med SQL kan du:
- H�mta data fr�n en databas
- L�gga in data
- Modifiera data
- Ta bort data

�ven:
- Skapa nya databaser
- Skapa nya tabeller (och modifiera)
- Skapa stored procedures
- Skapa vyer
- S�tta beh�righet

## En standard

SQL �r en standard men det finns vissa skillnader hur man skriver kommandon mellan olika databaser

Exempel p� olika relationsdatabaser:
- SQL Server
- MySQL
- Oracle
- Sybase
- PostgreSQL

## Relationsdatabaser

En tabell �r en samling av relaterad data. Den best�r av kolumner och rader. T.ex ett kundregister.

Exempel p� en tabell:

![File](img/file.png)

En tabell �r det s�ttet du lagrar information i en databas. 


Varje tabell �r uppdelad i f�lt. F�lten i kundtabellen ovan �r: CustomerID, CustomerName, ContactName, Address, City, PostalCode and Country. 

En **record** �r samma sak som en **rad** i en tabell.

## SQL Statements

Det mesta du beh�ver g�ra med en databas utf�rs med SQL-kommandon.

H�r �r ett exempel p� ett SQL-kommando som h�mtar alla rader i Customers-tabellen:

    SELECT * from Customers

Ett exempel till som bara h�mtar tv� kolumner:

    SELECT CustomerName, City 
    FROM Customers;

H�mta bara de rader d�r kunden bor i Mexico:

    SELECT * FROM Customers
    WHERE Country='Mexico';

H�mta de kunder som inte bor i varken Tyskland eller USA:

    SELECT * FROM Customers
    WHERE NOT Country='Germany' AND NOT Country='USA';

Sortera kunderna utifr�n land. D�refter utifr�n namn.

    SELECT * FROM Customers
    ORDER BY Country, CustomerName;

Det finns �ven kommandon f�r att l�gga till info:

    INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
    VALUES ('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway');

... och uppdatera:

    UPDATE Customers
    SET ContactName = 'Alfred Schmidt', City= 'Frankfurt'
    WHERE CustomerID = 1;

...och ta bort:

    DELETE FROM Customers
    WHERE CustomerName='Alfreds Futterkiste';

Det g�r �ven att skapa helt nya tabeller:

    CREATE TABLE Persons (
        PersonID int,
        LastName varchar(255),
        FirstName varchar(255),
        Address varchar(255),
        City varchar(255) 
    );



----

# �vrig


## Vad �r null?

Ett f�lt som inte har ett v�rde f�r v�rdet NULL 

Det �r inte samma som tom str�ng "" eller t.ex siffran 0.

## Vad �r constraints?

Ett s�tt att begr�nsa vilken data som f�r sparas i databasen.

T.ex: NOT NULL betyder att en kolumn inte f�r ha tomma v�rden

UNIQUE: s�ger att en kolumns v�rden inte f�r dyka upp flera g�nger i samma tabell

## Varf�r normalisering?

Databasnormalisering �r processen f�r att organisera data p� ett effektivt s�tt i en databas.

Varf�r?
- Tar bort redundant data (t.ex att spara samma data i mer �n en tabell)
- Se till att data beroenden �r vettiga

En effekt �r att databasen tar mindre plats p� h�rddisken.

Den tredje normalformen �r gott nog att komma till.

## Datatyper

I en databas kan du spara
- siffror
- str�ngar och tecken
- datum
- bin�rdata

Mer specifikt:
- Exact Numeric Data Types
- Approximate Numeric Data Types
- Date and Time Data Types
- Character Strings Data Types
- Unicode Character Strings Data Types
- Binary Data Types
