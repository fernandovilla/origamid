import logo from './logo.svg';
import './App.css';
import Conversor from './Components/Conversor';

function App() {
  return (
    <div className="App">      
    <h1>Conversor de Moedas</h1>
      <div className="linha">
        <Conversor moedaA="USD" moedaB="BRL" />
        <Conversor moedaA="BRL" moedaB="USD" />
      </div>
      <div className="linha">
        <Conversor moedaA="CAD" moedaB="BRL" />
        <Conversor moedaA="BRL" moedaB="CAD" />
      </div>
      <div className="linha">
        <Conversor moedaA="EUR" moedaB="BRL" />
        <Conversor moedaA="BRL" moedaB="EUR" />
      </div>
    </div>
  );
}

export default App;
