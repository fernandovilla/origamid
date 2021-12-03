import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { decrementar, incrementar } from './store/contador';
import { abrir, fechar } from './store/modal';


const App = () => {

  const contador = useSelector(state => state.contador);
  const modal = useSelector(state => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <h1>Total: {contador.total}</h1>      
      <button onClick={() => dispatch(incrementar())} >+</button>
      <button onClick={() => dispatch(decrementar())}>-</button>

      <h1>Modal: {modal ? 'Aberto' : 'Fechado'}</h1>
      <button onClick={() => dispatch(abrir())}>Abrir</button>
      <button onClick={() => dispatch(fechar())}>Fechar</button>
    </div>
  );
}

export default App;
