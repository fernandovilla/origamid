import React, { Children } from 'react';
import Form2 from './Form/Form2';

const Titulo = ({ texto, color }) => {
  return <h1 style={{ color: color }}>{texto}</h1>;
};

const SubTitulo = ({ children, color }) => {
  return <h2 style={{ color: color }}>{children}</h2>;
};

//rest spread

const App = () => {
  return (
    <>
      <Titulo texto="Título #1" color="green" />
      <SubTitulo color="blue">Sub-Titulo #1</SubTitulo>
      <Form2 />
    </>
  );
};

export default App;
