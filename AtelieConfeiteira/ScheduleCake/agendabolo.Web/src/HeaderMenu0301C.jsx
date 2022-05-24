import React from 'react';

const HeaderMenu0301C = ({ buttons, setButton, onClick }) => {
  const handleClick = (event) => {
    if (setButton !== undefined) {
      setButton(event.target.id);
    } else {
      onClick(event);
    }
  };

  return (
    <div>
      {buttons.map((button) => (
        <button
          style={{ margin: '0px 10px' }}
          key={button.key}
          id={button.key}
          onClick={handleClick}
        >
          {button.display}
        </button>
      ))}
    </div>
  );
};

export default HeaderMenu0301C;
