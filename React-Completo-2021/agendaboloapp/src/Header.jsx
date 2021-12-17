import React from 'react';
import { NavLink } from 'react-router-dom';
import './Header.css';

const menuItens = [
  { display: 'Home', to: '/' },
  { display: 'Sobre', to: 'sobre' },
  { display: 'Contato', to: 'contato' },
  { display: 'Produtos', to: 'produtos' },
  { display: 'Login', to: 'login' },
  { display: 'ProdutosTable', to: 'produtosTable' },
];

const Header = ({ text }) => {
  return (
    <header style={{ backgroundColor: '#eee' }}>
      <h1>{text}</h1>
      <nav>
        {menuItens.map((item, index) => (
          <li
            key={index}
            style={{
              listStyle: 'none',
              display: 'inline-block',
              margin: '0 5px',
            }}
          >
            <NavLink to={item.to} end={index === 0}>
              {item.display}
            </NavLink>
            {index < menuItens.length - 1 && ' | '}
          </li>
        ))}
      </nav>
    </header>
  );
};

export default Header;
