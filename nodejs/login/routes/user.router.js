import express from "express"
const router = express.Router()

import {Logincontroller} from '../controllers/user.controller.js'

router.post("/get", Logincontroller);


export {router}