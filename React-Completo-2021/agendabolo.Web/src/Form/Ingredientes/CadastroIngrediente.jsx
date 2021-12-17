import React from 'react';
import Input from '../Input3';
import useForm from '../../Hooks/useForm';
import useFetch from '../../Hooks/useFetch';
import { useIngredientes } from './useIngredientes';

export const CadastroIngrediente = () => {
  const nome = useForm();
  const precoCusto = useForm();
  const { request, data, loading, error } = useFetch();
  const { cadastrarIngrediente } = useIngredientes();

  const handleSubmit = async (event) => {
    event.preventDefault();

    await cadastraIngrediente();
  };

  const cadastraIngrediente = async () => {
    const ingrediente = {
      nome: nome.value,
      precoCusto: precoCusto.value,
    };

    const retorno = await cadastrarIngrediente(ingrediente);

    if (retorno){
      //cadastrado com sucesso...
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
