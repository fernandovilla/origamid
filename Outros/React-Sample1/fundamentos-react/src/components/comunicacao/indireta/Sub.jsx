import React from 'react'

const Sub = (props) => {

  function onClickSub(){
    props.onClickSuper("pink", Math.random(), "Novo Valor");
  }

  return <div>
    <button onClick={onClickSub}>Alterar Pai</button>
  </div>
}

export default Sub;