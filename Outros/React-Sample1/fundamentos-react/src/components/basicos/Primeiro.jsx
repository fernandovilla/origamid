// Se retorno for apenas uma string, não é necessáiro importar o React, apenas se o retorno for JSX;
import React from 'react';    

const Primeiro = (props) => {
  return (
    <>    
      <h1>First Component</h1>
      <p>First component developed with react js</p>
    </>);
}

// Também dá pra usar uma <div> ou o <React.Fragment> para retornar;

export default Primeiro;