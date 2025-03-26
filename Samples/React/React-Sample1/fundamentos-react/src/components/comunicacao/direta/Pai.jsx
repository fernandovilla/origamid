import './Pai.css';
import React from 'react';
import Filho from './Filho';

const Pai = (props)=> {
    
    return <div>
      <h4>Pai: Emanual {props.sobrenome}</h4>      
      <ul className="filhos">        
        {/* Passagem de parâmetros usando spread */}
        <li><Filho {...props}>João</Filho></li>

        {/* Passagem de parâmetros direta */}
        <li><Filho sobrenome={props.sobrenome}>Maria</Filho></li>

        
        <li><Filho sobrenome={props.sobrenome}>Pedro</Filho></li>
      </ul>      
    </div>
};

export default Pai;