class Veiculo {
  constructor(rodas) {
    this.rodas = rodas;
  }
  acelerar() {
    console.log("Acelerou");
  }
}

class Moto extends Veiculo {
  constructor(capacete) {
    super(2); //super => base
    this.capacete = capacete;
  }
  empinar() {
    console.log("Moto empinou com " + this.rodas + " rodas");
  }
  acelerar() {
    super.acelerar() + console.log(" nervoso!!!");
  }
}

const honda = new Moto(true);
honda.acelerar();
honda.empinar();
console.log("Capacete: " + honda.capacete);

const civic = new Veiculo(4);
civic.acelerar();
