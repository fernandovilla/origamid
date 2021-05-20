import './App.css';
import React from 'react';
import Primeiro from './components/Primeiro';
import ComParametro from './components/ComParametro';
import Card from './components/layout/Card';
import Catalogo from './components/Catalogo';
import Condicional from './components/Condicional';
import CondicionalComIF from './components/CondicionalComIF';

const App = (props) => {
  return (<div className="App">    
    <Card title="First Component:">
      <Primeiro />
    </Card>

    <Card title="Second Component:">
      <ComParametro titulo='Element with parameter - title' subtitulo='Element with parameter - sub-title' />
    </Card>

    <Card title="Tirth Component - Repetition">
      <Catalogo />
    </Card>

    <Card title="Forth Component - Conditional">
      <Condicional number={3} />
    </Card>

    <Card title="Fifth Component - Conditional com If">
      <CondicionalComIF number={4} /> 
    </Card>

  </div>);
}

export default App;