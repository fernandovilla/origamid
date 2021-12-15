import React from 'react';
import Input from '../Input3';
import useForm from '../../Hooks/useForm';
import useFetch from '../../Hooks/useFetch';

export const CadastroIngrediente = () => {
  const nome = useForm();
  const precoCusto = useForm();
  const { request, data, loading, error } = useFetch();

  const handleSubmit = async (event) => {
    event.preventDefault();
    await cadastrarIngrediente();
  };

  const cadastrarIngrediente = async () => {
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

  return (
    <div>
      <h2>Cadastro de Ingrediente</h2>
      <form onSubmit={handleSubmit}>
        <Input
          id="nome"
          label="Nome"
          type="text"
          value={nome.value}
          {...nome}
        />

        <Input
          id="precoCusto"
          label="Preço Custo"
          type="number"
          value={precoCusto}
          {...precoCusto}
        />

        <button type="submit">Confirmar</button>
      </form>
    </div>
  );
};
