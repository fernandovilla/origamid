import React from 'react';
import Button from './Button';
import Contador from './Contador';
import Header from './Header';
import Produtos from './Produtos';
import ReducerArray from './ReducerArray';
//import Contato from './Contato';
const Contato = React.lazy(() => import('./Contato'));

const Loading = () => {
  return <div>Carregando...</div>;
};

const App = () => {
  const [ativo, setAtivo] = React.useState(false);

  return (
    <div>
      <Header />
      <Button margin="10px" onClick={() => setAtivo(!ativo)}>
        Clique aqui
      </Button>
      {ativo && (
        <React.Suspense fallback={<Loading />}>
          <Contato />
        </React.Suspense>
      )}
      <Contador />
      <ReducerArray />
      <Produtos titulo="Produtos" />
    </div>
  );
};

export default App;
