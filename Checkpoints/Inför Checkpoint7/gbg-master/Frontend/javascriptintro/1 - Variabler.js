﻿
var5();

function var1() {
    /* Skriv ut "Jag heter XXXX" i consolen */
    console.log('Jag heter Oscar');
}

function var2() {
    /* 
    Skapa variabel och sätt det till 35. 
    Meddela värdet av siffran (med hjäp av "console.log")
    */

    let number1 = 35;
    console.log(number1);
}

function var3() {

    /*
     Skapa en variabel "x" med värdet 12
     Skapa en variabel "y" med värdet 6
     Skapa en variabel "z" som summerar talen
     Skriv ut svaret "Svar: 18"
    */
    let x = 12;
    let y = 6;
    let z = x + y;
    console.log('Svar: ' + z);
}

function var4() {

    /*
    Modifera koden du skapat sist och se vilka effekter/felmeddelanden som dyker upp
    Experimentera!

    Skapa en variabel "x" med värdet 77
    Skapa en variabel "y" med värdet 44
    Ändra värdet av "x" till 55
    Skapa en variabel "z" som summerar talen
    Skriv ut summan
    */
    let x = 77;
    let y = 44;
    x = 55;
    let z = x + y;
    console.log('Svar: ' + z);
}


function var5() {

    /*
     Samma som sist men låter x vara en konstant (const)
    Vilket felmeddelande dyker upp?
    */
    const x = 77;
    let y = 44;
    x = 55; // TypeError: Assignment to constant variable

    let z = x + y;
    console.log('Svar: ' + z);
}

function var6() {
    /*
    Modifera koden du skapat sist och se vilka effekter/felmeddelanden som dyker upp
    Experimentera!

    Skapa en variabel "nummer1" och sätt den till strängen "77" 
    Skapa en variabel "nummer2" och sätt den till strängen "50"
    Skriv ut nummer1+nummer2 (ska ge 7750)
    */
    let nummer1 = "77";
    let nummer2 = "50";
    console.log(nummer1 + nummer2);
}

function var7() {
    /*
    Skapa en variabel "nummer1" och sätt den till strängen "77" 
    Skapa en variabel "nummer2" och sätt den till 50
    Använd parseInt för att omvandla "nummer1" till siffran 77
    Skriv ut nummer1+nummer2 (ska ge 127)
    */
    let nummer1 = "77";
    let nummer2 = 50;
    nummer1 = parseInt(nummer1);
    console.log(nummer1 + nummer2);
}

function var8() {
    /*
    Skapa variabel nummer med värdet 42. 
    Skriv ut "Mitt favorittal är 42" (om det är 42).
    */
    let nummer = 42;
    console.log("Mitt favorittal är " + nummer);
}

function var9() {

    /* Använd "snedfnutt" (alltså teckenet `) för att lösa problemet ovan */

    let nummer = 42;
    console.log(`Mitt favorittal är ${nummer}`);
}

function var10() {
    /*
    Skapa en variabel "middag" och sätt den till 'broccoli'
    Skapa en variabel "Middag" och sätt den till 'pasta'
    Meddela värdet av "middag"
    */
    let middag = 'broccoli';
    let Middag = 'pasta';
    console.log(middag);
}

function var11() {
    /*
    Skapa en variabel x med värdet 12
    Skapa en variabel y med värdet true
    Skapa en variabel z med värdet 'måndag'
    Skapa en variabel w utan att sätta något värde
    Skriv ut typen av dessa fyra variabler mha "typeof"
    */
    let x = 12;
    console.log(typeof x); // number

    let y = true;
    console.log(typeof y); // boolean

    let z = 'måndag';
    console.log(typeof z); // string

    let w;
    console.log(typeof w); // undefinied
}

function var12() {
    /*
    Skapa en variabel "x". Sätt värdet till "parseInt('oscar')"
    Skriv ut x (ska ge "NaN")
    Använd "isNaN" fär att kolla om x är ett icke-nummer. Sätt y till det värdet (y kommer få värdet true)
    Skriv ut y
    */
    let x = parseInt('oscar', 10);
    console.log(x); // "NaN"

    let y = isNaN(x);
    console.log(y);
}

