import './Card.css';
import React from 'react';

const Card = (props) => {
  return <div className="card" style={{borderColor: props.color || '#000'}}>
    <div className="content">
      {props.children}
    </div>    
    <div className="footer" style={{backgroundColor: props.color || '#000'}}>
      <h3>{props.title}</h3>
    </div>    
  </div>
}

export default Card;