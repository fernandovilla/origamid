import React from 'react';

const InputText = (props) => {
  return (
    <div>
      <label htmlFor={props.id}>{props.label}</label>
      <input
        type="text"
        id={props.id}
        name={props.name}
        value={props.value}
        onChange={props.onChange}
      />
    </div>
  );
};

export default InputText;
