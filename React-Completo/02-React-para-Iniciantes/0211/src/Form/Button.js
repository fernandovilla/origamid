import React from 'react';

function printItems(items) {
  console.log(items);
}

const Button = (props) => {
  const items = props.items;
  return <button onClick={() => printItems(items)}>Enviar</button>;
};

export default Button;
