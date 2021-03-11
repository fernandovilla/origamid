import React from 'react';
import styles from './InputText.module.css';

const InputText = (props) => {
  return (
    <div className={props.col}>
      <label className={styles.label} htmlFor={props.name}>
        {props.label}
      </label>
      <input
        className={styles.input}
        type="text"
        id={props.name}
        name={props.name}
      />
    </div>
  );
};

export default InputText;
