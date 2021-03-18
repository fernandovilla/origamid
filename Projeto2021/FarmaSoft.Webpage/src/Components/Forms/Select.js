import React from 'react';
import styles from './Select.module.css'

const Select = (props) => {

  const options = props.options;

  if (options == null)
    return null;

  function onChange(event){
    //...
  }

  return (
    <div className={`${props.col} component-container`}>
      <label className={styles.label} htmlFor={props.id}>{props.label}</label>
      <select 
        className={styles.select} 
        id={props.id} 
        name={props.id}
        {...props}>

        {options.map((item,index) => (
          <option 
            key={index} 
            value={item.value} 
            disabled={item.disabled}>{item.label}
          </option>
        ))}
      </select>
    </div>)
}

export default Select;