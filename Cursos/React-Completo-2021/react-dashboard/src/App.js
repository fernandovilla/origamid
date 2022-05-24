import './App.css';
import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import SideMenu from './components/SideMenu';
import Dashboard from './Dashboard'
import Design from './Design'
import Courses from './Courses'
import Videos from './Videos'

// https://www.youtube.com/watch?v=99hJdy-mj5I

function App() {
  const [inactiveMenu, setInactiveMenu] = React.useState(false);

  return (
    <BrowserRouter>
      <div className="App">              
          <SideMenu onCollapse={(inactive) => {
            setInactiveMenu(inactive);
          }} />

          <div className={`container ${inactiveMenu ? "inactive" : ""}`}>            
            <Routes>
              <Route path={'/'} element={<Dashboard />} />                          
              <Route path={'/content/courses'} element={<Courses />} />            
              <Route path={'/content/videos'} element={<Videos />} />
              <Route path={'/design'} element={<Design />} />
            </Routes> 
          </div>                 
      </div>
    </BrowserRouter>
  );
}

export default App;
