
# Checkpoint - Listor

## Intro

I uppgifterna nedan ska du bara skapa **metoder** som jobbar med listor.

## Tid 

2h

## Level 1

Skriv en metod **MultiplyBy100AndAdd3** som tar en lista av heltal som parameter och returnerar en ny lista med heltal.

Multiplicera varje tal med 100 och lägg till 3

Exempel, listan:

    2 8 3 11

...ska returnera listan

    203 803 303 1103

Använd **ej** Console.Write eller Console.Readline i metoden *MultiplyBy100AndAdd3*.

Anropa din metod med en lista och skriv ut resultatet:

![](level1.PNG)

(användaren behöver inte mata in något)


## Level 2

Lös först level 1 (krav)

Skapa sedan en metod **ReorderList** som returnerar en ny lista där ordningen är omkastad.

Exempel

    List<string> result1 = ReorderList(new List<string> { "a", "b", "c", "d", "e" }, new List<int> { 1, 2, 3, 5, 4 });

...ska returnera listan

    a b c e d
Exempel

    List<string> result2 = ReorderList(new List<string> { "a", "b", "c", "d" }, new List<int> { 3, 1, 4, 2 });

...ska returnera listan

    c a d b

Exempel

    List<string> result3 = ReorderList(new List<string> { "a", "b" }, new List<int> { 2, 2 });

...ska returnera listan

    b b

Skapa ett *testprojekt* med tre testmetoder som testar exemplen ovan.

I denna uppgift ska du alltså inte skriva ut något i consolen.  