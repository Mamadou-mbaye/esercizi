import { Sequelize } from "sequelize";

const DB_NAME = "js_login";
const DB_USER = "root";
const DB_PASSWORD = "R4ndomS3cure";
const DB_HOST = "localhost";
const sequelize = new Sequelize(DB_NAME, DB_USER, DB_PASSWORD, {
  dialect: "mysql",
  host: DB_HOST,
  port: 3306,
  timezone: "+02:00",
});

export const User =  sequelize.define('user', {
  username: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  password: {
    type: Sequelize.STRING,
    allowNull: false,
  },
});

export const connect = async ()=>{
    try{
        await sequelize.authenticate();
        console.log('Connection to the database has been established successfully.');
        await User.sync();
        }catch(error){
            console.error('Unable to connect to the database:', error);
        }
    
}