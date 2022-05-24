import React from 'react';
import './Header.css';
import { NavLink, useLocation } from 'react-router-dom';

const Header = () => {
  const location = useLocation();

  React.useEffect(() => {
    console.log('mudou a rota...');
  }, [location]);

  return (
    <div className="header-container">
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
      </nav>
    </div>
  );
};

export default Header;
