import React from 'react';
import { Link } from 'react-router-dom';
import { useTable } from 'react-table';
import { Ingrediente } from './Ingrediente';

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

  // Cria a instâncis de tableInstance
  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = useTable({ columns, data});
 
  
  return (
    <div>
      <h2>Ingredientes:</h2>
      {/* <Routes>
        <Route path="ingredientes/:id/*" element={<Ingrediente />} />
      </Routes> */}

      { /* apply the table props */}
      <table {...getTableProps()}>
        <thead>
          { // Loop over the header rows
          headerGroups.map(headerGroup => (
          <tr {...headerGroup.getHeaderGroupProps()}>
            { // Apply the header cell props
            headerGroup.headers.map(column => (
            <th {...column.getHeaderProps()}>
              {column.render('Header')}
            </th>
            ))} 
          </tr>
          ))}
        </thead>
        {/* Apply the table body props */}
        <tbody {...getTableBodyProps()}>
          { // Loop over the table rows
            rows.map(row => {
              // Prepare the row for display
              prepareRow(row)
              return (
                <tr {...row.getRowProps()}>
                  { // Loop over the rows cells
                    row.cells.map(cell => {
                      // Apply the cell props
                      return (
                        <td {...cell.getCellProps()}>
                          {cell.render('Cell')}
                        </td>
                      )
                    })
                  }
                </tr>
              )})
          }  
        </tbody>
      </table>
    </div>
  );
};

export default Ingredientes;
