import React from 'react'
import { Container, Navegation, DropboxLogo, Form } from './styles';

const MenuForm: React.FC = () => {

  const handleToggle =() => {
    if (window.toggleActiveMenu) 
      window.toggleActiveMenu();
  }

  return (
    <Container>
      <Navegation>
        <h1>
          <DropboxLogo />
          <span>Dropbox</span>
        </h1>

        <button className='action--close' onClick={handleToggle}>✖</button>
      </Navegation>

      <Form>
        <span className="title">Registre-se</span>
        <span className="subtitle">preencha o formulário abaixo</span>
        <input type="text"  placeholder='Nome'/>
        <input type="text"  placeholder='Sobrenome'/>
        <input type="email"  placeholder='E-mail'/>
        <input type="password"  placeholder='Password'/>

        <button>Prosseguir</button>

        <span className='terms'>
          Esta página está sugeita à política de privacidade e aos termos de serviço.
        </span>
      </Form>

    </Container>
  )
}

export default MenuForm