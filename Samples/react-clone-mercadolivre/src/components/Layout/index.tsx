import React from 'react'
import Product from '../Product/Index'
import { Container, Header, Wrapper, Footer } from './style'

const Layout: React.FC = () => {
  return (
    <Container>
      <Header />
      <Wrapper>
        <Product />        
      </Wrapper>

      <Footer />
    </Container>
  )
}

export default Layout