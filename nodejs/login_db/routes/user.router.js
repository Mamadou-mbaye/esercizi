import express from "express";
import {createUserController,getUserController} from '../controllers/user.controller.js'
const router = express.Router();
router.post('/create', createUserController);
router.get('/get/:id', getUserController);
export { router };
