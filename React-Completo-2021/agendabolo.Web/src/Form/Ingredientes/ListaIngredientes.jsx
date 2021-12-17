import React from 'react';
import { CadastroIngrediente } from './Form/Ingrediente/CadastroIngrediente';

const obterListaIngredienes = async () => {
  const ingrediente = {
    nome: nome.value,
    precoCusto: precoCusto.value,
  };

  const url = 'http://localhost:42916/ingredientes';

  const options = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json;charset=utf-8' },
    body: JSON.stringify(ingrediente),
  };

  const { response } = await request(url, options);

  if (response !== undefined && response.ok && error === null) {
    console.log('Cadastrado com sucesso...');
  } else {
    console.log('ERRO:', error);
  }
};

const ListaIngredientes = () => {
  return <div></div>;
};

export default ListaIngredientes;
