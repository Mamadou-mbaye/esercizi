/* come evento appesta il caricamento del documento per lanciare la funzione*/
document.addEventListener("DOMContentLoaded", function () {
  /*isLoggedIn é salvato quando quando facciamo login in index.html diventa falso quando facciamo logout perche è stato usato removeItem*/
  const isLoggedIn = localStorage.getItem("isLoggedIn");

  if (!isLoggedIn) {
    window.location.href = "index.html"; // Reindirizza alla pagina di login se l'utente non è loggato
  }

  const logoutBtn = document.querySelector("#logout");
  logoutBtn.addEventListener("click", function () {
    localStorage.removeItem("isLoggedIn");
    window.location.href = "index.html"; // Reindirizza alla pagina di login dopo il logout
  });
});
