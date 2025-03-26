onmessage = (e) => {
  console.log('Worker: Message received from main script');
  const result = e.data[0] * e.data[1];

  if (isNaN(result)) {
    postMessage('Worker: Please write two numbers');
  } else {
    const workerResult = 'Resultado: ' + result;
    console.log('Worker: Posting result back to main script');
    postMessage(workerResult);
  }
};
