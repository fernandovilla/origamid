import React from 'react';

function reducer(state, action) {
  switch (action.type) {
    case 'REMOVER':
      return state.filter((i) => i !== action.value);
    case 'ADICIONAR':
      return [...state, action.value];
    default:
      return state;
  }
  return state;
}

const ReducerArray = () => {
  const [state, dispatch] = React.useReducer(reducer, ['uva', 'pêra', 'maçã']);

  function adicionar() {
    const f = document.getElementById('fruta').value;
    if (f.trim() !== '') dispatch({ type: 'ADICIONAR', value: f });
  }

  function remover() {
    const f = document.getElementById('fruta').value;
    if (f.trim() !== '') dispatch({ type: 'REMOVER', value: f });
  }

  return (
    <section
      style={{
        border: '1px solid green',
        borderRadius: '4px',
        margin: '10px 0',
        padding: '20px',
      }}
    >
      <p>Frutas: {JSON.stringify(state)}</p>
      <input type="text" id="fruta" />
      <p>
        <button onClick={adicionar}>Adicionar</button>
        <button onClick={remover}>Remover</button>
      </p>
    </section>
  );
};

export default ReducerArray;
