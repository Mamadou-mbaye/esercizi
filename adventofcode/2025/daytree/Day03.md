# Day 3 — Lobby (2015)

**Contesto:** L'input ha una riga per ogni "bank" di batterie, ognuna una sequenza di cifre (1-9). Bisogna scegliere alcune cifre da "accendere" (mantenendo l'ordine originale, senza riordinare) per formare il numero più grande possibile, poi sommare i risultati di tutti i bank.

## Parte 1
Scegliere esattamente **2** cifre per formare il numero a 2 cifre più grande possibile.

- Strategia: trovare la **prima occorrenza** della cifra massima nel bank, usarla come prima cifra; poi cercare la cifra massima tra quelle **dopo** quella posizione, come seconda cifra.
- Caso speciale: se la cifra massima globale è l'**ultima** posizione del bank, non può essere usata come prima cifra (non ci sarebbe nulla dopo) — va usata come seconda cifra fissa, cercando il massimo tra tutte le altre come prima cifra.
- Perché funziona: prendere la prima occorrenza del massimo garantisce il maggior numero di cifre rimanenti disponibili per la seconda scelta — qualunque occorrenza successiva darebbe una scelta più ristretta, quindi mai migliore.
- Costruire il numero con `primaCifra * 10 + secondaCifra` è più diretto che passare per `string.Concat` + `Parse`.
- Complessità: O(n) — un `Max()`, un `IndexOf()` e un filtro, tutti in sequenza sullo stesso array (non annidati).

## Parte 2
Scegliere esattamente **12** cifre per formare il numero più grande possibile (stesso principio, generalizzato).

- **Tecnica dello stack con budget:** si scorre il bank cifra per cifra, mantenendo una pila (lista) del risultato in costruzione.
  - `budget = lunghezza_bank - 12` → quante cifre ci si può permettere di scartare in totale.
  - Per ogni nuova cifra: finché l'ultimo elemento in pila è **più piccolo** della cifra corrente E c'è ancora budget disponibile, si rimuove l'ultimo elemento dalla pila (budget--) e si ricontrolla.
  - Si aggiunge la cifra corrente in fondo alla pila.
  - Se a fine ciclo la pila ha ancora più di 12 elementi (budget non esaurito durante il ciclo), si prendono solo i primi 12.
- **Bug preso:** rimuovere l'ultimo elemento della pila con `list.RemoveAt(list.IndexOf(valore))` è sbagliato se ci sono valori duplicati — `IndexOf` trova la **prima** occorrenza del valore, non necessariamente l'ultimo elemento della lista. Va usato `list.RemoveAt(list.Count - 1)` per rimuovere esplicitamente l'ultimo elemento.
- **Osservazione su codice ridondante:** non serve pre-filtrare il bank per trovare "a mano" la cifra massima iniziale prima di applicare lo stack — l'algoritmo a stack, applicato a tutto il bank fin dall'inizio, arriva automaticamente allo stesso risultato, eliminando da solo le cifre iniziali "deboli" durante il ciclo. Principio generale: se un meccanismo più generale già gestisce correttamente un caso specifico, non serve duplicare la logica con un controllo a parte.

## Concetti chiave usati
- Strategia greedy: scegliere sempre la cifra migliore disponibile localmente, rispettando un vincolo di "slot rimanenti"
- Tecnica dello stack/pila per costruire una sottosequenza ottima mantenendo l'ordine originale (pattern classico, riutilizzabile per problemi simili in futuro)
- Attenzione a `IndexOf` con valori duplicati — cercare per valore non è lo stesso che riferirsi a una posizione specifica
- Riconoscere e rimuovere logica ridondante quando un algoritmo più generale già copre un caso particolare
