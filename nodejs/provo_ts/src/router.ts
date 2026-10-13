import express, { Application, Request, Response } from "express";

export const getMessage = (req: Request, res: Response) => {
  res.send("Hello mondo");
};
