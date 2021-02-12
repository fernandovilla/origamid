import React from 'react';

const Header = () => {
  console.log('Renderizou header...');
  return (
    <div style={{ borderBottom: '1px solid gray' }}>
      <h1>Header</h1>
    </div>
  );
};

export default React.memo(Header);
