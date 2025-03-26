import logo from './logo.svg';
import './App.css';
import Navbar from './components/layout/Navbar';
import Sidenav from './components/layout/Sidenav';
import Modal from './components/layout/Modal';

function App() {
  return (
    <div className="App">
      <Sidenav />

      <Modal modalId="inclusao-cliente" />
    </div>
  );
}

export default App;
