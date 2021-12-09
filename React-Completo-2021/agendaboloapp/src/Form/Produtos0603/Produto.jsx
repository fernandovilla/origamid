import React from 'react';
import {
  Routes,
  useNavigate,
  useParams,
  Route,
  NavLink,
} from 'react-router-dom';
import ProdutoDescricao from './ProdutoDescricao';
import ProdutoAvaliacao from './ProdutoAvaliacao';
import ProdutoCustomizaco from './ProdutoCustomizado';

const Produto = () => {
  const params = useParams();
  const navigate = useNavigate();

  const handleClick = () => {
    navigate('/produtos');
  };

  return (
    <div>
      <h2>Produto: {params.id}</h2>
      <nav>
        <NavLink to="" end>
          Descrição
        </NavLink>
        {' | '}
        <NavLink to="avaliacao">Avaliação</NavLink>
        {' | '}
        <NavLink to="customizado">Customizado</NavLink>
      </nav>

      <section>
        <p>Detalhes:</p>
        <Routes>
          <Route path="/" elemement={<ProdutoDescricao />} />
          <Route path="avaliacao" elemement={<ProdutoAvaliacao />} />
          <Route path="customizado" elemement={<ProdutoCustomizaco />} />
        </Routes>
      </section>

      <button onClick={handleClick}>Voltar</button>
    </div>
  );
};

export default Produto;
