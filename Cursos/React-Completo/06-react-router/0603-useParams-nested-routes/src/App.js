import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './Header';
import Home from './Home';
import Login from './Login';
import PageNotFound from './PageNotFound';
import Produto from './Produto';
import Sobre from './Sobre';
import ProdutoAvaliacao from './ProdutoAvaliacao';
import ProdutoCustomizaco from './ProdutoCustomizaco';
import ProdutoDescricao from './ProdutoDescricao';

function CreateRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Home />} /*Home.js*/ />
      <Route path="sobre" element={<Sobre />} /*Sobre.js*/ />
      <Route path="login" element={<Login />} /*Login.js*/ />
      <Route
        path="produto/:id"
        element={
          <Produto />
        } /** produto/id/... assim não é necessário o '/*' depois '/:id' **/
      >
        <Route path="/" element={<ProdutoDescricao />} />
        <Route path="avaliacao" element={<ProdutoAvaliacao />} />
        <Route path="customizado" element={<ProdutoCustomizaco />} />
      </Route>
      <Route
        path="*"
        element={<PageNotFound />} /*quaquer página não encontrada */
      />
    </Routes>
  );
}

const App = () => {
  return (
    <BrowserRouter>
      <Header />
      <CreateRoutes />
    </BrowserRouter>
  );
};

export default App;
