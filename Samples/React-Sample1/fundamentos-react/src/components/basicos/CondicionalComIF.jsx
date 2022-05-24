import React from 'react';
import If from './If';

const CondicionalComIF = (props) => {

  return (
    <div>
      <p>O número {props.number} é </p>
      <If test={props.number % 2 === 0}>
        <span>Par</span>
      </If>
      <If test={props.number % 2 === 1}>
        <span>Ímpar</span>
      </If>      
    </div>
  )
}

export default CondicionalComIF;