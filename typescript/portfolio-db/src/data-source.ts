import "reflect-metadata";
import { DataSource } from "typeorm";
import { Portfolio } from "./entity/Message";
import * as dotenv from "dotenv";
dotenv.config();

const host: string = process.env.DB_HOST;
const user: string = process.env.DB_HOST_USER;
const name: string = process.env.DB_NAME;
const password: string = process.env.DB_PASSWORD;
const port: number = parseInt(process.env.DB_PORT);

export const AppDataSource = new DataSource({
  type: "mysql",
  host: host,
  port: port,
  username: user,
  password: password,
  database: name,
  synchronize: true,
  entities: [Portfolio],
});

export const connect = async () => {
  try {
    await AppDataSource.initialize();
    console.log("Connection to the database establised");
  } catch (error) {
    console.error(error);
    throw new Error("Connection to the database failed");
  }
};  