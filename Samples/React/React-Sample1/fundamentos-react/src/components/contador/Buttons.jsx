import React from 'react'

const Buttons = (props) => {
  return (
  <div>
    <button onClick={props.onAddValue}>+</button>
    <button onClick={props.onSubValue}>-</button>
  </div>);
}

export default Buttons;