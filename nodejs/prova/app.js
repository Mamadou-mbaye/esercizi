import express from "express";
import { connect } from "./models/db.js";
import { router as actorsRouter } from "./routes/actors.router.js";
const app = express();
const port = 3000;
app.use(express.json());
app.use("/actor", actorsRouter);
app.listen(port, async () => {
  await connect();
  console.log(`Server is running on port ${port}`);
});
