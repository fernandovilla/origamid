import React from 'react';

const Input = ({ id, label, value, type, placeholder, error, onChange, onBlur }) => {
  // const handleChange = ({ target }) => {
  //   setValue(target.value);
  // };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
        type={type}
        id={id}
        name={id}
        value={value}
        placeholder={placeholder}      
        onChange={onChange}
        onBlur={onBlur}
        //{...props} //spread -> espalhar
      />
      {error && <p>{error}</p>}
    </>
  );
};

export default Input;
