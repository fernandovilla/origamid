import React from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const navigate = useNavigate();

  function handleClick() {
    console.log('Vai para a tela de Home, após fazer o login');
    // navigate('/sobre');
    navigate('/');
  }

  return (
    <div>
      <h1>Login</h1>
      <button onClick={handleClick}>Login</button>
    </div>
  );
};

export default Login;
