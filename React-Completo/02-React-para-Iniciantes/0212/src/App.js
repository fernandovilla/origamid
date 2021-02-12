import React from 'react';
import Header from './Header';
import Home from './Home';
import Produtos from './Produtos';

const App = () => {
  const links = [
    { label: 'Home', href: '/' },
    { label: 'Produtos', href: '/produtos' },
  ];

  const { pathname } = window.location;

  let Pagina;
  if (pathname === '/produtos') {
    Pagina = Produtos;
  } else {
    Pagina = Home;
  }

  Pagina = Produtos;
  return (
    <section>
      <Header links={links} />
      <Pagina />
    </section>
  );
};

export default App;
