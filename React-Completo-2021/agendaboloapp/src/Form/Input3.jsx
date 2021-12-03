import React from 'react';

<<<<<<< HEAD
const Input = ({
  id,
  label,
  value,
  type,
  placeholder,
  error,
  onChange,
  onBlur,
}) => {
=======
const Input = ({ id, label, value, type, placeholder, error, onChange, onBlur }) => {
>>>>>>> b094f887ae179e44ad6b5c613ba4d93351aeb3cf
  // const handleChange = ({ target }) => {
  //   setValue(target.value);
  // };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
<<<<<<< HEAD
        id={id}
        name={id}
        type={type}
        placeholder={placeholder}
        value={value}
        error={error}
=======
        type={type}
        id={id}
        name={id}
        value={value}
        placeholder={placeholder}      
>>>>>>> b094f887ae179e44ad6b5c613ba4d93351aeb3cf
        onChange={onChange}
        onBlur={onBlur}
        //{...props} //spread -> espalhar
      />
      {error && <p>{error}</p>}
    </>
  );
};

export default Input;
