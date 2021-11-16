import React from 'react';

const App = () => {
  // const [nome, setNome] = React.useState('');
  // const [email, setEmail] = React.useState('');

  const [form, setForm] = React.useState({ nome: '', email: '' });

  const handleSubmit = (event) => {
    event.preventDefault();

    console.log(form);
  };

  const handleChange = ({ target }) => {
    const { id, value } = target;
    setForm({ ...form, [id]: value });
  };

  return (
    <>
      <h1>0401 - Forms - Input</h1>
      <form action="" onSubmit={handleSubmit}>
        <label htmlFor="nome">Nome</label>
        <input
          id="nome"
          type="text"
          value={form.nome}
          //onChange={(event) => setNome(event.target.value)}
          onChange={handleChange}
        />
        <p>{form.nome}</p>

        <label htmlFor="email">Email</label>
        <input
          id="email"
          type="email"
          value={form.email}
          //onChange={(event) => setEmail(event.target.value)}
          onChange={handleChange}
        />
        <p>{form.email}</p>
        <button type="submit">Enviar</button>
      </form>
    </>
  );
};

export default App;
