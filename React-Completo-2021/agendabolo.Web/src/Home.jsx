import React from 'react';
import Titulo from './Titulo';

const Home = ({ title }) => {
  if (title === undefined) title = 'Título da Home';

  return (
    <section>
      <Titulo texto={title} />
      <p>Essa é a página Home</p>
    </section>
  );
};

export default Home;
