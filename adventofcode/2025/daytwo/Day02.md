# Day 2 — Gift Shop (2015)

**Contesto:** L'input è una singola riga con più range di ID separati da virgola (es. `11-22,95-115,...`), ogni range nel formato `inizio-fine`. Bisogna trovare, dentro ogni range, gli ID "invalidi" secondo una regola basata sul pattern delle cifre, e sommarli tutti.

## Parte 1
Un ID è invalido se è fatto da una sequenza di cifre ripetuta **esattamente due volte** (es. `446446` = `446`+`446`).

- Un numero può essere invalido solo se ha **lunghezza pari** (altrimenti non si divide a metà).
- Soluzione naive: per ogni numero nel range, dividere la stringa a metà e confrontare le due parti.
- Soluzione ottimizzata: invece di controllare ogni numero del range (lento su range enormi), si **generano direttamente i candidati**: per ogni lunghezza pari possibile, si scorrono tutti i blocchi `n` della metà lunghezza e si costruisce il candidato ripetendolo due volte (`n * 10^halfLen + n`), controllando solo se cade nel range.
- **Bug preso:** overflow di `int` nella somma finale — con range fino a 10 cifre la somma totale supera il limite di `int` (~2,1 miliardi). Serve `long` per `sumInvalidID`, `inizioRange`, `fineRange` e la variabile del ciclo.

## Parte 2
Regola generalizzata: un ID è invalido se è fatto da una sequenza di cifre ripetuta **almeno due volte** (non solo esattamente due) — es. `123123123` (`123` × 3), `1111111` (`1` × 7), `1212121212` (`12` × 5).

- Per un numero di lunghezza totale `L`, le lunghezze di blocco possibili (`blockLen`) sono tutti i **divisori di `L` minori di `L` stesso** (un blocco lungo quanto l'intero numero non conta come "ripetuto almeno due volte").
- Per ogni combinazione `totalLen` / `blockLen` valida (`totalLen % blockLen == 0`), si genera ogni possibile blocco di quella lunghezza (`minBlock` a `maxBlock`, stessa idea della parte 1), lo si ripete `totalLen / blockLen` volte per formare il candidato, e si controlla se cade nel range.
- **Attenzione ai duplicati:** uno stesso numero può essere generato da più combinazioni diverse (es. `111111` da blocco `1`×6, `11`×3, o `111`×2) — serve un insieme di ID unici prima di sommare, altrimenti lo stesso numero viene contato più volte.
- Soluzione: usare `HashSet<long>` invece di `List<long>` per raccogliere i candidati validi trovati — `HashSet` ignora automaticamente i duplicati e ha ricerca/inserimento molto più veloci di una `List` (utile se si volesse comunque controllare la presenza prima di aggiungere). La somma finale (`.Sum()`) si fa una sola volta, fuori da tutti i cicli, sull'insieme completo.

## Concetti chiave usati
- Divisori di un numero (lunghezza totale → possibili lunghezze di blocco)
- Generazione diretta dei candidati invece di scorrere un range enorme (pattern riusato dalla parte 1 del giorno)
- `string.Concat(Enumerable.Repeat(...))` per ripetere una stringa N volte
- `HashSet<T>` per deduplicare in modo efficiente, invece di `List<T>.Contains()` (O(1) vs O(n))
- Attenzione generale a overflow di `int` quando si sommano molti valori grandi — meglio partire da `long` in caso di dubbio
