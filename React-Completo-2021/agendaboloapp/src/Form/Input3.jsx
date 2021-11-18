import React from 'react';

const Input = ({ id, label, setValue, ...props }) => {
  const handleChange = ({ target }) => {
    setValue(target.value);
  };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
        type="text"
        id={id}
        name={id}
        onChange={handleChange}
        {...props} //spread -> espalhar
      />
    </>
  );
};

export default Input;
