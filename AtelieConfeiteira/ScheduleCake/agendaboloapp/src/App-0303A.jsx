import React from 'react';

const App = () => {
  const [input, setInput] = React.useState('');
  const [comentarios, setComentarios] = React.useState([]);
  const inputElement = React.useRef();

  React.useEffect(() => {}, []);

  // const handleClick = () => {
  //   if (input !== '') {
  //     setComentarios([...comentarios, input]);
  //     setInput('');
  //     inputElement.current.focus();
  //     console.log(inputElement.current);
  //   }
  // };

  const handleSubmit = (event) => {
    event.preventDefault();

    if (input !== '') {
      setComentarios([...comentarios, input]);
      setInput('');
      inputElement.current.focus();
      console.log(inputElement.current);
    }
  };

  return (
    <div>
      <h1>Comentários</h1>
      <div
        style={{
          border: '1px solid black',
          borderRadius: '10px',
          margin: '20px 0px',
        }}
      >
        <ul>
          {comentarios.map((comentario, index) => (
            <li key={index}>{comentario}</li>
          ))}
        </ul>
      </div>

      <form action="" onSubmit={handleSubmit}>
        <label htmlFor="coment">Adicione seu comentário</label>
        <section style={{ display: 'inline-flex' }}>
          <input
            id="coment"
            type="text"
            value={input}
            onChange={(event) => setInput(event.target.value)}
            ref={inputElement}
          />
          <button type="submit" style={{ margin: '0px 2px' }}>
            Enviar Comentário
          </button>
        </section>
      </form>
    </div>
  );
};

export default App;
