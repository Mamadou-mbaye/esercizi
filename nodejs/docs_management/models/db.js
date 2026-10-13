import { Sequelize } from "sequelize";
const db_name = "document";
const db_user = "root";
const db_password = "R4ndomS3cure";
const sequelize = new Sequelize(db_name, db_user, db_password, {
  dialect: "mysql",
  host: "localhost",
  port: 3306,
});
export const Documents = sequelize.define("documents", {
  author: { type: Sequelize.STRING, allowNull: false },
  title: { type: Sequelize.STRING, allowNull: false },
  description: { type: Sequelize.STRING, allowNull: false },
});
export const connect = async () => {
  try {
    await sequelize.authenticate();
    console.log("Connection to the database has been established");
    await Documents.sync();
  } catch (error) {
    console.log("Connection to the database has failed");
  }
};
