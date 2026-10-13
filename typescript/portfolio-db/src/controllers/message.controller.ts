import { Request, Response } from "express";
import { registerMessage } from "../services/mesage.service";
export const registerMessageController = async (
  req: Request,
  res: Response
) => {
  const referer = req.get("Referer");
  if (!referer) return res.send({ message: "Forbiden" });
  if (referer.startsWith("http//localhost:3001/portfolio")) return;
  const fullName: string = req.body.fullName;
  const email: string = req.body.email;
  const message: string = req.body.message;
  try {
    await registerMessage(fullName, email, message);
    res.status(201).send({ message: "Message registred" });
  } catch (error) {
    console.error(error);
    res.send("An error occurred");
  }
};
