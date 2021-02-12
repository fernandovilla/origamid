import React from 'react';

const Input = ({
  id,
  label,
  value,
  setValue,
  onChange,
  type,
  onBlur,
  placeholder,
  error,
  ...props
}) => {
  // function handleChange({ target }) {
  //   setValue(target.value);
  // }

  if (type.length === 0) type = 'text';

  console.log(error);

  return (
    <div>
      <label htmlFor={id}>{label}</label>
      <input
        type={type}
        id={id}
        name={id}
        value={value}
        onChange={onChange}
        onBlur={onBlur}
        placeholder={placeholder}
        {...props}
      />
      {error && (
        <span style={{ color: 'red', fontStyle: 'italic' }}>{error}</span>
      )}
    </div>
  );
};

export default Input;
