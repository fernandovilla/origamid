import React from 'react';
import { Link } from 'react-router-dom';
import Head from './Head';

const Home = () => {
  return (
    <div>
      <Head title="Aqui é a Home!" description="Este é um site muito legal" />
      <h1>Home</h1>
      <p>Essa é a home do site</p>
      <Link to="produto/notebook">Notebook</Link> |{' '}
      <Link to="produto/smartphone">Smartphone</Link>
    </div>
  );
};

export default Home;
