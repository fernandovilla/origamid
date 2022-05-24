import React from 'react';

// Uso do useRef
// React.useRef pode ser utilizado para a referência de qq valor, objeto ou elemento

// Uso do 'useRef' para setar um input
const Sample1 = () => {
  const [comentarios, setComentarios] = React.useState([]);
  const [input, setInput] = React.useState('');
  const inputElement = React.useRef();

  function handleChange(event) {
    const value = event.target.value;
    setInput(value);
  }

  function handleClick() {
    setComentarios([...comentarios, input]);
    setInput('');
    inputElement.current.focus(); // mantém o foco no elemento definido
  }

  return (
    <div>
      <ul>
        {comentarios.map((comentario, index) => (
          <li key={index}>{comentario}</li>
        ))}
      </ul>
      <br />

      <div>
        <input
          type="text"
          value={input}
          onChange={handleChange}
          ref={inputElement}
        />
        <br />
        <button onClick={handleClick}>Enviar</button>
      </div>
    </div>
  );
};

const Sample2 = () => {
  const [cart, setCart] = React.useState(0);
  const [notificacao, setNotificacao] = React.useState(null);
  const timeoutRef = React.useRef();

  function handleClick() {
    setCart(cart + 1);
    setNotificacao('Item add in the cart');

    // Limpa a referencia acumulada para não bugar a tela...
    clearTimeout(timeoutRef.current);

    // Limpa as notificações após 3 segundos
    timeoutRef.current = setTimeout(() => {
      setNotificacao(null);
    }, 2000);
  }

  return (
    <div>
      <button onClick={handleClick}>Add cart: {cart}</button>{' '}
      <p>{notificacao}</p>
    </div>
  );
};

const App = () => {
  return Sample2();
};

export default App;
