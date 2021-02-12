import React from 'react';
import Button from './Button';
import Input from './Input';

const Form = () => {
  const arrayButton = ['Item 1', 'Item 2', 'Item 3'];

  return (
    <form>
      <Input label="Email: " id="codigo" required />
      <Input label="Password: " id="nome" type="password" />
      <Button items={arrayButton} />
    </form>
  );
};

export default Form;
