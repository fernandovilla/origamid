import React from 'react'
import Input from '../Input3'
import useForm from '../../Hooks/useForm';
import useFetch from '../../Hooks/useFetch';

export const CadastroIngrediente = () => {
  const nome = useForm();
  const { request, data, loading, error } = useFetch();


  const handleSubmit = async (event) => {
    event.preventDefault();

    const ingrediente = {
      nome: nome.value,
      precoCusto: 2.00,
    }

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(ingrediente),
    };

    const { response } = await request(
      'http://localhost:42916/ingredientes',
      options,
    );

    if (response.ok && error == null) {
      console.log("Cadastrado com sucesso...");
    } else {
      console.log(error);
    }
  }

  return (
    <div>
      <h2>Cadastro de Ingrediente</h2>
      <form onSubmit={handleSubmit}>
        <Input 
          id="nome"
          label="Nome" 
          type="text" 
          value={nome.value} 
          {...nome} />

        <button type="submit">Confirmar</button>
      </form>
    </div>
  )
}
