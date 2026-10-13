import express from "express";
const app = express();
const port = 3000;
import { connect } from "./models/db.js";
import { router as DocumentsRouter } from "./routes/documents.router.js";
app.use(express.json());
app.use("/documents", DocumentsRouter);
app.listen(port, async () => {
  await connect();
  console.log(`Server is running on port ${port}`);
});
