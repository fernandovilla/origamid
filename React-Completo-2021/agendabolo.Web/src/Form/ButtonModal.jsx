import React from 'react';

const ButtonModal = ({ setModal }) => {
  //'anterior' equivale ao valor anterior que está no useState alterado pelo setModal
  const handleClick = () => setModal((anterior) => !anterior);

  return <button onClick={handleClick}>Abrir</button>;
};

export default ButtonModal;
