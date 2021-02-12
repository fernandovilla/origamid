import React from 'react';

const PhotoGet = () => {
  const [id, setId] = React.useState('');

  async function handleSubmit(event) {
    event.preventDefault();

    let url = `https://dogsapi.origamid.dev/json/api/photo/${id}`;
    const response = await fetch(url);
    const jsonResponse = await response.json();

    console.log(jsonResponse);
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={id}
        onChange={({ target }) => setId(target.value)}
        placeholder="ID da foto"
      />
      <button>Obter</button>
    </form>
  );
};

export default PhotoGet;
