import { Router } from "express";
import { registerMessageController } from "../controllers/message.controller";
const router = Router();
router.post("/message/register", registerMessageController);
export { router };
