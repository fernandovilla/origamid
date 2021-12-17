<<<<<<< HEAD
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
=======
import React from 'react'
import { useIngredientes } from './useIngredientes'

export const ListaIngredientes = () => {
   const { listarIngredientes } = useIngredientes();
   const [ ingredientes, setIngredientes ] = React.useState(null);
   const [ error, setError ] = React.useState(null);

  React.useEffect(() => {    
    const listar = async () => {
      const response = await listarIngredientes();

      setIngredientes(null);
      setError(null);

      if (response.status === 200){
        setIngredientes(response.data);
      } else {
        setError(response.error)
      }
    }

    listar();
  }, [])


  return (
    <div>      
      { ingredientes && (
          ingredientes.map(item => (
            <li key={item.id}>{item.nome}</li>
          ))
      )}

      { error && <p>Ocorreu erro ao listar os itens</p>}

    </div>
  )
}
>>>>>>> e6478ed8e807d1a74d00de7ec6806774018eea53
