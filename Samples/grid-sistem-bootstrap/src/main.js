const first = document.getElementById('number1');
const second = document.getElementById('number2');
const result = document.getElementById('result');

if (window.Worker) {
  const myWorker = new Worker('/src/worker.js');

  first.onchange = () => {
    myWorker.postMessage([first.value, second.value]);
    console.log('Message posted to worker. #first');
  };

  second.onchange = () => {
    myWorker.postMessage([first.value, second.value]);
    console.log('Message posted to worker. #second');
  };

  myWorker.onmessage = (e) => {
    result.textContent = e.data;
    console.log('Message received from worker');
  };
} else {
  console.log("Your browser doesn't suport web workers");
}
