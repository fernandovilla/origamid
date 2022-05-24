import React from 'react';

function reducer(state, action) {
  switch (action) {
    case 'AUMENTAR':
      return state + 1;
    case 'REDUZIR':
      return state - 1;
    default:
      return state;
    //throw new Error('action inválida');
  }
}

const Contador = () => {
  // const [contar, setContar] = React.useState(0);
  const [state, dispatch] = React.useReducer(reducer, 0);

  // function adicionar() {
  //   setContar(contar + 1);
  // }

  // function subtrair() {
  //   setContar(contar - 1);
  // }

  return (
    <div
      style={{
        border: '1px solid gray',
        borderRadius: '4px',
        padding: '20px',
      }}
    >
      {/* 
      <p>{contar}</p>
      <button onClick={adicionar}>+</button>
      <button onClick={subtrair}>-</button> 
      */}
      <p>{state}</p>
      <button onClick={() => dispatch('AUMENTAR')}>+</button>
      <button onClick={() => dispatch('REDUZIR')}>-</button>
      <button onClick={() => dispatch('X')}>X</button>
    </div>
  );
};

export default Contador;
