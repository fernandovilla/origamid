function samplePost() {
  const url = 'https://jsonplaceholder.typicode.com/posts';
  const options = {
    method: 'POST',
    body: '{ "title": "JavaScript", "time": "2h15m"}',
    headers: {
      'Content-Type': 'application/json charset=utf-8',
    },
  };

  fetch(url, options)
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
    });
}
//samplePost();

function samplePut() {
  const url = 'https://jsonplaceholder.typicode.com/posts/2';
  const options = {
    method: 'PUT',
    body: '{ "title": "CSS+HTML", "time": "3h30m"}',
    headers: {
      'Content-Type': 'application/json charset=utf-8',
    },
  };

  fetch(url, options)
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
    });
}
//samplePut();

function sampleHead() {
  const url = 'https://jsonplaceholder.typicode.com/posts/2';
  const options = {
    method: 'HEAD',
  };

  fetch(url, options).then((response) => {
    console.log(response.headers.get('Content-Type'));
    response.headers.forEach((i) => console.log(i));
  });
}
sampleHead();
