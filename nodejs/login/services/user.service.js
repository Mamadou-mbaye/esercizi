const user = {
  username: "modu",
  email: "mo@",
  password: "secret",
};

export const Login = (username, password) => {
  console.log(username);
  console.log(password);
  if (username.trim() === user.username) {
    if (password.trim() === user.password) {
      return "success";
    } else {
      return "invalid_password";
    }
  } else {
    return "user_not_found";
  }
};
