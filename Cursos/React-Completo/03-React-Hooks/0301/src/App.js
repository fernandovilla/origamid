import React from 'react';
import ButtonModal from './ButtonModal';
import Modal from './Modal';

const Sample1 = () => {
  // Define o valor de 'ativo' manualmente...
  let ativo = true;
  return <button disabled={!ativo}>{ativo ? 'Ativo' : 'Inativo'}</button>;
};

const Sample2 = () => {
  // Define o valor de ativo através de Hook
  const ativoHook = React.useState(true);
  const currentValue = ativoHook[0];
  const atualizarValor = ativoHook[1];

  function handleClick() {
    atualizarValor(!currentValue);
  }

  return (
    <button onClick={handleClick}>{currentValue ? 'Ativo' : 'Inativo'}</button>
  );
};

// Atualiza um objeto com hook
const Sample3 = () => {
  // Define o valor de ativo através de Hook, desestruturando o array de Hook
  const [ativo, setAtivo] = React.useState(true);
  const [cliente, setCliente] = React.useState({ nome: '', email: '' });

  function handleClick() {
    setAtivo(!ativo);
    setCliente({ nome: 'Fernando Villa', email: 'fermvilla@gmail.com' });
  }

  return (
    <div>
      <p>{cliente.nome}</p>
      <p>{cliente.email}</p>
      <button onClick={handleClick}>{ativo ? 'Ativo' : 'Inativo'}</button>
    </div>
  );
};

// Passando o hook para outro componente através das propriedades do componente
const Sample4 = () => {
  const [modal, setModal] = React.useState(false);
  return (
    <div>
      <p>{modal ? 'Modal Aberto' : 'Modal Fechado'}</p>
      <Modal modal={modal} setModal={setModal} />
      <ButtonModal setModal={setModal} />
    </div>
  );
};

// Atualização de arrays com o hook
const Sample5 = () => {
  const [items, setItems] = React.useState(['Item 0']);

  function handleClick() {
    const newItem = `Item ${items.length}`;
    setItems([...items, newItem]);
  }

  function clearItems() {
    setItems([]);
  }

  return (
    <div>
      <p>
        <button onClick={handleClick}>Add item</button>
      </p>
      <p>
        <button onClick={clearItems}>Clear</button>
      </p>

      <p>{items}</p>
    </div>
  );
};

const Sample6 = () => {
  const [count, setCount] = React.useState(1);
  const [items, setItems] = React.useState(['Item 1']);

  function handleClick() {
    setCount(count + 1);
    setItems([...items, `Item ${count + 1}`]);
  }

  return (
    <div>
      <button onClick={handleClick}>{count}</button>
      {items.map((item) => (
        <li key={item}>{item}</li>
      ))}
    </div>
  );
};

const App = () => {
  return Sample6();
};

export default App;
