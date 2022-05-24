import styled from 'styled-components'
import { FaDropbox } from 'react-icons/fa'


export const Container = styled.div`
  display: flex;
  flex-direction: column;
  height: 100%;

  @media (min-width: 1024px) {
    max-width: 480px;    
  }
`;

export const Navegation = styled.nav`
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 16px 32px;
  min-height: 62px;

  > h1 {
    display: flex;
    align-items: center;
  }

  > span {
    color: var(--color-quaternary);
    margin-left: 10px;
    font-size: 29px;
  }

  > button {
    background: none;
    border: none;
    cursor: pointer;
    font-weight: bold;
    font-size: 17px;
    outline: none;
  }

  @media (min-width: 1024px){
    justify-content: flex-end;  /* oculta o logo e posiciona o X à direita */

    > h1 {
      display: none;
    }
  }
`;

export const DropboxLogo = styled(FaDropbox)`
  width: 36px;
  height: 32px;
  fill: var(--color-blue);
`;

export const Form = styled.form`
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding: 0 32px;
  max-width: 480px;
  margin: 0 auto;

  > .title {
    font-size: 25px;
    font-weight: 500;
  }
  > .subtitle {   
    font-size: 12px;
    margin-top: 3px;
  }
  > input {
    background: var(--color-tertiary);
    border: 1px solid var(--color-border);
    font-size: 18px;
    padding: 13px;
    margin-top: 18px;
  }
  > button {
    margin-top: 18px;
    padding: 13px 18px;
    font-size: 16px;
    background: var(--color-blue);
    color: var(--color-tertiary);
    border: none;
    cursor: pointer;

    &:hover {
      opacity: 0.87;
    }
  }
  > .terms {
    font-size: 12px;
    opacity: 0.6;
    margin-top: 4px;
  }
`;