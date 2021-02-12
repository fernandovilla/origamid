function Exemplo1() {
  class Button {
    constructor(text, background) {
      this.text = text;
      this.background = background;
    }
    element() {
      const buttonElement = document.createElement("button");
      buttonElement.innerText = this.text;
      buttonElement.style.background = this.background;
      return buttonElement;
    }
    appendElementoTo(target) {
      const targetElement = document.querySelector(target);
      targetElement.appendChild(this.element());
    }
  }

  const blueButton = new Button("Comprar", "orange");
  blueButton.appendElementoTo("body");

  console.log(blueButton);
}

function Exemplo2() {
  class Button {
    constructor(options) {
      console.log("Criando botão");
      this.options = options;
    }
    static create(text, background) {
      const buttonElement = document.createElement("button");
      buttonElement.innerText = text;
      buttonElement.style.background = background;
      return buttonElement;
    }
  }

  // const blueButton = new Button({
  //   text: "Comprar",
  //   color: "white",
  //   backgroundColor: "blue",
  // });

  const blueButton = Button.create("Comprar", "blue");
  console.log(blueButton);
}

function Exemplo3() {
  class Button {
    constructor(text, background) {
      this.text = text;
      this.background = background;
    }
    element() {
      const buttonElement = document.createElement("button");
      buttonElement.innerText = this.text;
      buttonElement.style.background = this.background;
      return buttonElement;
    }
    appendElementoTo(target) {
      const targetElement = document.querySelector(target);
      targetElement.appendChild(this.element());
    }
    static CreateBlueButton(text) {
      return new Button(text, "blue");
    }
  }

  // const blueButton = new Button("Comprar", "orange");
  // blueButton.appendElementoTo("body");

  const blueButton = Button.CreateBlueButton("Ok");
  blueButton.appendElementoTo("body");

  console.log(blueButton);
}
Exemplo3();
