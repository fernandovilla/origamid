import React from 'react';

const Header = ({ links }) => {
  return (
    <header>
      <ul>
        {links.map((link) => (
          <li key={link.label}>
            <a href={link.href}>{link.label}</a>
          </li>
        ))}
      </ul>
    </header>
  );
};

export default Header;
