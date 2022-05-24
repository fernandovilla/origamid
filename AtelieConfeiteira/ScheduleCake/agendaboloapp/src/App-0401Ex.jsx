import React from 'react';
import Input2 from './Form/Input2';
import useFetch from './Hooks/useFetch';

const formFields = [
  { id: 'nome', label: 'Nome', type: 'text' },
  { id: 'email', label: 'Email', type: 'email' },
  { id: 'senha', label: 'Senha', type: 'password' },
  { id: 'cep', label: 'CEP', type: 'text' },
  { id: 'rua', label: 'Rua', type: 'text' },
  { id: 'numero', label: 'Número', type: 'text' },
  { id: 'bairro', label: 'Bairro', type: 'text' },
  { id: 'cidade', label: 'Cidade', type: 'text' },
  { id: 'uf', label: 'UF', type: 'text' },
];

const clienteDefault = formFields.reduce((acc, field) => {
  return { ...acc, [field.id]: '' };
}, {});

const App = () => {
  const [form, setForm] = React.useState(clienteDefault);
  const { request, data, loading, error } = useFetch();
  const timeoutRef = React.useRef();
  const [notification, setNotification] = React.useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(form),
    };

    const { response } = await request(
      'https://ranekapi.origamid.dev/json/api/usuario',
      options,
    );

    if (response.ok && error == null) {
      setNotification('Usuário registrado com sucesso');
    } else {
      setNotification('Ocorreu erro ano registrar usuário. Erro: ' + error);
    }

    clearTimeout(timeoutRef.current); // Limpa a referência e em seguida cria uma nova referencia do timeout
    timeoutRef.current = setTimeout(() => {
      setNotification(null);
    }, 3000);
  };

  const handleChange = ({ target }) => {
    const { id, value } = target;
    setForm({ ...form, [id]: value });
  };

  const limparHandleClick = () => {
    setForm(clienteDefault);
  };

  return (
    <div>
      <h1>0401 - Exercício</h1>
      <form onSubmit={handleSubmit}>
        {formFields.map(({ id, label, type }) => (
          <Input2
            key={id}
            id={id}
            type={type}
            label={label}
            value={form[id]}
            onChange={handleChange}
          />
        ))}
        <button type="submit">Enviar</button>
        <button
          type="button"
          onClick={limparHandleClick}
          style={{ marginLeft: '10px' }}
        >
          Limpar
        </button>
      </form>

      {loading && <p>Registrando usuário. Aguarde...</p>}
      {notification && <p>{notification}</p>}
    </div>
  );
};

export default App;
