import './Card.css';
import React from 'react';

const Card = (props) => {
  return <div className="card">
    <div className="content">
      {props.children}
    </div>    
    <div className="footer">
      <h3>{props.title}</h3>
    </div>    
  </div>
}

export default Card;