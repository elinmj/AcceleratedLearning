# SQL – Modellera biluthyrning

## Uppgift

Biluthyrningsfirma **Car Rental Supreme** vill skapa ett datorsystem för att hålla reda på sina kunder, bokningar och bilar. Just nu använder de papper och penna och det blir väldigt rörigt. För att bygga datorsystemet så ska först en databasmodell tas fram.
Du har haft ett möte med Car Rental Supreme där de berättat om vilka behov de har och du har antecknat för fullt. Utifrån dessa anteckningar ska du designa en databas. Här är dina anteckningarna:
 
    En kund ska kunna boka en bil under en tidsperiod. 

    Det är inte säkert att kunden kommer vara den som kör bilen, så även föraren ska sparas i bokningen.

    Grundläggande uppgifter (förnamn, efternamn ,personnummer, adress) ska kunna sparas för kunder och även bilförare.

    Kunder som ofta hyr av firman ska kunna få rabatt. Det ska finnas tre nivåer Standard, Premium, Gold. Premium ska ge 10% rabatt och Gold ska ge 25% rabatt.

    Biluthyrningsfirman har för närvarande tre bilmärken: Scoda, Volvo, BMW

    Bilarna har just nu dessa olika färger: Red, White, Black

    Det finns tre storlekar på bilar: Minicar, Normal, SUV. Om en kund hyr en Minicar ska han få 50% rabatt. En SUV kostar 2.5 ggr mer än en Normal.

    Betalning kan ske via kort, kontant eller faktura (vid faktura behöver fakturaadressen sparas). 
 
Ta fram vilka tabeller och kolumer som du anser behövs.
Lägg till lämpliga primärnycklar, index och relationer till tabellerna. 

Allt handlar om databasmodellering, att skapa tabeller och relationer. Du behöver inte utföra några beräkningar för t.ex rabatter eller någon annan funktionalitet. Bara möjliggöra att man i databasen kan justera en rabatt. Hela uppgiften löses i **SQL Management Studio**. 

Fyll databasen med lämpliga testvärden.

## Extra

1. CRS (Car Rental Supreme) har ett antal parkeringsrutor. De vill hålla reda på var bilarna är parkerade. 

2. Vissa parkeringsrutor är små och där få inte SUV’arn plats. Uppdatera databasmodellen för detta scenario.

3. Nu går det bra för företaget och de har startat flera kontor. CRS vill hålla koll på vilket kontor som har vilka bilar etc.

4. CRS expanderar och finns nu i hela Sverige. Det finns tre kontor i göteborgsområdet, två i Stockholm och en Malmö. Uppdatera databasmodellen.

5. Det går bra i Göteborg och de har nu fem kontor.  CRS har bestämt att deras företag ska delas in i regioner har nu bildat regioner istället. Dessa finns just nu:
- Göteborg Norra
- Göteborg Södra
- Stockholm
- Malmö

6. De flesta bilar hyrs ut av ett kontor men vissa bilar delas av flera kontor. Uppdatera databasmodellen.

7. Fundera på vilken ytterligare information en biluthyrare kan behöva hantera. 
Lägg till ett par tabeller med tillhörande kolumner och ev relationer/index. Motivera ditt val. Redovisa för din lärare.


