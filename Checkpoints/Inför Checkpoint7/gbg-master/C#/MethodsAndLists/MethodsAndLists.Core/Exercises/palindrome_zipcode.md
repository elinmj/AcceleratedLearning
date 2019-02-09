# Palindrom och postgiro


Skapa en klass i testprojektet *MethodsAndLists.Test*:

    StringToBoolTests.cs

Skapa en klass i klassprojektet *MethodsAndLists.Core*:

    StringToBool.cs

## Palindrom

Skapa en metod i klassen *StringToBool*:

    public bool IsPalindrome(string word)
    {
    }

...som kollar om ett ord är ett palindrom.

Tillåt bara svenska tecken som inparameter. Tillåt inte några andra tecken (som t.ex blanksteg).

Exempel på palindrom: 

    abcba

Exempel på icke-palindrom:

    abcb

Skapa tester för att verifiera att din metod *IsPalindrome* funkar. Kolla även på "edge-cases", t.ex om metoden anropas med *null*

## Zipcode

Skapa en metod i klassen *StringToBool*:

    IsZipCode

som returnerar *true* eller *false* beroende på om inparametern är en postgirokod.

Exempel på postgiro

    123 45
    444 88

Exempel på icke-postgiro

    023 45
    44488
    PANDA

Skriv tester för att verifiera att din kod funkar.

## Extra

1. Kolla vad dina kollegor har skrivt för testfall (t.ex korrekta/felaktiga postnummer) och testa dessa i din kod.
2. Jämför med dina kollegor hur du tolkat uppgifterna. Skiljer det sig åt på något sätt?
3. Skriv flera varianter av *IsPalindrome* och *IsZipCode* (t.ex med och utan LINQ eller RegEx) och verfiera att alla dina metoder funkar.
4. Jämför dina lösningar med dina kollegors lösningar