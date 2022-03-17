import React from 'react'
import { Container, Condition, Row, HeartIcon, DispatchTag, PriceCard, PriceRow, InstallmentsInfo, StockStatus, MethodCard, CheckIcon, Actions, Button, Benefits, ShildIcon  } from './style';

const ProductAction: React.FC = () => {
  return (
    <Container>
      <Condition>Novo | 9 vendidos</Condition>
      <Row>
        <h1>Camiseta Branca de Marca Desconhecida</h1>
        <HeartIcon />
      </Row>

      <DispatchTag>Enviando Normalmente</DispatchTag>

      <PriceCard>
        <PriceRow>
          <span className='symbol'>R$</span>
          <span className='fraction'>34</span>
          <span className='cents'>,99</span>
        </PriceRow>

        <InstallmentsInfo>em 3x de R$ 11,67</InstallmentsInfo>
      </PriceCard>

      <StockStatus>Estoque disponível</StockStatus>

      <MethodCard>
        <CheckIcon />
        <div>
          <span className="title">Frete gratís</span>
          <span className="details">Benefício ML</span>
          <a href="#" className="more">Ver mais opções</a>
        </div>
      </MethodCard>

      <Actions>
        <Button solid>Comprar Agora</Button>
        <Button>Adicionar ao carrinho</Button>
      </Actions>

      <Benefits>
        <li>
          <ShildIcon />
          <p>Compra garantida, receba o produto que está esperando ou devolvemos o dinheiro</p>
        </li>

      </Benefits>

    </Container>
  )
}

export default ProductAction