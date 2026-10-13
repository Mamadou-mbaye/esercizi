import express from "express";
import {
  createDocumentsController,
  getDocumentController,
  updateDocumentController,
  deleteDocumentController,
} from "../controllers/documents.controller.js";
const router = express.Router();
router.post("/create", createDocumentsController);
router.get("/get/:id", getDocumentController);
router.put("/update/:id", updateDocumentController);
router.delete("/delete/:id", deleteDocumentController);
export { router };
