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
  const [respostas, setRespostas] = React.useState({
    p1: '',
    p2: '',
    p3: '',
    p4: '',
  });

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log('respondeu...');
  };

  const handleChange = ({ target }) => {
    //setRespostas({...respostas, [target.id]})
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        {perguntas.map((pergunta) => (
          <Pergunta
            pergunta={pergunta}
            key={pergunta.id}
            onChange={handleChange}
            value={respostas[pergunta.id]}
          />
        ))}

        <button type="submit">Próxima</button>
      </form>
    </div>
  );
};

export default App;
