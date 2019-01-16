# SQL � Modellera biluthyrning

## Uppgift

Biluthyrningsfirma **Car Rental Supreme** vill skapa ett datorsystem f�r att h�lla reda p� sina kunder, bokningar och bilar. Just nu anv�nder de papper och penna och det blir v�ldigt r�rigt. F�r att bygga datorsystemet s� ska f�rst en databasmodell tas fram.
Du har haft ett m�te med Car Rental Supreme d�r de ber�ttat om vilka behov de har och du har antecknat f�r fullt. Utifr�n dessa anteckningar ska du designa en databas. H�r �r dina anteckningarna:
 
    En kund ska kunna boka en bil under en tidsperiod. 

    Det �r inte s�kert att kunden kommer vara den som k�r bilen, s� �ven f�raren ska sparas i bokningen.

    Grundl�ggande uppgifter (f�rnamn, efternamn ,personnummer, adress) ska kunna sparas f�r kunder och �ven bilf�rare.

    Kunder som ofta hyr av firman ska kunna f� rabatt. Det ska finnas tre niv�er Standard, Premium, Gold. Premium ska ge 10% rabatt och Gold ska ge 25% rabatt.

    Biluthyrningsfirman har f�r n�rvarande tre bilm�rken: Scoda, Volvo, BMW

    Bilarna har just nu dessa olika f�rger: Red, White, Black

    Det finns tre storlekar p� bilar: Minicar, Normal, SUV. Om en kund hyr en Minicar ska han f� 50% rabatt. En SUV kostar 2.5 ggr mer �n en Normal.

    Betalning kan ske via kort, kontant eller faktura (vid faktura beh�ver fakturaadressen sparas). 
 
Ta fram vilka tabeller och kolumer som du anser beh�vs.
L�gg till l�mpliga prim�rnycklar, index och relationer till tabellerna. 

Allt handlar om databasmodellering, att skapa tabeller och relationer. Du beh�ver inte utf�ra n�gra ber�kningar f�r t.ex rabatter eller n�gon annan funktionalitet. Bara m�jligg�ra att man i databasen kan justera en rabatt. Hela uppgiften l�ses i **SQL Management Studio**. 

Fyll databasen med l�mpliga testv�rden.

## Extra

1. CRS (Car Rental Supreme) har ett antal parkeringsrutor. De vill h�lla reda p� var bilarna �r parkerade. 

2. Vissa parkeringsrutor �r sm� och d�r f� inte SUV�arn plats. Uppdatera databasmodellen f�r detta scenario.

3. Nu g�r det bra f�r f�retaget och de har startat flera kontor. CRS vill h�lla koll p� vilket kontor som har vilka bilar etc.

4. CRS expanderar och finns nu i hela Sverige. Det finns tre kontor i g�teborgsomr�det, tv� i Stockholm och en Malm�. Uppdatera databasmodellen.

5. Det g�r bra i G�teborg och de har nu fem kontor.  CRS har best�mt att deras f�retag ska delas in i regioner har nu bildat regioner ist�llet. Dessa finns just nu:
- G�teborg Norra
- G�teborg S�dra
- Stockholm
- Malm�

6. De flesta bilar hyrs ut av ett kontor men vissa bilar delas av flera kontor. Uppdatera databasmodellen.

7. Fundera p� vilken ytterligare information en biluthyrare kan beh�va hantera. 
L�gg till ett par tabeller med tillh�rande kolumner och ev relationer/index. Motivera ditt val. Redovisa f�r din l�rare.


