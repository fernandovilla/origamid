import React from 'react';

const Radio = ({ options, value, setValue, ...props }) => {
  function handleChange({ target }) {
    setValue(target.value);
  }

  return (
    <section>
      {options.map((option) => (
        <label key={option}>
          <input
            type="radio"
            value={option}
            checked={value === option}
            onChange={handleChange}
            {...props}
          />
          {option}
        </label>
      ))}
    </section>
  );
};

export default Radio;
