import React from 'react';

const Checkbox = ({ options, value, setValue, ...props }) => {
  function handleChange({ target }) {
    if (target.checked) {
      setValue([...value, target.value]);
    } else {
      setValue(value.filter((i) => i !== target.value));
    }
  }

  function checkValue(item) {
    return value.includes(item);
  }

  return (
    <section>
      {options.map((option) => (
        <label key={option}>
          <input
            type="checkbox"
            value={option}
            onChange={handleChange}
            checked={checkValue(option)}
          />
          {option}
        </label>
      ))}
    </section>
  );
};

export default Checkbox;
