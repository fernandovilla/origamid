import React from 'react';
import Pergunta from './Form/Pergunta';

const perguntas = [
  {
    id: 'p1',
    pergunta: 'Qual método é utilizado para criar componentes?',
    options: [
      'React.makeComponent()',
      'React.createComponent()',
      'React.createElement()',
    ],
    resposta: 'React.createElement()',
  },
  {
    id: 'p2',
    pergunta: 'Como importamos um componente externo?',
    options: [
      'import Component from "./Component"',
      'require("./Component")',
      'import "./Component"',
    ],
    resposta: 'import Component from "./Component"',
  },
  {
    id: 'p3',
    pergunta: 'Qual hook não é nativo?',
    options: ['useEffec()', 'useFetch()', 'useCallback()'],
    resposta: 'useFetch()',
  },
  {
    id: 'p4',
    pergunta: 'Qual prefixo deve ser utilizado para criarmos um hook?',
    options: ['set', 'get', 'use'],
    resposta: 'use',
  },
];

const App = () => {
  const [slide, setSlide] = React.useState(0);
  const [resultado, setResultado] = React.useState(null);
  const [respostas, setRespostas] = React.useState({
    p1: '',
    p2: '',
    p3: '',
    p4: '',
  });

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  const handleChange = ({ target }) => {
    setRespostas({ ...respostas, [target.id]: target.value });
  };

  const handleClick = () => {
    if (slide < perguntas.length - 1) {
      setSlide(slide + 1);
    } else {
      setSlide(10); // Para sumir com a pergunta...
      calculaResultado();
    }
  };

  const calculaResultado = () => {
    console.log('Resultado...');
    const corretas = perguntas.filter(
      ({ id, resposta }) => respostas[id] === resposta,
    );
    console.log('Calculando resutado...');
    setResultado(`Você acertou ${corretas.length} de ${perguntas.length}`);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        {perguntas.map((pergunta, index) => (
          <Pergunta
            id={pergunta.id}
            pergunta={pergunta}
            key={pergunta.id}
            onChange={handleChange}
            value={respostas[pergunta.id]}
            active={slide === index}
          />
        ))}
        {resultado ? (
          <p>{resultado}</p>
        ) : (
          <button onClick={handleClick}>Próxima</button>
        )}
      </form>
    </div>
  );
};

export default App;
