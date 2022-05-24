import React from 'react';
import Button from './Button';
import Input from './Input';

const Form = () => {
  return (
    <form>
      <p>
        <label htmlFor="name">Nome</label>
        <Input />
      </p>

      <p>
        <label htmlFor="email">E-mail</label>
        <Input />
      </p>

      <Button />
    </form>
  );
};

export default Form;
