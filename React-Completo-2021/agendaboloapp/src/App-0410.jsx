import React from 'react';
import Input from './Form/Input3';

const App = () => {
  const [cep, setCep] = React.useState('');
  const [error, setError] = React.useState(null);

  const validarCep = (value) => {
    if (value.length === 0) {
      setError('CEP inválido');
      return false;
    }

    const regex = /^\d{5}-?\d{3}$/;
    if (!regex.test(value)) {
      setError('CEP inválido');
      return false;
    }

    setError(null);
    return true;
  };

  const handleBlur = ({ target }) => {
    validarCep(target.value);
  };

  const handleChange = ({ target }) => {
    if (error) {
      validarCep(target.value);
    }
    setCep(target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    if (!validarCep(cep)) {
      console.log('Não enviou...');
      return;
    }

    console.log('Enviando...');
  };

  return (
    <div>
      <h1>0410 - Validação</h1>
      <form onSubmit={handleSubmit}>
        <Input
          id="cep"
          label="CEP"
          placeholder="000000-000"
          value={cep}
          onChange={handleChange}
          onBlur={handleBlur}
        />
        {error && <p>{error}</p>}

        <p>
          <button type="submit">Enviar</button>
        </p>
      </form>
    </div>
  );
};

export default App;
