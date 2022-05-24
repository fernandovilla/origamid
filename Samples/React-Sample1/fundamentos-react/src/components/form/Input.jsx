import React from 'react'

const Input = (props) => {
  const [value, setValue] = React.useState(props.initialValue);

  const changeValue = (events) => {
    const text = events.target.value;

    if (text != value)
      setValue(text);
  };

  return <>
    <h3>{value}</h3>
    <input type="text" value={value} onChange={changeValue} />
  </>;
}

export default Input;