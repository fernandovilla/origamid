import './Super.css'
import React from 'react'
import Sub from './Sub'

const Super = (props) => {
  
  const [label, setLabel] = React.useState("Valor");
  const [number, setNumber] = React.useState(0);

  function onClick(classNameAdd, newNumber, newLabel){        
    const pai = document.getElementById("pai");
    pai.classList.toggle(classNameAdd);   
    
    setNumber(newNumber.toFixed(2));

    if (newLabel != label)
      setLabel(newLabel);
  }

  return <div>
    <h4 id="pai">{label}: {number}</h4>
    <Sub onClickSuper={onClick} />
  </div>
}

export default Super;