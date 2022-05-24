import React from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const navigate = useNavigate();

  const handleClick = () => {
    console.log('Realizando login do fulano...');
    navigate('/');
  };

  return (
    <div>
      <h2>Login</h2>
      <button onClick={handleClick}>Login</button>
    </div>
  );
};

export default Login;
