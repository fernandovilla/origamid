import React from 'react';
import { useSelector, useDispatch } from 'react-redux';

const App = () => {

  const state = useSelector((state) => state);

  const dispatch = useDispatch();

  const incrementar = () => dispatch({ type:  'INCREMENTAR'});

  const decrementar = () => dispatch({ type: 'DECREMENTAR'});

  return (
    <div>
      <h1>Total: {state}</h1>
      <button onClick={incrementar}>+</button>
      <button onClick={decrementar}>-</button>
    </div>
  );
}

export default App;
