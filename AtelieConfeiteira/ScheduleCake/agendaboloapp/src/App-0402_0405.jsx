import React from 'react';

const produtos = [
  { id: '1', nome: 'Notebook' },
  { id: '2', nome: 'Smartphone' },
  { id: '3', nome: 'Table' },
];

const App = () => {
  const [textarea, setTextarea] = React.useState('');
  const [select, setSelect] = React.useState('');
  const [radio, setRadio] = React.useState('2');
  const [checkbox, setCheckbox] = React.useState(false);
  const [multcheckbox, setMultcheckbox] = React.useState(['2']);

  const handleChange = async ({ target }) => {
    setRadio(target.id);
  };

  const handleChangeMultCheckbox = async ({ target }) => {
    if (target.checked) {
      setMultcheckbox([...multcheckbox, target.value]);
    } else {
      setMultcheckbox(multcheckbox.filter((i) => i !== target.value));
    }
  };

  const checkAtivo = (value) => {
    return multcheckbox.includes(value);
  };

  return (
    <div>
      <h1>0402 - TextArea, 0403 - Select, 0404 - Radio, 0405 - Checkbox</h1>
      <textarea
        value={textarea}
        onChange={({ target }) => setTextarea(target.value)}
        rows="2"
      />

      <h3>Select:</h3>
      <select
        id="produtos"
        value={select}
        onChange={({ target }) => setSelect(target.value)}
      >
        <option disabled value="">
          Selecione
        </option>
        {produtos.map((prod, index) => (
          <option key={prod.id} value={prod.id}>
            {prod.nome}
          </option>
        ))}
      </select>
      <p>Value: {select}</p>

      <h3>Multiplos Radio:</h3>
      {produtos.map((prod, index) => (
        <label key={index}>
          <input
            name="produtos"
            id={prod.id}
            type="radio"
            onChange={handleChange}
            checked={radio === prod.id}
          />
          {prod.nome}
        </label>
      ))}
      <p>Value: {radio}</p>

      <h3>Checkbox:</h3>
      <label>
        <input
          type="checkbox"
          value="termos"
          checked={checkbox}
          onChange={({ target }) => setCheckbox(target.checked)}
        />
        Li e aceito os termos do contrato
      </label>
      <p>Value: {checkbox ? 'True' : 'False'}</p>

      <h3>Multiplos Checkbox:</h3>
      {produtos.map((prod, index) => (
        <label key={index}>
          <input
            id={prod.id}
            type="checkbox"
            value={prod.id}
            onChange={handleChangeMultCheckbox}
            checked={checkAtivo(prod.id)}
          />
          {prod.nome}
        </label>
      ))}
      <p>Value: {JSON.stringify(multcheckbox)}</p>
    </div>
  );
};

export default App;
