import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ListaIngredientes from './Form/Ingredientes/ListaIngredientes';
import Home from './Home';
import SideMenu from './SideMenu/SideMenu';

const App = () => {
  return (
    <BrowserRouter>
      <SideMenu />

      {/* <Routes>
        <Route path="/" element={<Home title="0601 - Router" />} />
        <Route path="sobre" element={<ListaIngredientes />} />
      </Routes> */}
    </BrowserRouter>
  );
};

export default App;
