function exemplo1() {
  const button = {
    get tamanho() {
      return this._tamanho || 100; //se for 'undefined', retorna 100;
    },
    set tamanho(value) {
      this._tamanho = value;
    },
    get PI() {
      //read-only
      return 3.14;
    },
  };

  console.log(button.tamanho);
  button.tamanho = 20;
  console.log(button.tamanho);
}

function exemplo2() {
  const frutas = {
    lista: [],
    set addNewFruta(fruta) {
      this.lista.push(fruta);
    },
  };

  frutas.addNewFruta = "Banana";
  frutas.addNewFruta = "Morango";

  console.log(frutas.lista);
}

function exemplo3() {}
exemplo3();
