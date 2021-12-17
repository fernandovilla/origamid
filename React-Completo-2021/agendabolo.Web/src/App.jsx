import React from 'react';
import { CadastroIngrediente } from './Form/Ingredientes/CadastroIngrediente';
import { ListaIngredientes } from './Form/Ingredientes/ListaIngredientes';

const App = () => {
  return (
    <div>
      <CadastroIngrediente />
      <ListaIngredientes />
    </div>
  );
};

export default App;
