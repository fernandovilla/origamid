import React from 'react';
import Form from './Form/Form';

const TituloA = (args) => {
  return <h1 style={{ color: args.cor }}>{args.texto}</h1>;
};

const TituloB = ({ texto, cor, children }) => {
  return (
    <h1 style={{ color: cor }}>
      {texto}, {children}
    </h1>
  );
};

const App = () => {
  return (
    <div>
      <TituloB texto="Título #1" cor="red">
        este elemento possui 'children'
      </TituloB>
      <TituloB texto="Título #2" cor="blue" />
      <TituloB texto="Título #3" cor="green" />
      <hr />
      <Form />
    </div>
  );
};

export default App;
