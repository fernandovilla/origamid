import React from 'react';
import Button2 from './Button2';
import Input2 from './Input2';

const Form2 = () => {
  return (
    <form>
      <Input2 id="email" label="Email" required />
      <Input2 id="password" label="Password" type="password" />
      <p>
        <Button2 />
      </p>
    </form>
  );
};

export default Form2;
