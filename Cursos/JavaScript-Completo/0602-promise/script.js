//Exemplo 1
function initExemplo1() {
  const promessa = new Promise((resolve, reject) => {
    const condicao = true;

    if (condicao) {
      resolve({ message: 'Resolvido com sucesso!' });
    } else {
      reject(Error('Ocorreu um erro na promisse'));
    }
  });

  promessa.then((resultado) => {
    console.log(resultado.message); //valor retornado pelo método callback 'resolve()'
  });
}

//Exemplo 2
function initExemplo2() {
  const promessa = new Promise((resolve, reject) => {
    const condicao = true;

    if (condicao) {
      console.log('Resolvendo promisse');
      setTimeout(() => {
        resolve({ message: 'Resolvido com sucesso!' });
      }, 3 * 1000);
      console.log('Promisse resolvida');
    } else {
      reject(Error('Ocorreu um erro na promisse'));
    }
  });

  //then() ocorre quando a função callback resolve() é executada;
  //Podem ser aninhados quantos thens() forem necessários...
  promessa
    .then((resultado) => {
      console.log(resultado.message); //imprime 'Resolvido com sucesso!' -> valor retornado pelo método callback 'resolve()'
      return 'OK2';
    })
    .then((resultado) => {
      console.log(resultado); //imprime 'OK2'
      return 'OK3';
    })
    .then((resultado) => {
      console.log(resultado); //imprime 'OK3'
    })
    //catch() ocorre quando a função callback da promisse é executada...
    //O catch tb pode ser passado como segundo argumento do then()
    .catch((rejeitada) => {
      console.log('Rejeição: ' + rejeitada);
    })
    .finally(() => {
      console.log('>FIM');
    });
}

//Exemplo 3
function initExemplo3() {
  const login = new Promise((resolve) => {
    setTimeout(() => {
      resolve('Usuário logado');
    }, 1000);
  });

  const dados = new Promise((resolve) => {
    setTimeout(() => {
      resolve('Dados carregados');
    }, 900);
  });

  //lista todos os resultados das promises passadas como argumento
  const dadosCarregados = Promise.all([login, dados]);
  dadosCarregados.then((resultado) => {
    console.log(resultado);
  });

  //lista apenas o resultado da primeira promisse resolvida
  const dadosCarregados2 = Promise.race([login, dados]);
  dadosCarregados2.then((resultado) => {
    console.log(resultado);
  });
}
initExemplo3();
