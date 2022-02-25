import React from 'react';
import './style.css';

const Sidemenu = () => {
  const menuSessions = [
    {
      title: 'Cadastros',
      items: ['Produtos', 'Clientes', 'Fornecedores'],
    },
    {
      title: 'Relatórios',
      items: ['Vendas', 'Financeiro', 'Caixa', 'Estoque'],
    },
  ];

  return (
    <div className="sidemenu">
      <div className="logo">logo</div>
      <nav className="items">
        {menuSessions.map((item, n) => (
          <SideMenuSession title={item.title} items={item.items} key={n} />
        ))}
      </nav>
      <div className="footer">footer</div>
    </div>
  );
};

const SideMenuSession = ({ title, items }) => {
  const handleClick = ({ target }) => {
    const ul = target.nextSibling;
    ul.classList.toggle('active');
  };

  return (
    <div className="menuitem">
      <span onClick={handleClick}>{title}</span>
      <ul>
        {items.map((item, n) => (
          <li key={n}>{item}</li>
        ))}
      </ul>
    </div>
  );
};

export default Sidemenu;
