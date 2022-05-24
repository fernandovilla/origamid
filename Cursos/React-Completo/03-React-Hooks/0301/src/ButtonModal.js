import React from 'react';

const ButtonModal = ({ setModal }) => {
  function handleClick() {
    setModal((ativo) => !ativo);
  }

  return <button onClick={handleClick}>Modal</button>;
};

export default ButtonModal;
