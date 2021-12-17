import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import ListaIngredientes from './Form/Ingredientes/ListaIngredientes';
import Home from './Home';

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home title="0601 - Router" />} />
        <Route path="sobre" element={<ListaIngredientes />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
