import React from 'react';
import './App.css';
import luaJPG from './img/lua.jpg';
import luaSVG from './img/lua.svg';
import { ReactComponent as DogSVG1 } from './img/dog.svg';
import DogSvg from './DogSvg';

const App = () => {
  const [olho, setOlho] = React.useState(20);

  function abreOlho() {
    setOlho(30);
  }

  function fechaOlho() {
    setOlho(20);
  }

  return (
    <div>
      <section className="avatar" onMouseOver>
        <p className="avatar-img"></p>
        <p className="avatar-nome">Dog</p>
      </section>
      <section>
        <DogSVG1 style={{ width: '50px', height: '50px' }} />
        <DogSvg
          style={{ width: '70px', height: '70px' }}
          color="tomato"
          olho={olho}
          onMouseOver={abreOlho}
          onMouseOut={fechaOlho}
        />
      </section>
      <img src={luaJPG} alt="Foto lua jpg" />
      <img src={luaSVG} style={{ width: '50px' }} alt="Foto lua svg" />
    </div>
  );
};

export default App;
