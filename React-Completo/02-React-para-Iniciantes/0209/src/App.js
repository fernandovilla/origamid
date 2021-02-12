import React from 'react';

/* 
  Eventos disponívels no React
  https://reactjs.org/docs/events.html
*/

function handleClick(event) {
  console.log(event);
}

function handleScroll(event) {
  console.log(event);
}
window.addEventListener('scroll', handleScroll);

const App = () => {
  return (
    <section style={{ height: '1000px' }}>
      <button id="btnBotao" onClick={handleClick}>
        Botão
      </button>
      <button id="btnOutroBotao" onClick={(event) => alert(event.target)}>
        Outro botão
      </button>
    </section>
  );
};

export default App;
