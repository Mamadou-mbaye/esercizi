import express from "express";
import {
  createActorController,
  getActorController,
  updateActorController,
  deleteActorController,
} from "../controllers/actor.controller.js";

const router = express.Router();

router.post("/create", createActorController);
router.get("/get/:id", getActorController);
router.patch("/update/:id", updateActorController);
router.delete("/delete/:id", deleteActorController);
export { router };
