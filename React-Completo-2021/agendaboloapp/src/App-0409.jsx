import React from 'react';
import Checkbox from './Form/Checkbox3';
import Input from './Form/Input3';
import Radio from './Form/Radio3';
import Select from './Form/Select3';

const options = [
  { display: 'Smartphone', value: '0' },
  { display: 'Notebook', value: '1' },
  { display: 'Tablet', value: '2' },
];

const App = () => {
  const [nome, setNome] = React.useState('');
  const [produto, setProduto] = React.useState('');
  const [prod2, setProd2] = React.useState('1');
  const [prod3, setProd3] = React.useState([]);

  return (
    <div>
      <h1>0406|0407|0408|0409 - Custom Controls</h1>
      <form>
        <h2>Input:</h2>
        <Input id="nome" label="Nome" value={nome} setValue={setNome} />

        <h2>Select:</h2>
        <Select
          id="info"
          label="Produtos:"
          options={options}
          select="true"
          value={produto}
          setValue={setProduto}
        />
        {produto}

        <h2>Radio:</h2>
        <Radio
          options={options}
          name="prods"
          value={prod2}
          setValue={setProd2}
        />
        {prod2}

        <h2>Checkbox:</h2>
        <Checkbox options={options} value={prod3} setValue={setProd3} />
        {JSON.stringify(prod3)}

        <p>
          <button type="submit">Enviar</button>
        </p>
      </form>
    </div>
  );
};

export default App;
