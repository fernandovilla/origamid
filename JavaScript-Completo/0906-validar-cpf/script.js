import ValidacaoCPF from "./validar-cpf.js";

const cpf = document.querySelector("#cpf");
const validarCpf = new ValidacaoCPF(cpf);
//validarCpf.addEvent();

console.log(validarCpf.formatar("31365040895"));
