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

  const handleChange = async ({ target }) => {
    setRadio(target.id);
  };

  return (
    <div>
      <h1>0402 - TextArea, 0403 - Select, 0404 - Radio, 0405 - Checkbox</h1>
      <textarea
        value={textarea}
        onChange={({ target }) => setTextarea(target.value)}
        rows="2"
      />

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
      <p>Select: {select}</p>

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
      <p>Radio: {radio}</p>

      <label>
        <input
          type="checkbox"
          value="termos"
          checked={checkbox}
          onChange={({ target }) => setCheckbox(target.checked)}
        />
        Li e aceito os termos do contrato
      </label>
      <p>{checkbox ? 'True' : 'False'}</p>
    </div>
  );
};

export default App;
