# Day 1 — Not Quite Lisp... ehm, no: Safe Cracking (2015)

**Contesto:** Un dial circolare con numeri da 0 a 99. Parte sempre dalla posizione **50**. Riceve una sequenza di rotazioni (una per riga di input), ognuna nel formato `L<n>` o `R<n>` (L = sinistra/sottrai, R = destra/aggiungi), con wrap-around circolare (da 99 si torna a 0 e viceversa).

## Parte 1
Contare quante volte il dial si ferma esattamente su 0 **alla fine** di una rotazione.

- Soluzione: aggiornare la posizione ad ogni riga con `(position + delta) % 100`, correggendo se negativo (`+100`), e controllare se il risultato è 0.

## Parte 2
Contare quante volte il dial passa per lo 0 **in totale**, incluso durante una rotazione lunga (non solo alla fine). Esempio: `R1000` da 50 passa per lo 0 dieci volte.

- Soluzione: per ogni rotazione, calcolare quanti giri completi da 100 click fa (`rotate / 100`, ogni giro = 1 passaggio garantito per lo 0), più eventualmente 1 passaggio extra se il resto della rotazione (`rotate % 100`) supera la distanza dalla posizione attuale allo 0 nella direzione scelta.
- **Attenzione/bug preso:** bisogna comunque aggiornare la posizione ad ogni riga (con la formula della parte 1) per usarla come punto di partenza della riga successiva — altrimenti ogni riga viene calcolata partendo sempre da 50, dando un risultato sbagliato.

## Concetti chiave usati
- Aritmetica modulare (`%`)
- Gestione del wrap-around circolare
- Differenza tra "contare un evento finale" vs "contare un evento durante un processo continuo"
