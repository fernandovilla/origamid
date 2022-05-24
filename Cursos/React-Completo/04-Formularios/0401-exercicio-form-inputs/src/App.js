import React from 'react';
import InputEmail from './InputEmail';
import InputText from './InputText';
import InputPassword from './InputPassword';

const Sample1 = () => {
  const [form, setForm] = React.useState({ nome: '', email: '' });

  function handleChange({ target }) {
    const { id, value } = target;
    setForm({ ...form, [id]: value });
  }

  function handleSubmit(event) {
    event.preventDefault();
  }

  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="nome">Nome:</label>
      <input
        id="nome"
        type="text"
        onChange={handleChange}
        value={form.nome}
        name="nome"
      />

      <input
        type="email"
        id="email"
        onChange={handleChange}
        value={form.email}
        name="email"
      />
      <p>
        {form.nome}, {form.email}
      </p>
      <button type="submit">Enviar</button>
    </form>
  );
};

const getFormFields = () => {
  return [
    { id: 'nome', type: 'text', label: 'Nome' },
    { id: 'email', type: 'email', label: 'E-mail:' },
    { id: 'senha', type: 'password', label: 'Senha:' },
    { id: 'cep', type: 'text', label: 'CEP:' },
    { id: 'rua', type: 'text', label: 'Rua:' },
    { id: 'numero', type: 'text', label: 'Número:' },
    { id: 'bairro', type: 'text', label: 'Bairro:' },
    { id: 'cidade', type: 'text', label: 'Cidade:' },
    { id: 'estado', type: 'text', label: 'Estado:' },
  ];
};

const getDataFields = () => {
  return getFormFields().reduce((acc, field) => {
    return {
      ...acc,
      [field.id]: '',
    };
  }, {});
};

// Exercício com fetch
const Sample2 = () => {
  const [response, setResponse] = React.useState(null);
  const [form, setForm] = React.useState(getDataFields());

  function handleChange({ target }) {
    const { id, value } = target;
    setForm({ ...form, [id]: value });
  }

  function handleSubmit(event) {
    event.preventDefault();

    fetch('https://ranekapi.origamid.dev/json/api/usuario', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(form),
    }).then((response) => {
      setResponse(response);
    });
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        {getFormFields().map((field) => (
          <div key={field.id}>
            <label htmlFor={field.id}>{field.label}</label>
            <input
              type={field.type}
              id={field.id}
              value={form[field.id]}
              onChange={handleChange}
            />
          </div>
        ))}
        <button type="submit">Enviar</button>
        <br />
        {response && response.ok && <p>Dados cadastrados com sucesso!</p>}
      </form>
    </div>
  );
};

const App = () => {
  return Sample2();
};

export default App;
