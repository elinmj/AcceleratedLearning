# Spela ett kortspel


## Intro

Denna uppgift går ut på att skapa en kortlek och ett kortspel med hjälp av objektorienterad programmering i C#. 

Uppgiften är väldigt öppen för egna tolkningar och implementationer, och ni sätter själva ambitionsnivån på uppgiften. 

Skapa en console-app och gärna ett testprojekt som verfifierar delar av din kod.


## Uppgift

Följande är kraven på vad uppgiften måste innehålla:
- En klass **PlayingCard** som representerar ett vanligt spelkort.
PlayingCard ska innehålla:
    - Färg/svit. Dvs spader (♠), hjärter (♥), ruter (♦) och klöver (♣)
    - Valör. Dvs ess, 2, 3, 4, 5, 6, 7, 8, 9, 10, knekt, dam, kung
    - Indikerar om ett kort är vänt/dolt eller inte. Dvs, är färg/svit och valör synlig
- En klass **PlayingCardDeck** som representerar en kortlek på 52 kort av typen PlayingCard. PlayingCardDeck ska innehålla:

    - Minst en datastruktur för att lagra alla PlayingCard objekt.
Tex Array, List, Directory, etc.
    - En metod som tar ut det översta/första kortet från PlayingCardDeck.
Implementera på valfritt sätt vad som ska hända om kortleken är tom och man anropar metoden (ska den returnera null / false? Ska den kasta ett exception? etc).
    - En metod för att lägga till ett kort underst/längst bak på PlayingCardDeck.
- En spelklass **PlayingCardGame** som använder minst en instans av PlayingCardDeck för att spela ett kortspel. PlayingCardGame ska innehålla:
    - Skapa en blandad kortlek som spelet ska använda sig av
    - Kunna spela som en eller flera spelare. Detta är helt beroende på vilket spel man väljer att implementera.
    - Kunna vinna / förlora / få oavgjort i spelet. Med andra ord, man ska kunna spela ett kortspel.
    - Spara undan historik (tex highscore, antal spelade partier, etc.). Man kan spara undan denna information genom att skriva/läsa till en text-fil som ligger lokalt på datorn.
    - Innehålla en meny som ger användaren följande alternativ:
        - Spela ett parti
        - Visa spelregler
        - Visa statistik (tex highscore, antal spelade partier, etc)
        - Avsluta spelet
- Projektet ska vara skrivet i C# och laddas upp i ett publikt repository på GitHub.

Exempel på ett kortspel du kan implementera:

#### Högt eller lågt?
Två dolda kort tas ut från kortleken: det ena kortet ges till dig och det andra kortet läggs ut öppet så
att du kan se det. Nu ska du gissa om ditt dolda kort är högre eller lägre än det öppna kortet. Om du
gissar rätt/fel har du vunnit/förlorat och partiet är över. Om korten har samma valör jämför man färg
där spader (♠) > hjärter (♥) > ruter (♦) > klöver (♣). Efter ett parti ska bägge korten stoppas
tillbaka längst bak i kortleken och man ska bli tillfrågad om man vill spela ett nytt parti eller gå
tillbaka till huvudmenyn. När man spelat ett spel ska ens poängställning (antal vinter/förluster)
skrivas ner till fil och uppdatera sin spelarstatus-historik (totala vinster/förluster).

#### Alternativ

Exempel på andra kortspel man kan implementera:
- Singel spel 
  - Patiens, tex ”Harpan”
- Mot datorn och/eller flera spelare som turas om att spela
    - Svarte Petter
    - Finns i sjön
    - Poker
    - Black Jack
    - Bridge
    - Stress/bubblan
    - Andra egna kortspel du har kommit på!
    
## Extra


Följande modifieringar kan ni göra om ni har tid över och vill fördjupa er inom objekt orienterad
programmering. 
- Läs på om **enum** och hur du kan använda Enum i tex klassen PlayingCard för att
representera färg och valör.
- Skapa ett **testprojekt** med testmetoder som verifierar att delar av din kod är korrekt
- Läs på om **inheritance**. Skapa en abstrakt klass Card och modifiera klassen PlayingCard så
att den ärver sina variabler/metoder från klassen Card. Skapa andra spelkort utöver
PlayingCard som också ärver från Card som tex UnoCard, PokemonCard,
TarotCard, HockeyCard, StudyCard etc.
- Läs på om **interface**. Skapa ett interface CardDeck som innehåller de metodsignaturer man 
kan förvänta sig att man kan göra med en kortlek – tex metoder så som TakeCard, InsertCard,
Shuffle, Sort, osv. Modifiera klassen PlayingCardDeck så att den implementerar
interface:et CardDeck. Om du har skapat andra kort, använd
interface:et CardDeck för att skapa andra kortlekar – tex UnoCardDeck,
PokemonCardDeck, TarotCardDeck, HockeyCardDeck, StudyCardDeck etc.
- Låt användaren spela **olika kortspel** från menyn! Om man har gjort de föregående stretch
task:en om inheritance och interface, försök att göra den abstrakta klassen Card och
interface:et CardDeck så generell som möjlig så att man kan spela olika kortspel med olika
kortlekar – tex spela ”Finns i sjön” med en UNO kortlek, eller utföra spådomar med
pokémonkort!

