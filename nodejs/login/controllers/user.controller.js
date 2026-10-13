import { Login } from "../services/user.service.js";

export const Logincontroller = (req, res) => {
  const username = req.body.username;
  const password = req.body.password;
  const isLogin = Login(username, password);
  if (isLogin === "invalid_password") {
    res.status(401).send({ message: `Invalide password` });
  } else if (isLogin === "user_not_found") {
    res.status(404).send({ message: "User not found" });
  } else {
    res.send({ message: `Welcome ${username}` });
  }
};
