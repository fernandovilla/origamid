import React from 'react';
import Input from './Form/Input3';

const App = () => {
  const [nome, setNome] = React.useState('');
  const [email, setEmail] = React.useState('');

  return (
    <div>
      <h1>0406 - Formulários</h1>
      <form>
        <Input id="nome" label="Nome" value={nome} setValue={setNome} />
        <Input
          id="email"
          label="Email"
          value={email}
          setValue={setEmail}
          required
        />
        <button type="submit">Enviar</button>
      </form>
    </div>
  );
};

export default App;
