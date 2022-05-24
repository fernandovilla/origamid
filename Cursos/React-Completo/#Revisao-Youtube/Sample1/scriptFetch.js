const url = 'https://jsonplaceholder.typicode.com/todos';

// Get method *****************************************************************
function exemplo1(url) {
  fetch(url)
    .then((response) => {
      return response.json();
    })
    .then((jsonBody) => {
      console.log(jsonBody);
    });
}

// Post/Put method ************************************************************
function exemplo2(url) {
  const produto = {
    id: 1,
    nome: 'produto teste',
    preco: 2.5,
  };

  const postArgs = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(produto),
  };
  fetch(url, postArgs).then((response) => {
    console.log(response);
  });
}

// Async/Await ****************************************************************
function exemplo3(url) {
  async function fetchItensAsync(url) {
    const response = await fetch(url);
    const jsonBody = await response.json();
    return jsonBody;
  }

  const itens = fetchItensAsync(url).then((r) => {
    console.log(r);
  });
}
