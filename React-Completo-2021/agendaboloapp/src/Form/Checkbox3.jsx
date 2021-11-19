import React from 'react';

const Checkbox = ({ options, value, setValue, ...props }) => {
  const handleChange = ({ target }) => {
    if (target.value === '') return;

    if (target.checked) {
      setValue([...value, target.value]);
    } else {
      setValue(value.filter((i) => i !== target.value));
    }
  };

  return (
    <>
      {options.map((opt, index) => (
        <label key={index} htmlFor={`checkboxId${index}`}>
          <input
            id={`checkboxId${index}`}
            type="checkbox"
            value={opt.value}
            onChange={handleChange}
          />
          {opt.display}
        </label>
      ))}
    </>
  );
};

export default Checkbox;
