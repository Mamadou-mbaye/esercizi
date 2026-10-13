import { Sequelize } from "sequelize";

const DB_NAME = "provadue";
const DB_USER = "root";
const DB_PASSWORD = "R4ndomS3cure";
const DB_HOST = "localhost";
const sequelize = new Sequelize(DB_NAME, DB_USER, DB_PASSWORD, {
  dialect: "mysql",
  host: DB_HOST,
  port: 3306,
  timezone: "+02:00",
});

export const actors = sequelize.define("actors", {
  firstName: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  lastName: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  birthDate: {
    type: Sequelize.DATE,
    allowNull: false,
  },
  rolePlaying: {
    type: Sequelize.INTEGER,
    allowNull: false,
  },
});

export const connect = async () => {
  try {
    await sequelize.authenticate();
    await actors.sync();
    console.log("connection to the database has been established successfully");
  } catch (error) {
    console.log("connection to the database not established");
  }
};
