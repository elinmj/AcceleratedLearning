# Samurai2 - H�mta och modifiera samurajer

## Intro

Vi forts�tter med v�r samuraiapp. 

Nu ska vi l�gga till en console-app och l�gga till metoder f�r att l�gga till och  ta bort rader i tabellerna.

## Ny console app

L�gg till ett nytt projekt av typen **Console App (.NET Core)**. 

D�p projektet till **EfSamurai.App**

## 
## AddOneSamurai

Skriv en metod **AddOneSamurai**, som l�gger till en Samuraj

    private static void AddOneSamurai()
    {
        var samurai = new Samurai { Name = "Zelda" };
    
        using (var context = new SamuraiContext())
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
    }

...alternativt utan using:

    private static void AddOneSamurai()
    {
        var samurai = new Samurai { Name = "Zelda" };
    
        var context = new SamuraiContext();
        context.Samurais.Add(samurai);
        context.SaveChanges();
    }



## AddSomeSamurais

Skriv en metod **AddSomeSamurais**, som l�gger till flera Samurajer. Anv�nd **AddRange**.


## AddSomeBattles

Skriv en metod **AddSomeBattles** som l�gger till ett par Battles. Med tillh�rande BattleLog och ett par BattleEvents.


## AddOneSamuraiWithRelatedData

Skriv en metod **AddOneSamuraiWithRelatedData** som skapar en samuraj och fyller hela databasen. Allts� alla tabeller och kolumner ska anv�ndas.


## ClearDatabase

Skriv en metod ClearDatabase som rensar databasen p� allt inneh�ll.

Tips: anropa denna metod i b�rjan av ditt program s� �r det l�ttare att testa.


## ListAllSamuraiNames

Skriv en metod ListAllSamuraiNames som skriver ut namnen p� alla samurajer


## ListAllSamuraiNames_OrderByName

Skriv ut namnen och sortera p� f�rnamn


## ListAllSamuraiNames_OrderByIdDescending

Skriv ut namnen och sortera i omv�nde ordning p� Id.


## FindSamuraiWithRealName(string name)

Hitta den samuraj som har ett visst realname (SecretIdentity).

Skriv olika meddelande om samurajen hittades eller ej.


## ListAllQuotesOfType(QuoteStyle quoteStyle)

Lista alla citat av en viss typ


## ListAllQuotesOfType_WithSamurai(QuoteStyle quoteStyle)

Lista alla citat av en viss typ tillsammans med Samurajen som sa det. T.ex:


    'Carpe diem' is a cheesy quote by Kalle
    'Everything happens for a reason' is a cheesy quote by Kalle


## ListAllBattles(DateTime from, DateTime to, bool? isBrutal)

Lista alla slag som p�g�r inom ett tidsintervall. Och filtrera p� **isBrutal** om den �r n�got annat �n null.


    'Battle 1' is a brutal battle within the period
    'Battle 2' is not a brutal battle within the period

