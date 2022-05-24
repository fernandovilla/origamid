import React from 'react';

const Input = ({ id, label, ...props }) => {
  return (
    <section style={{ margin: '1rem 0' }}>
      <label htmlFor={id}>{label}</label>
      <input type="text" id={id} {...props} />
    </section>
  );
};

export default Input;
