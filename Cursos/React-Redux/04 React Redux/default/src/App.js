import React from 'react';
import { useSelector, useDispatch } from 'react-redux';

const App = () => {

  const state = useSelector((state) => state);

  const dispatch = useDispatch();

  

  return (
    <div>
      <h1>Ract Redux</h1>      
    </div>
  );
}

export default App;
