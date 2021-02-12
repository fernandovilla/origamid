function initConteudoAula() {
  //"use strict";
  //Ice Factory: retornar um Object.freeze(), garantindo que o retorno do método permanecerá intácto;

  function createButton(text) {
    function element() {
      const buttonElement = document.createElement("button");
      buttonElement.innerText = text;
      return buttonElement;
    }

    return Object.freeze({
      text,
      element,
    });
  }

  const btnComprar = createButton("Comprar");
  btnComprar.text = "Voltar"; //Não acontece nada, porém se declarar 'use strict' no topo da página, ocorre erro ao tentar editar o valor

  const btnVender = createButton("Vender");

  console.log(btnComprar);
  console.log(btnVender);

  function Pessoa(nome) {
    //garante que sempre será criada uma instancia de Pessoa, mesmo que seja chamada sem o 'new'
    //if (!new.target)... -> também é uma maneira de garantir a mesma coisa
    if (!(this instanceof Pessoa)) {
      return new Pessoa(nome);
    }

    this.nome = nome;
  }

  const designer = Pessoa("Fernando Villa");
  console.log(designer);
}

function initExercicios() {
  function $$(selectedElements) {
    const elements = document.querySelectorAll(selectedElements);

    function hide() {
      elements.forEach((element) => {
        element.style.display = "none";
      });

      return this;
    }

    function show() {
      elements.forEach((element) => {
        element.style.display = "initial";
      });

      return this;
    }

    function on(event, callback) {
      elements.forEach((element) => {
        element.addEventListener(event, callback);
      });
      return this;
    }

    function addClass(className) {
      elements.forEach((element) => {
        element.classList.add(className);
      });
      return this;
    }

    function removeClass(className) {
      elements.forEach((element) => {
        element.classList.remove(className);
      });
      return this;
    }

    return {
      elements,
      hide,
      show,
      on,
      addClass,
      removeClass,
    };
  }

  const btns = $$("button");
  console.log(btns);

  btns.on("click", (event) => {
    alert("Hello! " + event.target.innerText);
  });
}
initExercicios();
