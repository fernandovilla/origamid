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
          {Array.from(Array(25).keys()).map((i) => (
            <p
              style={{
                margin: '0',
                padding: '0',
              }}
            >
              Lorem ipsum dolor sit amet consectetur, adipisicing elit.
            </p>
          ))}
        </div>
      </section>
    </div>
  );
};

export default Layout;
