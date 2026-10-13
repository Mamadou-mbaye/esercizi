const username = document.getElementById("username");
const password = document.querySelector("#password");
const loginBtn = document.querySelector("#login");
const myForm = document.querySelector("#form");

const utente = {
  username: "admin",
  password: "secret",
};
const autentication = async () => {
  let user = username.value.trim();
  let codice = password.value.trim();
  const data = { username: user, password: codice };

  if (user === utente.username && codice === utente.password) {
    localStorage.setItem("isLoggedIn", "true");
    window.location.href = "welcome.html";
  } else {
    if (user !== utente.username) {
      alert(`username non corretto: ${user}`);
    }
    if (codice !== utente.password) {
      alert(`password non corretto ${codice}`);
    }
    myForm.addEventListener("submit", (event) => {
      event.preventDefault();
    });
  }
};
loginBtn.addEventListener("click", autentication);
document.addEventListener("DOMContentLoaded",()=>{
  const isLoggedIn = localStorage.getItem("isLoggedIn");
  if(isLoggedIn)
    window.location.href = "welcome.html";
})