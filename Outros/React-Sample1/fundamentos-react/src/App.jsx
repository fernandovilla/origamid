import './App.css';
import React from 'react';
import Primeiro from './components/basicos/Primeiro';
import ComParametro from './components/basicos/ComParametro';
import Card from './components/layout/Card';
import Catalogo from './components/basicos/Catalogo';
import Condicional from './components/basicos/Condicional';
import CondicionalComIF from './components/basicos/CondicionalComIF';
import Pai from './components/comunicacao/direta/Pai';
import Super from  './components/comunicacao/indireta/Super';
import Input from './components/form/Input';
import Contador from './components/contador/Contador';
import Mega from './components/megasena/Mega';

const App = (props) => {
  return (<div className="app">    
    <h1>Fundamentos em React</h1>

    <h2>Cards</h2>
    <div className="cards">      
      <Card title="#9 Component - Mega-Sena" color="#fe4a49 ">
        <Mega qtdNumeros={6} />
      </Card>

      <Card title="#8 Component - Contador" color="#293E6A">
        <Contador step={1} value={0} />
      </Card>

      <Card title="#7 Component - Input" color="#9C0F5F" >
        <Input initialValue="Fernando" />
      </Card>

      <Card title="#6 Component - Indirect Communication" color="#2ab7ca">
        <Super />
      </Card>

      <Card title="#6 Component - Direct Comunication" color="#2ab7ca ">
        <Pai sobrenome="Da Silva" />
      </Card>

      <Card title="#05 Component - Conditional com If" color="#FA6900">
        <CondicionalComIF number={4} /> 
      </Card>

      <Card title="#04 Component - Conditional" color="#FA6900">
        <Condicional number={3} />
      </Card>

      <Card title="#03 Component - Repetition" color="#E94C6F">
        <Catalogo />
      </Card>

      <Card title="#02 Component:" color="#FA6900">
        <ComParametro titulo='Element with parameter - title' subtitulo='Element with parameter - sub-title' />
      </Card>

      <Card title="#01 Component:">
        <Primeiro />
      </Card>
    </div>
  </div>);
}

export default App;