export default class ValidacaoCPF {
  constructor(element) {
    this.element = element;
    this.initializeClass();
  }

  limpar(cpf) {
    return cpf.replace(/\D/g, "");
  }

  construir(cpf) {
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "$1.$2.$3-$4");
  }

  formatar(cpf) {
    const cpfLimpo = this.limpar(cpf);
    return this.construir(cpfLimpo);
  }

  validarOnChange(cpfElement) {
    if (this.validarCpf(cpfElement.value)) {
      cpfElement.value = this.formatar(cpfElement.value);
      cpfElement.classList.add("valido");
      cpfElement.classList.remove("erro");
      cpfElement.nextElementSibling.classList.remove("ativo"); //span
    } else {
      cpfElement.classList.remove("valido");
      cpfElement.classList.add("erro");
      cpfElement.nextElementSibling.classList.add("ativo"); //span
    }

    console.log(this.validarCpf(cpfElement.value));
  }

  addSpanError() {
    const errorElement = document.createElement("span");
    errorElement.classList.add("error-text");
    errorElement.innerText = "CPF inválido!";
    this.element.parentElement.insertBefore(
      errorElement,
      this.element.nextElementSibling,
    );
    //parentElement = form
    //nextElementSibling = email
  }

  validarCpf(cpf) {
    const matchCpf = cpf.match(/(?:\d{3}[-.\s]?){3}(?:\d{2})/g);
    return matchCpf && matchCpf[0] == cpf;
  }

  addEvent() {
    this.element.addEventListener("change", () => {
      this.validarOnChange(this.element);
    });
  }

  initializeClass() {
    this.addEvent();
    this.addSpanError();
  }
}
