# Bloggy

Gör en consoleapp där användaren kan: 
- Se alla bloggposter
- Uppdatera en bloggpost (t.ex rubriken)
- Ta bort en bloggpost
- Lägga till en tagg för en bloggpost
- Ta bort en tagg
- Lägga till en kommmentar på en bloggpost
- Visa en bloggposts kommentarer

I korthet, kunna göra CRUD-optioner (Create Read Update Delete) på:
- Bloggposter
- Kommentarer
- Taggar

## Extra

1. Karma: hjälp en eller fler kollegor i minst 15 min

2. Lägg till validering 

3. Se över dina metoder så de är korta och gör en sak. Se över namngivning på metoder och variabler.

4. Se över dina klasser så de är korta bara har ansvar för ett område.

## Extra II

Välj en eller flera av följande:

* Lägg till **två extra fält** för BloggPost eller Comment och uppdatera din kod.

* Lägg tid på att snygga till **GUI’t**. Färger, typsnitt, radavstånd etc.

* Om användaren trycker på en knapp så visa en **hjälpassisten** (tänk det populära gemet i gamla word) som ger stöd i hur programmet används.

* Lägg till ett testprojekt med fler testmetoder

* Installera log4net eller nLog. Lägg till **loggning**. Logga alla CRUD-operationer, om det går bra eller dåligt. T.ex om en bloggpost har skapats eller om användaren matat in felaktigt format på ett  telefonnummer.

* Skapa en fil med **sql-kommandon** (textfil) som 
    * Tar bort databasen
    * Skapar en ny databas och tabeller
    * Fyller tabellerna med startvärden

    Skapa en metod som läser in textfilen och kör sql-kommandona. Låt användaren kunna återskapa databasen.

* Lägg till en **sökfunktion**. Låt användaren kunna söka med fritext. Sök alltså på alla fält och rangordna resultatet på lämpligt sätt.

* Om användaren vill **ta bort** en bloggpost som har kommentarer kopplade till sig kan två saker hända:

  * Programmet ger ett felmeddelande och tar inte bort något
  * Programmet tar bort bloggposten och alla kopplade kommentarer

    Låt programmets beteende vara konfigurerbart (t.ex i en fil)

* Låt ditt program vara sårbart för **SQL-injection**. Om användaren matar in ett förnamn: “kalle’); drop table BlogPost; --” så ska alla bloggposter raderas. I en konfigureringsfil anges om ditt program ska vara sårbart eller ej.

* Undersök **transaktioner**. Gör en metod som utför flera SQL-kommandon samtidigt och om någon av kommandon’a misslyckas så ska inget kommando utföras. Testkör detta och verifiera att det fungerar. 

* Gör en **avancerad sökfunktion**. Tillåt att användaren matar in nästa rätt (t.ex Rger istället för Roger). Vikta resultatet. Låt en administratör kunna ändra de viktade värdena så sökresultaten hamnar i en annan ordning.

* Låt användaren kunna **sortera** sökresultaten på olika sätt (utifrån förnamn, datum etc)