import React from 'react';

const Input = ({ id, label, onChange, ...props }) => {
  // const handleChange = ({ target }) => {
  //   setValue(target.value);
  // };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
        type="text"
        id={id}
        name={id}
        onChange={onChange}
        {...props} //spread -> espalhar
      />
    </>
  );
};

export default Input;
