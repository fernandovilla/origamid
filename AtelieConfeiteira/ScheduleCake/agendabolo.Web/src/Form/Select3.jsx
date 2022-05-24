import React from 'react';

const Select = ({ id, label, options, value, setValue, select, ...props }) => {
  const handleChange = ({ target }) => {
    if (target.value !== '') setValue(target.value);
  };

  return (
    <>
      {label && <label htmlFor={id}>{label}</label>}
      <select value={value} onChange={handleChange} {...props}>
        {select && (
          <option disabled value="">
            Selecione
          </option>
        )}
        {options.map((opt, index) => (
          <option key={index} value={opt.value}>
            {opt.display}
          </option>
        ))}
      </select>
    </>
  );
};

export default Select;
