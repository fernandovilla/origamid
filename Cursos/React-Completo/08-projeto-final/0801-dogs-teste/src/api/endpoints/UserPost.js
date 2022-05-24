import React from 'react';

const UserPost = () => {
  const [username, setUsername] = React.useState('');
  const [email, setEmail] = React.useState('');
  const [password, setPassword] = React.useState('');
  const [id, setId] = React.useState(null);

  function handleChangeUserName({ target }) {
    setUsername(target.value);
  }

  function handleChangeEmail({ target }) {
    setEmail(target.value);
  }

  function handleChangePassword({ target }) {
    setPassword(target.value);
  }

  async function handleSubmit(event) {
    event.preventDefault();

    const bodyPost = JSON.stringify({
      username,
      email,
      password,
    });

    const response = await fetch('https://dogsapi.origamid.dev/json/api/user', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: bodyPost,
    });

    const jsonResponse = await response.json();

    console.log(jsonResponse);
    setId(jsonResponse);
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
        type="email"
        value={email}
        onChange={handleChangeEmail}
        placeholder="E-mail"
      />
      <input
        type="password"
        value={password}
        onChange={handleChangePassword}
        placeholder="Password"
      />
      <button>Enviar</button>
      <p>ID: {id}</p>
    </form>
  );
};

export default UserPost;
