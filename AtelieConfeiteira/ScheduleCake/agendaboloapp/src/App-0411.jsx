import React from 'react';
import useForm from './Hooks/useForm';
import Input from './Form/Input3';

const App = () => {
  const cep = useForm('cep');
  const email = useForm('email');
  const nome = useForm();
  const sobrenome = useForm(false); //sem validação...

  const handleSubmit = (event) => {
    event.preventDefault();

    var ok = nome.validate() && email.validate() && cep.validate();

    if (ok) {
      console.log('Enviando...');
    } else {
      console.log('Erro ao enviar...');
    }
  };

  return (
    <div>
      <h1>0411</h1>
      <form onSubmit={handleSubmit}>
        <Input
          label="CEP"
          id="cep"
          type="text"
          placeholder="00000-000"
          {...cep}
        />
        <Input
          label="Email"
          id="email"
          type="email"
          placeholder="Informe seu email"
          {...email}
        />
        <Input
          label="Nome"
          id="nome"
          type="text"
          placeholder="Informe o nome..."
          {...nome}
        />

        <Input
          label="Sobrenome"
          id="sobrenome"
          type="text"
          placeholder="Informe o sobrenome..."
          {...sobrenome}
        />
        <button type="submit">Enviar</button>
      </form>
    </div>
  );
};

export default App;
