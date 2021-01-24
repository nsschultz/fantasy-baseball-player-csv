## Player CSV Service
* This is the source of truth for player data.
* The data is stored in a single CSV file.
* Once the updates can be done from the UI, this service will become export only.

---
### Endpoints:
* `GET api/player` - Gets all of the players from the CSV file.
* `POST api/player` - Overwrites the CSV with the collection of players provided.

---
### Healthcheck:
* The service will fail a healthcheck if any of the CSV file is not accessible. 