import React from 'react';

const menuItens = [
  { menu: 'Home', href: '/' },
  { menu: 'Produtos', href: '/produtos' },
];

const HeaderMenu = () => {
  return (
    <header>
      <ul>
        {menuItens.map((item) => (
          <li key={item.menu}>
            <a href={item.href}>{item.menu}</a>
          </li>
        ))}
      </ul>
    </header>
  );
};

export default HeaderMenu;
