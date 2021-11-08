import React from 'react';

const handlerScroll = () => {
  console.log('Scrolling...');
};

const App = () => {
  window.addEventListener('scroll', handlerScroll);

  return (
    <div style={{ height: '200vh' }}>
      <button onClick={(event) => alert(event.target.innerText)}>Click</button>
    </div>
  );
};

export default App;
