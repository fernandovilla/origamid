import React from 'react';
import Input from './Form/Input';
import useForm from './Hooks/useForm';

const App = () => {
  const cep = useForm('cep');
  const email = useForm('email');
  const nome = useForm(false);

  function handleSubmit(event) {
    event.preventDefault();

    if (!cep.validate()) {
      console.log('Não enviou...');
      return;
    }

    if (!email.validate()) {
      console.log('Não enviou...');
      return;
    }

    console.log('Enviou...');
  }

  return (
    <form onSubmit={handleSubmit}>
      <Input
        type="text"
        id="nome"
        label="Nome:"
        placeholder="Digite seu nome..."
        {...nome}
      />
      <br />
      {/* Fazendo o spread do cep, ele já pega os atributos 'value, onBlur e onChange' */}
      <Input
        type="text"
        id="cep"
        label="CEP:"
        placeholder="00000-000"
        {...cep}
      />
      <br />
      <Input
        type="email"
        id="email"
        label="E-mail:"
        placeholder="Digite seu e-mail..."
        {...email}
      />
      <br />
      <button>Enviar</button>
    </form>
  );
};

export default App;
