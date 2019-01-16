# Bloggy

G�r en consoleapp d�r anv�ndaren kan: 
- Se alla bloggposter
- Uppdatera en bloggpost (t.ex rubriken)
- Ta bort en bloggpost
- L�gga till en tagg f�r en bloggpost
- Ta bort en tagg
- L�gga till en kommmentar p� en bloggpost
- Visa en bloggposts kommentarer

I korthet, kunna g�ra CRUD-optioner (Create Read Update Delete) p�:
- Bloggposter
- Kommentarer
- Taggar

## Extra

1. Karma: hj�lp en eller fler kollegor i minst 15 min

2. L�gg till validering 

3. Se �ver dina metoder s� de �r korta och g�r en sak. Se �ver namngivning p� metoder och variabler.

4. Se �ver dina klasser s� de �r korta bara har ansvar f�r ett omr�de.

## Extra II

V�lj en eller flera av f�ljande:

* L�gg till **tv� extra f�lt** f�r BloggPost eller Comment och uppdatera din kod.

* L�gg tid p� att snygga till **GUI�t**. F�rger, typsnitt, radavst�nd etc.

* Om anv�ndaren trycker p� en knapp s� visa en **hj�lpassisten** (t�nk det popul�ra gemet i gamla word) som ger st�d i hur programmet anv�nds.

* L�gg till ett testprojekt med fler testmetoder

* Installera log4net eller nLog. L�gg till **loggning**. Logga alla CRUD-operationer, om det g�r bra eller d�ligt. T.ex om en bloggpost har skapats eller om anv�ndaren matat in felaktigt format p� ett  telefonnummer.

* Skapa en fil med **sql-kommandon** (textfil) som 
    * Tar bort databasen
    * Skapar en ny databas och tabeller
    * Fyller tabellerna med startv�rden

    Skapa en metod som l�ser in textfilen och k�r sql-kommandona. L�t anv�ndaren kunna �terskapa databasen.

* L�gg till en **s�kfunktion**. L�t anv�ndaren kunna s�ka med fritext. S�k allts� p� alla f�lt och rangordna resultatet p� l�mpligt s�tt.

* Om anv�ndaren vill **ta bort** en bloggpost som har kommentarer kopplade till sig kan tv� saker h�nda:

  * Programmet ger ett felmeddelande och tar inte bort n�got
  * Programmet tar bort bloggposten och alla kopplade kommentarer

    L�t programmets beteende vara konfigurerbart (t.ex i en fil)

* L�t ditt program vara s�rbart f�r **SQL-injection**. Om anv�ndaren matar in ett f�rnamn: �kalle�); drop table BlogPost; --� s� ska alla bloggposter raderas. I en konfigureringsfil anges om ditt program ska vara s�rbart eller ej.

* Unders�k **transaktioner**. G�r en metod som utf�r flera SQL-kommandon samtidigt och om n�gon av kommandon�a misslyckas s� ska inget kommando utf�ras. Testk�r detta och verifiera att det fungerar. 

* G�r en **avancerad s�kfunktion**. Till�t att anv�ndaren matar in n�sta r�tt (t.ex Rger ist�llet f�r Roger). Vikta resultatet. L�t en administrat�r kunna �ndra de viktade v�rdena s� s�kresultaten hamnar i en annan ordning.

* L�t anv�ndaren kunna **sortera** s�kresultaten p� olika s�tt (utifr�n f�rnamn, datum etc)