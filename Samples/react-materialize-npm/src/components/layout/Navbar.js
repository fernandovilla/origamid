import React from 'react';

const Navbar = () => {
  return (
    <nav>
      <div className="nav-wrapper grey darken-3">
        <div className="container">
          <a href="/" className="brand-logo">
            Logo
          </a>
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li>
              <a href="sass.html">Sass</a>
            </li>
            <li>
              <a href="badges.html">Components</a>
            </li>
            <li>
              <a href="collapsible.html">JavaScript</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
