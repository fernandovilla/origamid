function sample1() {
  debugger; //breakpoint

  let item1 = "1";

  function funcao1() {
    let item2 = "2";

    function funcao2() {
      let item3 = "3";

      console.log(item1);
      console.log(item2);
      console.log(item3);
    }
    funcao2();
  }
  funcao1();
}

function sample2() {
  debugger;
  function contagem() {
    let total = 0;
    return function incremento() {
      total++;
      console.log(total);
    };
  }

  const ativarContagem = contagem();
  ativarContagem();
  ativarContagem();
  ativarContagem();
  ativarContagem();
  ativarContagem();
}
sample2();
