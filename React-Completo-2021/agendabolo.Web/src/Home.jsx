import React from 'react';
import Titulo from './Titulo';
import ListaIngredientes from './Form/Ingredientes/ListaIngredientes';

const Home = ({ title }) => {
  if (title === undefined) title = 'Título da Home';

  return (
    <section>
      <Titulo texto={title} />
      <ListaIngredientes />
      <p>Essa é a página Home</p>
    </section>
  );
};

export default Home;
