# Progetto: Sistema di Gestione Ordini API


Il cliente vuole espandere il Sistema di Gestione Ordini del Blocco 01 trasformandolo in una ASP.NET Core Web API.

## Requisiti:

- POST /ordini — crea e salva un ordine
- GET /ordini — restituisce tutti gli ordini

Stessa logica di business del Blocco 01 (sconto 10% sopra 100€)
I servizi devono essere registrati nel container DI con il lifetime corretto
Program.cs non deve contenere logica di business

Il layer DataAccess rimane in memoria — niente database ancora.
Non ti dico come strutturarlo. Quando hai finito incolla il codice.
