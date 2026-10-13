import {createUser,getUser} from '../services/user.service.js'

export const createUserController = async (req, res) => {
  const { username, password } = req.body;
  const user = await createUser(username, password);
  res.send({ message: "User created successfully}", user });
};
export const getUserController = async (req, res) => {
  const id = req.params.id;
  const user = await getUser(Number(id));
  res.send({ message: "User retrieved successfully", user });
};