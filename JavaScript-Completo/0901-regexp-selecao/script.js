/*
   https://regexr.com/
   https://unicode-table.com/pt/#cyrillic-supplement
   https://pt.wikipedia.org/wiki/Lobo
   
   Flags:
   g - global: seleciona todas as ocorrências
   i - case insensitive: ignoca o case
   m - multiline

   Outros:
      [..] - busca individualmente por cada caracter informado no colchetes;
         ex: /./ -> busca toda a string
            /[.]/ -> busca todos os pontos
            /\./ -> busca todos os pontos
      [a-z] - seleciona todos os caracteres minusculos da tabela unicode;
      [^...] - negativa. desconsidera o que foi informado após o '^';
      . - ponto - seleciona qq caracter, menos quebra de linha;
      \w é a mesma coisa que [a-zA-Z0-9_] - seleciona todos os caracteres alfanuméricos e underline;
      \W é a mesma coisa que [^a-zA-Z0-9_] - seleciona todos os carecteres não alfanumpericos ou underline;
      \d - seleciona tudo que é digito;
      \D - seleciona tudo o que não é digito;
      \s - seleciona todos os espaços, tabs ou quebras de linha;
      \S - seleciona todo que não é espaço, tab ou quebra de linha;
      [\S\s] - seleciona tudo!
      ? - quando um caractere ou mais são opcionais, 
         Exemlpo: /regexp?/g => seleciona 'regexp' ou' regex', torna o 'p' opcional;
         Exemplo: /rege[xp]?/g -> seleciona 'regexp', 'regex', 'regep' ou 'rege', torna o 'x' e 'p' opcionais;
      | - seleciona um ou outro, exemplo: /brasil|argentina|chile/ => brasil ou argentina ou chile;
      \b - world boundary - indica que a seleção terá inicio e fim de não caracteres
         Exemplo: /\bpropor\b/g -> vai selecionar a palavra 'propor' isolada, 'proposito' não selecionaria
      \B - not world boundary é o contrário do \b
      ^ - Anchor Beginning - indica que a busca será do início para o fim:
         Exemplo: /^\w+/g - seleciona tudo que for alfanumérico no início da linha (left to right)
      $ - Anchor End - indica que a busca será do fim para o início:
         Exemplo: /\d+$/g - seleciona tudo que for numérico no final da linha (right to left)
      /\d+$/gm -> seleciona todas as linhas que terminam com caracteres numéricos;
      /^\d+/gm -> seleciona todas as linhas que começam com caracteres numéricos;
      /\n/gm -> seleciona todas a quebras de linha;
      \uXXXX -> seleciona unicode, onde XXXX é o código do caracter:
         Exemplo: /\u0040|\u00A9/g -> seleciona @ e ©;
      
   Quantificadores:
      char{N} => /i{3}/ - seleciona quando houver 'iii';
      char{N,} => /i{2,}/ - seleciona a partir de dois 'iiii....';
      char{N,X} => /i{2,4}/ - seleciona a partir de dois 'i' e menos que 4 'i';
         Exemplo: \w{2,} => seleciona tudo que é alfanumérico com mais de 2 letras;
      char+ => /i+/ => seleciona onde houver um ou mais 'i';
         Exemplo: /\d+/ - vai selecionar toda a sequência de números e não um por um;
         
   Substituição:
      $& - faz referencia a busca
      $N onde N é um número, faz referência a um grupo de captura => expressão entre ();
         Exemplo: /(\w+)@([\w.]+)/g -> na substituição $1 = (\w+) e $2 = ([\w.]+)
                  No texto 'fermvilla@gmail.com', a regex selecionaria todo o texto;
                  $1 seleciona 'fermvilla' e $2 seleciona 'gmail.com'
      (?:) - utiliza o parenteses para alguma separação mas ignora-o como grupo de captura;
      (?=) - positive lockedahead - não cria grupo de captura - seleciona o que há a frente do padrão:
         Exemplo: 
            Regex: '/\d(?=px)/g' => seleciona todos os dígitos com 'px' a frente;
            Texto: (2em, 1px, 2px, 5%, 3rem, 8pc);
            Resultado: 1 e 2
            Replace por 100: (2em, 100px, 100px, 5%, 3rem, 8pc);
      (?!) - negative lockedahead - contrário (?=)
         Exemplo:
            Regex: '/\d(?!px)/g' => seleciona todos os dígitos que não é 'px' na frente;
            Texto: (2em, 1px, 2px, 5%, 3rem, 8pc);
            Resultado: 2, 5, 3 e 8
            Replace por 100: (100em, 1px, 2px, 100%, 100rem, 100pc);
               
   Padrôes:
      CEP: /\d{5}[\s-]?\d{3}/g => '00000-000', '00000 000', '00000000'


 */

function sample1() {
  const frase = "JavaScript";
  console.log(frase);

  const novaFrase = frase.replace(/a/g, "_"); //g significa que vai selecionar todas as ocorrências de 'a'
  console.log(novaFrase);
  const cpf = "313.650.408-95";
  const regexCPF = /[.-]/g;
  const cpfFormatado = cpf.replace(regexCPF, "");
  console.log(cpfFormatado);
}

function validarCEP() {
  const cepRegex = /\d{5}[\s-]?\d{3}/g;
  const ceps = ["13612-030", "13610 210", "13610000"];
  ceps.forEach((cep) => {
    console.log(cep, cep.match(cepRegex));
  });
}

function validarCPF() {
  //const cpfRegex = /(\d{2,3})[\s\.]?(\d{3})[\s\.]?(\d{3})[\s-]?(\d{2})/g;
  const cpfRegex = /(?:\d{3}[\.\s-]?){3}\d{2}/g;
  const cpfs = [
    "313.650.408-95",
    "000000000-11",
    "00000000000",
    "000 000 000 00",
    "000-000-000-00",
    "000-000.000.00",
    "000.000.000.00",
  ];
  cpfs.forEach((cpf) => {
    console.log(cpf, cpf.match(cpfRegex));
  });
}

function validarCNPJ() {
  const regex = /\d{2}[-.\s]?(?:\d{3}[-.\s]?){2}[/\s]?\d{4}[-.\s]?\d{2}/g;
  const cnpjs = [
    "00.000.000/0000-00",
    "00 000 000 0000 00",
    "00-000-000-0000-00",
    "00000000000000",
    "00.000.000.0000-00",
  ];
  cnpjs.forEach((cnpj) => {
    console.log(cnpj, cnpj.match(regex));
  });
}

function validarTelefone() {
  const regex = /(?:\+?55\s?)?(?:[\(]?\d{2}[\)]?[\s-]?)?\d{4,5}[-\s]?\d{4}/g;
  const telefones = [
    "+55(11)98888-1234",
    "+55 (11) 98888-1234",
    "+55 11 98888-1234",
    "+55 11 98888 1234",
    "+5511988881234",
    "(11) 98888-1234",
    "(11)98888-1234",
    "11 98888 1234",
    "11988881234",
  ];

  telefones.forEach((fone) => {
    console.log(fone, fone.match(regex));
  });
}

function validarEmail() {
  const regex = /[\w.-]+@[\w-]+\.[\w.-]+/gi;
  const emails = [
    "email@email.com",
    "email@email.com.org",
    "email-email@email.com",
    "email_email@email.com",
    "email.email@email.com",
    "email123@email.com.br",
    "email.email123@sua-empresa.com.br",
    "c@email.cc",
  ];

  emails.forEach((email) => {
    console.log(email, email.match(regex));
  });
}

function validarTags() {
  const regex = /<\/?[\w\s='".]+\/?>/gi;
  const tags = [
    "<div>blablabla</div>",
    '<div class="ativo">blablabla</div>',
    "<div class='ativo'>blablabla</div>",
    '<img src="imagem.jpg">',
    "<img src='imagem.jpg' />",
  ];

  tags.forEach((tag) => {
    console.log(tag, tag.match(regex));
  });
}

function validarTagsSomenteNome() {
  //const regex = /(?<=<\/?)[\w]+/gi; //(?<=) positive lockedbehind
  const regex = new RegExp(/(?<=<\/?)[\w]+/, "gi");

  const tags = [
    "<div>blablabla</div>",
    '<div class="ativo">blablabla</div>',
    "<div class='ativo'>blablabla</div>",
    '<img src="imagem.jpg">',
    "<img src='imagem.jpg' />",
    "<ul></ul>",
  ];

  tags.forEach((tag) => {
    console.log(tag, tag.match(regex));
  });
}

function objetoRegExp() {
  const frase = "JavaScript, TypeScript, CoffeeScript, NodeJS, VBScript";
  const regexp = new RegExp(/SCRIPT/, "gi"); //retorna todas as posições onde encontrou 'SCRIPT';
  //const regexp = new RegExp(/\w+/, "gi");   //retorna todas as palavras encontradas, separando por caracter não alfanumérico: ', ';

  let value;
  while ((value = regexp.exec(frase)) !== null) {
    console.log(value.index, value[0]);
  }
}

function replaceRegexp() {
  const html = `
<ul>
  <li>Item #1</li>
  <li>Item #2</li>
</ul>`;

  const regexp = /ul/g;
  const htmlReplaced = html.replace(regexp, "div");

  console.log(htmlReplaced);
}
replaceRegexp();
