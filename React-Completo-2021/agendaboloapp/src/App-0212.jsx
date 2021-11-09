import React from 'react';
import Produtos from './Form/Produtos/Produtos';
import Home from './Home';
import HeaderMenu from './HeaderMenu';

const RenderPage = () => {
  const { pathname } = window.location;

  if (pathname === '/produtos') {
    return <Produtos />;
  } else {
    return <Home />;
  }
};

//renderPage();

const App = () => {
  return (
    <section>
      <HeaderMenu />
      <RenderPage />
    </section>
  );
};

export default App;
