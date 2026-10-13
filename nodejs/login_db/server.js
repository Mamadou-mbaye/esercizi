import express from "express";
import path from "path";
import { connect } from "./models/user.model.js";
import { router as UserRouter } from "./routes/user.router.js";

import { fileURLToPath } from "url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express();
const port = 8080;
app.use(express.json());
app.use("/user", UserRouter);
app.get("/", (req, res) => {
  res.sendFile(path.join(__dirname, "/public/index.html"));
});
app.get("/create", (req, res) => {
  res.sendFile(path.join(__dirname, "/public/create-user.html"));
});

app.listen(port, async () => {
  await connect();
  console.log(`Server is running on port ${port}`);
});
