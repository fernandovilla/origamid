import React from 'react';

const Select = ({ id, options, value, setValue, ...props }) => {
  function handleChange({ target }) {
    setValue(target.value);
  }

  return (
    <section>
      <select id={id} value={value} onChange={handleChange} {...props}>
        <option disabled value="">
          Selecione
        </option>
        {options.map((op) => (
          <option key={op} value={op}>
            {op}
          </option>
        ))}
      </select>
    </section>
  );
};

export default Select;
