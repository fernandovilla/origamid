import React from 'react';

const Input = ({ id, label, value, setValue, ...props }) => {
  function handleChange({ target }) {
    setValue(target.value);
  }

  return (
    <div>
      <label htmlFor={id}>{label}</label>
      <input
        type="text"
        id={id}
        name={id}
        value={value}
        onChange={handleChange}
        {...props}
      />
    </div>
  );
};

export default Input;
