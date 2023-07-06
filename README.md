# Generator de parole manual

## Solutie

1) Introducem de la tastatura userID-ul, data si ora.
2) Despartim aceasta intrare in 3 string-uri.
3) Pentru a verifica daca am scris formatul datei si al orei corect, concatenam stringul "date" si string-ul "time".
4) Daca verificarea a avut succes trece la urmatoarea etapa, in caz contrar se afiseaza un mesaj de atentionare.
6) Etapa care urmeaza se afla intr-un if si genereaza o parola aleatoare, seteaza un timer de 30 de secunde si deschide o bucla while.
7) Parolele se genereaza doar cand este apasata tasta "Enter".
8) Scopul buclei while este de a astepta ca utilizatorul sa apese tasta "Enter" pentru a generarea o noua parola.
9) Apasand tasta "Enter", se afiseaza o parola si un mesaj de atentionare ca parola va expira in 30 de secunde.


## Date format 
https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact?view=net-7.0
## Timer 
https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-7.0
## Press a specific key 
https://stackoverflow.com/questions/50290855/end-the-for-loop-by-keyboard-input-c-sharp
## Random password with given characters 
https://www.c-sharpcorner.com/article/how-to-generate-a-random-password-in-c-sharp-and-net-core/
