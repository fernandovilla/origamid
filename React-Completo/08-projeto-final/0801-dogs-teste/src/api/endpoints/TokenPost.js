import React from 'react';

const TokenPost = () => {
  const [username, setUsername] = React.useState('');
  const [password, setPassword] = React.useState('');
  const [token, setToken] = React.useState('');

  function handleChangeUserName({ target }) {
    setUsername(target.value);
  }

  function handleChangePassword({ target }) {
    setPassword(target.value);
  }

  async function handleSubmit(event) {
    event.preventDefault();

    const bodyPost = JSON.stringify({
      username,
      password,
    });

    const response = await fetch(
      'https://dogsapi.origamid.dev/json/jwt-auth/v1/token',
      {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: bodyPost,
      },
    );

    const jsonResponse = await response.json();

    console.log(response);
    console.log(jsonResponse);

    setToken(jsonResponse.token);
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={username}
        onChange={handleChangeUserName}
        placeholder="Username"
      />
      <input
        type="password"
        value={password}
        onChange={handleChangePassword}
        placeholder="Password"
      />
      <button>Login</button>
      <p style={{ wordBreak: 'break-all' }}>Token: {token}</p>
    </form>
  );
};

export default TokenPost;
