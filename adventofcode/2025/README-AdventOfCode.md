# Advent of Code 2015 — Riepilogo generale (Day 1-3)

*Progetto per allenare problem solving e logica, in C#. Ogni giorno ha il suo file di dettaglio (`Day01.md`, `Day02.md`, `Day03.md`).*

---

## Concetti tecnici/algoritmici coperti

**Day 1 — Aritmetica modulare e wrap-around circolare**
- Uso di `%` per gestire un valore che si "avvolge" in un range circolare (0-99)
- Gestione del modulo con numeri negativi in C# (`%` non dà sempre un risultato positivo, serve correggerlo a mano con `+100`)
- Differenza tra "contare un evento alla fine di un processo" vs "contare un evento durante tutto il processo"
- Calcolo diretto (giri completi + resto) invece di simulare click per click, per efficienza

**Day 2 — Generazione di candidati invece di brute-force**
- Pattern chiave: invece di controllare ogni numero in un range enorme, generare direttamente solo i numeri "candidati" che potrebbero essere validi
- Uso dei divisori di una lunghezza totale per trovare tutte le possibili lunghezze di blocco ripetibile
- `string.Concat(Enumerable.Repeat(...))` per costruire stringhe ripetute
- `HashSet<T>` per deduplicare in modo efficiente (O(1) invece di O(n) di `List.Contains()`)

**Day 3 — Strategie greedy e tecnica dello stack**
- Scelta greedy: prendere sempre la scelta migliore localmente disponibile, rispettando un vincolo (posizioni rimanenti)
- Tecnica dello stack con "budget" per estrarre la sottosequenza ottima mantenendo l'ordine originale — pattern classico, riutilizzabile in altri problemi
- Riconoscere quando un algoritmo generale già gestisce un caso particolare, evitando di duplicare la logica

---

## Errori/bug ricorrenti (da tenere a mente)

- **Overflow di `int`** (Day 2): la somma di molti valori grandi può superare il limite di `int` (~2,1 miliardi) senza dare errore, "si rigira" silenziosamente — usare `long` in caso di dubbio, specialmente con somme cumulative o numeri a 8+ cifre
- **`IndexOf` con valori duplicati** (Day 3): cercare un elemento per *valore* non garantisce di trovare la posizione voluta (es. l'ultimo elemento) se ci sono duplicati — riferirsi a una posizione esplicita (`Count - 1`) quando serve
- **Dimenticare di aggiornare lo stato tra iterazioni** (Day 1 parte 2): la posizione non veniva aggiornata riga per riga, causando calcoli sempre dallo stesso punto di partenza

---

## Pratiche di codice da consolidare

- Struttura pulita: costruttore solo per inizializzare, metodo separato (`Run`/`ReadFile`) per eseguire la logica — evitare di mettere lavoro/effetti collaterali nel costruttore
- Rimuovere `using` inutili e codice morto (residui di tentativi) quando il lavoro è concluso
- Preferire operazioni numeriche dirette (`x * 10 + y`) invece di passare per stringhe quando non è necessario

---

## Andamento generale

Progresso reale in 3 giorni: dal brute-force del Day 1 parte 2, a tentativi diretti di approcci ottimizzati sul Day 2, fino a implementare autonomamente un algoritmo più sofisticato (stack a budget) sul Day 3 — capendone davvero il funzionamento, non solo replicandolo (dimostrato riconoscendo da solo la ridondanza del pre-filtro).

**Punti di attenzione per i prossimi giorni:**
- Controllare in anticipo (prima che diventi un bug) se serve `long` invece di `int`
- Provare a scrivere uno scheletro/pseudocodice proprio prima di chiedere un esempio in codice, per allenare il passaggio "concetto capito → concetto implementato da zero"
