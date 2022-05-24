// https://makeup-api.herokuapp.com/
// https://jsonplaceholder.typicode.com/

const url = 'https://jsonplaceholder.typicode.com/todos';

// console.log('Fetching...');
// fetch(url)
//   .then((response) => {
//     return response.json();
//   })
//   .then((json) => {
//     console.log(json);
//   });

async function fetchItemsAsync(url) {
  const response = await fetch(url);
  const produtos = await response.json();

  console.log(produtos);
}

const produtos = fetchItemsAsync(url);
