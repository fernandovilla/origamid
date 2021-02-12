import React from 'react';

const InputEmail = (props) => {
  return (
    <div>
      <label htmlFor={props.id}>{props.label}</label>
      <input
        type="email"
        id={props.id}
        name={props.name}
        value={props.value}
        onChange={props.onChange}
      />
    </div>
  );
};

export default InputEmail;
