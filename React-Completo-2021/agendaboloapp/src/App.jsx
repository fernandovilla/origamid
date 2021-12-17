import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './Header';
import Home from './Home';
import NotFound from './NotFound';
import Sobre from './Sobre';
import Footer from './Footer';
import Contato from './Contato';
import Login from './Login';
import Produto from './Form/Produtos0603/Produto';
import Produtos from './Form/Produtos0603/Produtos';
import ProdutosTable from './ProdutosTable';

/****************************************************************************
  BrouseRouter: componente pai que envolve tudo que depende do react-router
  Routes: define a área em que vamor colocar os nossos 'Route';
  Route: recebe um caminha em 'path' que será rendereizado no 'Routes';
****************************************************************************/

const App = () => {
  return (
    <BrowserRouter>
      <Header text="Nome do Site" />

      <Routes>
        <Route path="/" element={<Home title="0601 - Router" />} />
        <Route path="sobre" element={<Sobre />} />
        <Route path="contato" element={<Contato />} />
        <Route path="login" element={<Login />} />
        <Route path="produtos" element={<Produtos />} />
        {/*<Route path="produtos/:id" element={<Produto />} />*/}
        <Route path="produtos/:id/*" element={<Produto />} />
        <Route path="produtosTable" element={<ProdutosTable />} />
        <Route path="*" element={<NotFound />} />
      </Routes>

      <Footer text="Footer da Página" />
    </BrowserRouter>
  );
};

export default App;
