import React from 'react';
import { useIngredientes } from './useIngredientes';
import { Link } from 'react-router-dom';
import Table from '../Table';

const ListaIngredientes = () => {
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

  const cellLink = ({row})  => {
    return <Link to={row.original.id} style={{color:'blue'}}>{row.original.nome}</Link>
  }

  const columns = React.useMemo(() => [
    { Header: 'ID', accessor: 'id' },
    { Header: 'Nome', accessor: 'nome', Cell: cellLink },
    { Header: 'Preço Custo', accessor: 'precoCusto'},    
  ]);

  
  return (
    <div>
      {/* {ingredientes &&
        ingredientes.map((item) => <li key={item.id}>{item.nome}</li>)} */}

      {error && <p>Ocorreu erro ao listar os itens</p>}

      { ingredientes && <Table columns={columns} data={ingredientes} />}
    </div>
  );
};

export default ListaIngredientes;