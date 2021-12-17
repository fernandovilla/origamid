import React from 'react';

/*
  React Table
  https://react-table.tanstack.com/docs/quick-start 
*/

const ProdutosTable = () => {
  const data = React.useMemo(() => [
    { col1: 'Hello', col2: 'World' },
    { col1: 'react-table', col2: 'rocks' },
    { col1: 'whatever', col2: 'you want' },
  ]);

  const columns = React.useMemo(() => [
    { Header: 'Column 1', accessor: 'col1' },
    { Header: 'Column 2', accessor: 'col2' },
  ]);

  return (
    <div>
      <h1>Produtos</h1>
    </div>
  );
};

export default ProdutosTable;
