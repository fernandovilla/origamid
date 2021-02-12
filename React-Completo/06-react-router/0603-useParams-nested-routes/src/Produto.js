import React from 'react';
import {
  NavLink,
  Outlet,
  Route,
  Routes,
  useLocation,
  useParams,
} from 'react-router-dom';
import ProdutoAvaliacao from './ProdutoAvaliacao';
import ProdutoCustomizaco from './ProdutoCustomizaco';
import ProdutoDescricao from './ProdutoDescricao';

const Produto = () => {
  const params = useParams();
  const location = useLocation();
  const search = new URLSearchParams(location.search);

  // usado para captar os demais parâmetros passados na URL, ex: ?nome=dell&cor=verde&memoria=16GB
  //search.get('nome_param');

  return (
    <div>
      <h1>Produto</h1>
      <p>Produto: {params.id}</p>
      <nav>
        <NavLink to="">Descrição</NavLink> |{' '}
        <NavLink to="avaliacao">Avaliação</NavLink> |{' '}
        <NavLink to="customizado">Customizado</NavLink>
      </nav>
      {/* Aqui é onde as rotas anihadas serão apresentadas */}
      <div
        style={{
          width: '600px',
          height: '300px',
          background: '#eee',
          border: '2px solid gray',
          borderRadius: '8px',
          margin: '10px 0px',
          padding: '0px 20px',
        }}
      >
        <Outlet />
      </div>

      {/* 
      É possível criar as rotas aqui ou em App.js
      <Routes>
        <Route path="/" element={<ProdutoDescricao />} />
        <Route path="avaliacao" element={<ProdutoAvaliacao />} />
        <Route path="customizado" element={<ProdutoCustomizaco />} />
      </Routes> */}
    </div>
  );
};

export default Produto;
