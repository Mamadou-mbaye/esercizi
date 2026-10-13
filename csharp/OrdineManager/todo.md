# Progetto: Sistema di Gestione Ordini

**Il cliente vuole una console app C# che:**
Permetta di creare un ordine (`cliente`, `prezzo unitario`, `quantità`)
Applichi uno `sconto del 10%` sugli ordini superiori a 100€
Mostri tutti gli ordini salvati con il totale
Usi liste in memoria — niente database per ora

## Vincoli architetturali che il cliente ha specificato:

- Il codice deve essere organizzato in 3 layer separati ( Business → DataAccess → Models)
- Il Program.cs non deve contenere logica di business né SQL
- Deve essere possibile sostituire lo storage (oggi lista, domani database) senza toccare la logica di business



