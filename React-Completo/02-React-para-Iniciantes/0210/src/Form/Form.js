import React from 'react';
import Button from './Button';
import Input from './Input';

const Form = () => {
  return (
    <form>
      <p>
        <label htmlFor="codigo">Codigo</label>
        <Input id="codigo" />
      </p>
      <p>
        <label htmlFor="nome">Nome</label>
        <Input id="nome" />
      </p>
      <p>
        <label htmlFor="email">Email</label>
        <Input id="email" />
      </p>
      <Button />
    </form>
  );
};

export default Form;
