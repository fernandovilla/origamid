import React from 'react'
import { Container, Row, Panel, Column, Galery , Description, Section} from '../Product/style'
import tshirtImage from '../../assets/tshirt.png';
import SellerInfo from '../SellerInfo/Index';
import ProductAction from '../ProductAction';

const Product = () => {
  return (
    <Container>
      <Row>
        <a href="#">Compartilhar</a>
        <a href="#">Vender um igual</a>
      </Row>
      <Panel>
        <Column>
          <Galery>
            <img src={tshirtImage} alt="t-shirt" />
          </Galery>

          <Info />
        </Column>

        <Column>
          <ProductAction />
          <SellerInfo />
          <WarrantySection></WarrantySection>
          <WarrantySection></WarrantySection>
          <WarrantySection></WarrantySection>
        </Column>
      </Panel>
    </Container>
  )
}

const WarrantySection = () => {
  return (<Section>
    <h4>Garantia</h4>
    <div>
      <span>
        <p className='title'>Compra garantida com o ML</p>
        <p className='description'>Receba o produto que está comprando ou devolvemos o ser dinheiro</p>
      </span>
      <span>
        <p className='title'>Garantida do vendedor</p>
        <p className='description'>Sem garantia</p>
      </span>
    </div>

    <a href="#">Saiba mais sobre garantia</a>
  </Section>)
}

const Info = () => {
  return (
    <Description>
      <h2>Descrição do Produto</h2>
      <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quos totam tempora magni adipisci quibusdam doloribus vel porro ratione ea? Magnam temporibus facere nulla exercitationem repudiandae nisi a recusandae odit hic porro iste illo, ut debitis ad magni, voluptate ipsa corporis impedit velit quibusdam eum accusamus!
      <br />
      <br />
      Itens Inclusos: <br />
      - 1x LED <br />
      - 1x LED <br />
      - 1x LED <br />
      - 1x LED <br />
      - 1x LED <br />
      <br />
      Lorem ipsum dolor sit amet consectetur adipisicing elit. Corrupti tempore libero reprehenderit incidunt neque nulla illo eveniet nisi molestias sapiente at quidem mollitia tenetur architecto quibusdam, voluptatem pariatur nobis officia earum numquam ipsa quisquam. Facilis quo inventore molestias ad impedit.
      </p>
    </Description>);
}

export default Product