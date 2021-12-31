import React from 'react';
import { Link } from 'react-router-dom';
import { Table } from '../Table';

/*
  React Table
  https://react-table.tanstack.com/docs/quick-start 
*/

const Ingredientes = () => {
  const data = React.useMemo(() => [
    { id: '1', prod: 'FARINHA DE TRIGO', preco: 3.40, quant: '10.5k' },
    { id: '2', prod: 'LEITE EM PÓ NINHO', preco: 13.90, quant: '4.0k' },
    { id: '3', prod: 'LEITE CONDENSADO MOÇA', preco: 5.99, quant: '2.6k' },
  ]);

  const cellLink = ({row})  => {
    return <Link to={row.original.id} style={{color:'blue'}}>{row.original.prod}</Link>
  }

  const columns = React.useMemo(() => [
    { Header: 'ID', accessor: 'id' },
    { Header: 'Produto', accessor: 'prod', Cell: cellLink },
    { Header: 'Preço', accessor: 'preco'},
    { Header: 'Qtde', accessor: 'quant'}
  ]);

  return (
    <div>
      <h2>Ingredientes:</h2>
      
      <Table columns={columns} data={data} />      
    </div>
  );
};

export default Ingredientes;
