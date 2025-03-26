import './ComParametro.css';
import React from 'react';

const ComParametro = (props) => {
  return (
    <div className="container">
      <h1>Component with Parameters</h1>
      <h2>{props.titulo}</h2>
      <h3>{props.subtitulo}</h3>    
    </div>
  )
}

export default ComParametro;