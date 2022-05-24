import React from 'react';
import { Link } from 'react-router-dom';

const Produtos = () => {
  return (
    <div>
      <h2>Produtos</h2>
      <ul style={{ listStyle: 'none' }}>
        <li>
          <Link to="notebook">Notebok</Link>
        </li>
        <li>
          <Link to="smartphone">SmartPhone</Link>
        </li>
        <li>
          <Link to="tablet">Tablet</Link>
        </li>
      </ul>
    </div>
  );
};

export default Produtos;
