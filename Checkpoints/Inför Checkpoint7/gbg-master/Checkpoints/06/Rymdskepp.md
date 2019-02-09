# Checkpoint - Rymdskepp

## Intro

Du ska skriva en app som sparar och h�mtar rymdskepp.

L�s denna uppgift med **Entity Framework Core**

N�r du l�mnar in s� skapa en metod som �terskapar databasen: 

    private void RecreateDatabase()
    {
        using (var context = new SpaceContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }

Anropa denna metod n�r ditt program startar.

F�r att f� godk�nt ska det r�cka med att starta programmet fr�n en annan dator. Tips: testa detta genom att ta bort din databas och sedan k�ra programmet. 

## Level 1

G�r en metod **AddSpaceship** som l�gger till ett rymdskepp i databasen.

Skriv dessutom metoderna **GetAllSpaceships** och **DisplaySpaceships**

S� h�r **ska** ditt huvudprogram se ut:

    RecreateDatabase();
            
    AddSpaceship("USS Enterprise");
    AddSpaceship("Millennium Falcon");
    AddSpaceship("Cylon Raider");

    List<Spaceship> list = GetAllSpaceships();
    DisplaySpaceships(list);

...och det ska ge f�ljande resultat:

![Rymdskepp 2](Rymdskepp_1.png)


## Level 2

F�r att kunna flyga l�ngt i rymden kr�vs ett lager med ravioli. 

All ravioli har ett packdatum och ett b�stf�redatum. B�stf�redatumet �r alltid 6 m�nader och 15 dagar senare �n packdatumet.

Skriv en metod **AddRavioliForSpaceship** som f�rv�ntar sig namn p� ett rymdskepp och ett antal ravioliburkar samt deras packdatum. Om det finns ett rymdskepp med detta namn s� l�ggs burkarna i skeppet. Annars sker ingenting.

S� h�r **ska** ditt huvudprogram se ut:

    RecreateDatabase();
            
    AddSpaceship("USS Enterprise");
    AddSpaceship("Millennium Falcon");
    AddSpaceship("Cylon Raider");

    AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
    AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
    AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
    AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

    List<Spaceship> list = GetAllSpaceships();
    DisplaySpaceships(list);

...och det ska ge f�ljande resultat:

![Rymdskepp 3](Rymdskepp_3.png)