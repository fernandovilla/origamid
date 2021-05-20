import React from 'react';

const Condicional = (props) => {

  return (
    <div>
      <p>O número {props.number} é </p>
      { props.number % 2 == 0  ?
        <span>Par</span> :
        <span>Ímpar</span>
      }
    </div>
  )

}

export default Condicional;