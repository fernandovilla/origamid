import React from 'react';

// ...props => spread/espalhamento
const Input2 = ({ id, label, ...props }) => {
  return (
    <div style={{ margin: '1rem 0' }}>
      <label htmlFor={id}>{label}</label>
      <input id={id} type="text" {...props} style={{ display: 'block' }} />
    </div>
  );
};

export default Input2;
