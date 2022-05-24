import React from 'react';
import styled from 'styled-components';

/*
  Exemplo utilizando 'styled-components'
  1. npm install styled-components;
  2. instalar o plugin do vscode: styled-components;
*/

const ProdutosContainer = styled.div`
  display: flex;
  border: 1px solid gray;
  border-radius: 4px;
  padding: 10px;
`;

const Produto = styled.div`
  flex: 1;
`;

/* background: hsl(${Math.random() * 360 */
const Preco = styled.p`
  width: 100px;
  height: 20px;
  margin: 10px;
  background: ${(props) => props.background};
  color: white;
  border-radius: 3px;
  padding: 5px;
  text-align: center;
`;

const Title = styled.h1`
  font-size: 2rem;
  color: tomato;
`;

const Paragrafo = styled.p`
  font-size: 1.3rem;
  color: green;
`;

const Comprar = styled.button`
  background: ${(props) => (props.ativo ? 'green' : 'gray')};
  color: white;
  border: 1px solid rgba(0, 0, 0, 0.1);
  border-radius: 3px;
  padding: 10px 20px;
  text-align: center;
  text-transform: uppercase;
  margin: 10px 0px;
  cursor: pointer;
  &:hover {
    border: 1px dashed orange;
  }
`;

const App = () => {
  const [ativo, setAtivo] = React.useState(false);

  function handleClick() {
    setAtivo(!ativo);
  }

  return (
    <>
      <Title>Hello world with styled-components</Title>
      <Comprar ativo={ativo} onClick={handleClick}>
        Comprar
      </Comprar>

      <ProdutosContainer>
        <Produto>
          <Paragrafo>Smartphone</Paragrafo>
          <Preco background="#53d956">R$ 1.500,00</Preco>
        </Produto>
        <Produto>
          <Paragrafo>Notebook</Paragrafo>
          <Preco background="gray">R$ 4.500,00</Preco>
        </Produto>
        <Produto>
          <Paragrafo>Tablet</Paragrafo>
          <Preco background="gray">R$ 1.450,00</Preco>
        </Produto>
      </ProdutosContainer>
    </>
  );
};

export default App;
