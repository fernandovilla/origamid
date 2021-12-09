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

/****************************************************************************
  BrouseRouter: componente pai que envolve tudo que depende do react-router
  Routes: define a área em que vamor colocar os nossos 'Route';
  Route: recebe um caminha em 'path' que será rendereizado no 'Routes';
****************************************************************************/

const App = () => {
  return (
    <BrowserRouter>
      <Header text="Nome do Site" />

      {/* <header style={{ backgroundColor: '#eee' }}>

        <Titulo texto="Header da Página" />
        <hr style={{ border: '1px solid green', marginTop: '0' }} />
      </header> */}

      <Routes>
        <Route path="/" element={<Home title="0601 - Router" />} />
        <Route path="sobre" element={<Sobre />} />
        <Route path="contato" element={<Contato />} />
        <Route path="login" element={<Login />} />
        <Route path="produtos" element={<Produtos />} />
        <Route path="produtos/:id" element={<Produto />} />
        <Route path="*" element={<NotFound />} />
      </Routes>

      {/* <footer style={{ backgroundColor: '#eee' }}>
        <hr style={{ border: '1px solid green', marginBottom: '0' }} />
        <Titulo texto="Footer da Página" />
      </footer> */}

      <Footer text="Footer da Página" />
    </BrowserRouter>
  );
};

export default App;
