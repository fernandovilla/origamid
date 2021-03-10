// Função que retorna um array dos 'innerText' a partir de uma lista de elementos;
function getElementsInnerText([...elements]) {
  return elements.map((element) => element.innerText);
}

//Função que remove caracteres não numéricos do CPF
const limparCPF = (cpf) => {
  return cpf.replace(/\D/g, ''); //\D é tudo que não é digito
};

//Função que formata o CPF
const construirCPF = (cpfLimpo) => {
  const regexp = /(\d{3})(\d{3})(\d{3})(\d{2})/g;
  return cpfLimpo.replace(regexp, '$1.$2.$3-$4');
};

//Função que limpa e formata a lista de CPFs
const formatarCPFs = (cpfs) => {
  return cpfs.map(limparCPF).map(construirCPF);
};

//Função para trocar o innerText dos elementos com os CPFs já formatados
function tratarCPFS(cpfElements) {
  const cpfs = getElementsInnerText(cpfElements);
  const cpfsFormatados = formatarCPFs(cpfs);
  cpfElements.forEach((element, index) => {
    element.innerText = cpfsFormatados[index];
  });
}

const listaCpfsElements = document.querySelectorAll('.cpf li');
tratarCPFS(listaCpfsElements);
