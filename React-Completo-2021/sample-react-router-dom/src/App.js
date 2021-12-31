import './App.css';
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import Page1 from './Pages/Page1';
import Page2 from './Pages/Page2';
import Page3 from './Pages/Page3';

function App() {
  return (
    <BrowserRouter>
      <div className="App">      
        <nav>
          <ul className='menu'>
            <li><Link to="/">Page 1</Link></li>
            <li><Link to="/page2">Page 2</Link></li>
            <li><Link to="/page3">Page 3</Link></li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<Page1 />} />
          <Route path="/page2" element={<Page2 />} />
          <Route path="/page3" element={<Page3 />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
