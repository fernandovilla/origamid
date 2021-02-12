import React from 'react';
import './Header.css';
import { NavLink } from 'react-router-dom';

const Header = () => {
  return (
    <nav>
      {/* Se não quiser usar a estilização do .active no css, usar o 'activeStyle' direto no componente abaixo */}
      <NavLink to="/" end>
        Home
      </NavLink>{' '}
      |{' '}
      <NavLink
        to="sobre"
        activeStyle={{ color: 'green', textDecoration: 'underline' }}
      >
        Sobre
      </NavLink>{' '}
      | <NavLink to="login">Login</NavLink>
      <hr />
    </nav>
  );
};

export default Header;
