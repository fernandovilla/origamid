import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './Header';
import Home from './Home';
import PageNotFound from './PageNotFound';
import Sobre from './Sobre';

const App = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} /*home*/ />
        <Route path="sobre" element={<Sobre />} /*sobre*/ />
        <Route
          path="*"
          element={<PageNotFound />} /*quaquer página não encontrada */
        />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
