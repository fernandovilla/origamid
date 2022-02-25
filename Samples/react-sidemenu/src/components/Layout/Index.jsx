import React from 'react';
import './style.css';
import Sidemenu from '../Sidemenu/Index';
import Navtop from '../Navtop/Index';

const Layout = () => {
  return (
    <div className="layout">
      <Sidemenu />
      <section className="main">
        <Navtop />
        <div className="sub-main">
          <p>submain</p>
        </div>
      </section>
    </div>
  );
};

export default Layout;
