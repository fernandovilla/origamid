import React from 'react';

const Filho = (props)=> {
    return <div>      
      <p>{props.children} {props.sobrenome}</p>
    </div>;
};

export default Filho;