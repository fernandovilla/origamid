import React from 'react';

const Radio = ({ name, options, value, setValue, ...props }) => {
  const handleChange = ({ target }) => {
    if (target.value !== '') {
      setValue(target.value);
    }
  };

  return (
    <>
      {options.map((opt, index) => (
        <label key={index} htmlFor={`radioId${index}`}>
          <input
            type="radio"
            id={`radioId${index}`}
            name={name}
            value={opt.value}
            checked={value === opt.value}
            onChange={handleChange}
            {...props}
          />
          {opt.display}
        </label>
      ))}
    </>
  );
};

export default Radio;
