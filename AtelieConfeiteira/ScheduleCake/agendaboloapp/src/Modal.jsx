import React from 'react';

const Modal = ({ modal, setModal }) => {
  const handleClick = () => setModal(false);

  if (modal)
    return (
      <div
        style={{
          border: '1px solid',
          borderRadius: '4px',
          margin: '20px 0px',
          padding: '5px',
          width: '300px',
          height: '200px',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
        }}
      >
        Esse é um modal. <button onClick={handleClick}>X</button>
      </div>
    );

  return null;
};

export default Modal;
