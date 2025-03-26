import React from 'react';
import Main from '../Main/Index';

import { Container, Wrapper } from './styles'


const Layout = () => {
  return (
    <Container>
      <Wrapper>
        {/* <ManuBar /> */}
        <Main />
        {/* <SideBar /> */}
      </Wrapper>
    </Container>
  );
}

export default Layout;