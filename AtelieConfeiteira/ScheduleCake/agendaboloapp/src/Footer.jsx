import React from 'react';

const Footer = ({ text }) => {
  if (text === undefined) text = 'Todos os direitos reservados.';

  return (
    <footer>
      <p>{text}</p>
    </footer>
  );
};

export default Footer;
