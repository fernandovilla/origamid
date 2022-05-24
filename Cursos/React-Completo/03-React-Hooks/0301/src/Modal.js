import React from 'react';

const Modal = ({ modal, setModal }) => {
  if (!modal) return null;

  return (
    <div
      style={{
        border: '1px solid',
        borderRadius: '4px',
        padding: '10px',
        margin: '20px',
      }}
    >
      <p>Esse é um modal!</p>
      <button onClick={() => setModal(false)}>Fechar</button>
    </div>
  );
};

export default Modal;
