import React, { useCallback } from 'react';
import Checkbox from './Form/Checkbox';
import Input from './Form/Input';
import Radio from './Form/Radio';
import Select from './Form/Select';

const card = {
  width: '50vw',
  border: '2px solid gray',
  borderRadius: '4px',
  boxShadow: '2px 2px 2px rgba(0,0,0,0.4)',
  padding: '20px',
};

const App = () => {
  const [nome, setNome] = React.useState('');
  const [email, setEmail] = React.useState('');
  const [cores, setCores] = React.useState([]);
  const [produto, setProduto] = React.useState('Caderno');
  const [frutas, setFrutas] = React.useState('Abacate');
  const [linguagens, setLinguagens] = React.useState([]);
  const [termos, setTermos] = React.useState([]);

  const coresArray = ['Azul', 'Branco', 'Cinza'];
  const produtosArray = ['Caneta', 'Caderno', 'Papel A4'];
  const frutasArray = ['Abacate', 'Banana', 'Caqui'];
  const linguagensArray = ['JS', 'C#', 'Java', 'PHP'];

  return (
    <form style={card}>
      <Input id="nome" label="Nome:" value={nome} setValue={setNome} required />
      <p>{nome}</p>
      <Input id="email" label="E-mail:" value={email} setValue={setEmail} />
      <p>{email}</p>
      <Select options={coresArray} value={cores} setValue={setCores} />
      <p>{cores}</p>
      <h4>Produtos:</h4>
      <Radio options={produtosArray} value={produto} setValue={setProduto} />
      <h4>Frutas:</h4>
      <Radio options={frutasArray} value={frutas} setValue={setFrutas} />
      <h4>Checkbox:</h4>
      <Checkbox
        options={linguagensArray}
        value={linguagens}
        setValue={setLinguagens}
      />
      Value: {JSON.stringify(linguagens)}
      <h4>Termos:</h4>
      <Checkbox
        options={['Aceito os termos']}
        value={termos}
        setValue={setTermos}
      />
      <br />
      <button>Enviar</button>
    </form>
  );
};

export default App;
