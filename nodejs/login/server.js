import express from "express";
const app = express();
const port = 3000;

import {router} from "./routes/user.router.js"



app.use(express.json());
app.use("/", router)

app.listen(port, () => {
  console.log(`Server listening on port ${port}`);
});
