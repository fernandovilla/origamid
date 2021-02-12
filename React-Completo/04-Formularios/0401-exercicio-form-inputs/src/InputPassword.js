import React from 'react';

const InputPassword = (props) => {
  return (
    <div>
      <label htmlFor={props.id}>{props.label}</label>
      <input
        type="password"
        id={props.id}
        name={props.name}
        value={props.value}
        onChange={props.onChange}
      />
    </div>
  );
};

export default InputPassword;
