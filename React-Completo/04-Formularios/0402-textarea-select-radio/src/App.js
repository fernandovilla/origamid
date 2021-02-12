import React from 'react';

const defaultStyle = {
  width: '40vw',
  border: '1px solid lightgray',
  borderRadius: '5px',
  boxShadow: '2px 2px 2px rgba(0,0,0,0.3)',
  margin: '15px 0px',
  padding: '10px',
};

const TextArea = () => {
  const [textarea, setTextarea] = React.useState('');

  function handleChangeTextArea({ target }) {
    setTextarea(target.value);
  }

  return (
    <section style={defaultStyle}>
      <label htmlFor="textarea">Texto:</label>
      <textarea
        id="textarea"
        value={textarea}
        onChange={handleChangeTextArea}
        rows="5"
      ></textarea>
      <p>Value: {textarea}</p>
    </section>
  );
};

const Select = () => {
  const [select, setSelect] = React.useState(''); // Estado inicial do select

  function handleChangeSelect({ target }) {
    setSelect(target.value);
  }

  return (
    <section style={defaultStyle}>
      <label htmlFor="select">Opções:</label>
      <select id="select" value={select} onChange={handleChangeSelect}>
        <option disabled value="">
          Selecione:
        </option>
        <option value="0">Notebook</option>
        <option value="1">Smartphone</option>
        <option value="2">Tablet</option>
      </select>
      <p>Value: {select}</p>
    </section>
  );
};

const Radio = () => {
  const [produto, setProduto] = React.useState('1');

  function handleChange({ target }) {
    setProduto(target.value);
  }

  return (
    <section style={defaultStyle}>
      <label>
        <input
          type="radio"
          name="produto"
          value="0"
          onChange={handleChange}
          checked={produto === '0'}
        />
        Notebook
      </label>
      <label>
        <input
          type="radio"
          name="produto"
          value="1"
          onChange={handleChange}
          checked={produto === '1'}
        />
        Smartphone
      </label>
      <p>Checked: {produto}</p>
    </section>
  );
};

const CheckboxUnico = () => {
  const [termos, setTermos] = React.useState(true);

  return (
    <div>
      <section style={defaultStyle}>
        <label>
          <input
            type="checkbox"
            value="Termos"
            checked={termos}
            onChange={({ target }) => setTermos(target.checked)}
          />
          Aceito os termos do site.
        </label>
        Value: {termos ? 'true' : 'false'}
      </section>
    </div>
  );
};

const CheckboxMultiplo = () => {
  const [cores, setCores] = React.useState(['azul', 'verde']);
  const coresArray = ['azul', 'roxo', 'laranja', 'verde', 'vermelho', 'cinza'];

  function handleChange({ target }) {
    if (target.checked) {
      // adiciona a cor marcada no array
      setCores([...cores, target.value]);
    } else {
      // .filter() retorna um novo array sem a cor desmarcada
      setCores(cores.filter((cor) => cor !== target.value));
    }
  }

  function checkColor(cor) {
    return cores.includes(cor);
  }

  return (
    <div>
      <section style={defaultStyle}>
        {coresArray.map((cor, index) => (
          <label key={index} style={{ textTransform: 'capitalize' }}>
            <input
              type="checkbox"
              value={cor}
              onChange={handleChange}
              checked={checkColor(cor)}
            />
            {cor}
          </label>
        ))}
        <p>Value: {JSON.stringify(cores)}</p>
      </section>
    </div>
  );
};

const App = () => {
  return (
    <div>
      <TextArea />
      <Select />
      <Radio />
      <CheckboxUnico />
      <CheckboxMultiplo />
    </div>
  );
};

export default App;
