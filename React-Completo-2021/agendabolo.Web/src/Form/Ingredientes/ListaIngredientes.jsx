import React from 'react';
import { useIngredientes } from './useIngredientes';

/*
  React Table
  https://react-table.tanstack.com/docs/quick-start 
*/

export const ListaIngredientes = () => {
  const { listarIngredientes } = useIngredientes();
  const [ingredientes, setIngredientes] = React.useState(null);
  const [error, setError] = React.useState(null);

  React.useEffect(() => {
    const listar = async () => {
      const response = await listarIngredientes();

      setIngredientes(null);
      setError(null);

      if (response.status === 200) {
        setIngredientes(response.data);
      } else {
        setError(response.error);
      }
    };

    listar();
  }, []);

  return (
    <div>
      {ingredientes &&
        ingredientes.map((item) => <li key={item.id}>{item.nome}</li>)}

      {error && <p>Ocorreu erro ao listar os itens</p>}
    </div>
  );
};
