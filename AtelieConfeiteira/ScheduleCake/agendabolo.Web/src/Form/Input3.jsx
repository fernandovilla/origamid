import React from 'react';


const Input = ({ id, label, value, type, placeholder, error, onChange, onBlur }) => {
  // const handleChange = ({ target }) => {
  //   setValue(target.value);
  // };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
        id={id}
        name={id}
        type={type}
        placeholder={placeholder}
        value={value}
        error={error}
        onChange={onChange}
        onBlur={onBlur}
        //{...props} //spread -> espalhar
      />
      {error && <p>{error}</p>}
    </>
  );
};

export default Input;
