const express = require("express");
const path = require("path");

const replicaApp = process.env.APP_NAME

const app = express();
const port = 3000;
app.use(express.static(path.join(__dirname, "public")));
app.use("/", (req, res) => {
  res.sendFile(path.join(__dirname, "index.html"));
  console.log(`Request received at ${new Date().toISOString()} for ${req.url} on ${replicaApp}`);
});

app.listen(port, () => {
    console.log(`${replicaApp} is running on http://localhost:${port}`);
}); 