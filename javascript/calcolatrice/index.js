const output = document.getElementById("display-result");
const operazioneInput = (input) => {
  output.value += input;
};
const cancella = document.getElementById("cancella");
cancella.addEventListener("click", () => {
  output.value = "";
});
const calcolare = () => {
  try {
    const result = new Function("return " + output.value)();
    output.value = result;
  } catch (error) {
    output.value = "error";
  }
};
