import { User } from "../models/user.model.js";

export const createUser = (username, password) => {
  return User.create({ username, password });
};
export const getUser =(id)=>{
  return User.findByPk(id);
}