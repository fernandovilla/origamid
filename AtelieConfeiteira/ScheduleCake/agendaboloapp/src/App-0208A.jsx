import React from 'react';

const Titulo = () => {
  return <h1>Agenda de Bolos - App - Release 1.0.0</h1>;
};

const itens = [
  { title: 'Agenda', href: 'https://www.google.com.br' },
  { title: 'Cadastros', href: 'https://www.microleme.com' },
  { title: 'Relatórios', href: 'http://www.uol.com.br' },
  { title: 'Insumos', href: '' },
];

const listaMenu = () => {
  return itens
    .filter(({ href }) => href !== '')
    .map(({ title, href }) => (
      <li key={title}>
        <a href={href}>{title}</a>
      </li>
    ));
};

const App = () => {
  return (
    <div>
      <Titulo />
      <ul>{listaMenu()}</ul>
    </div>
  );
};

export default App;
