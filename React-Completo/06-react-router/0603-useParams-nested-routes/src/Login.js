import React from 'react';
import { useNavigate } from 'react-router-dom';
import Head from './Head';

const Login = () => {
  const navigate = useNavigate();

  function handleClick() {
    console.log('Vai para a tela de Home, após fazer o login');
    // navigate('/sobre');
    navigate('/');
  }

  return (
    <div>
      <Head
        title="Log-in"
        description="Aqui é onde você faz o login, se tiver acesso"
      />
      <h1>Login</h1>
      <button onClick={handleClick}>Login</button>
    </div>
  );
};

export default Login;
