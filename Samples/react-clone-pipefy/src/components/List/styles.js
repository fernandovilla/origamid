import styled from 'styled-components';
import { MdAdd } from 'react-icons/md';

export const Container = styled.div`
  padding: 0 15px;
  height: 100%;
  flex: 0 0 320px;
  /* flex-grow: 0; -> define como os elementos vão crescer, 0 elemento não cresce, 1 o elemento cresce com a tela
    flex-shrink: 0; -> define como os elementos vão reduzir, 0 não reduz, 1 reduz junto com a tela
    flex-basis: 320px -> define a largura base do elemento, respeita o flex-direction do pai
  */

  & + div {
    border-left: 1px solid rgba(0, 0, 0, 0.05);
  }

  header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 42px;

    h2 {
      font-weight: bold;
      font-size: 16px;
      padding: 0 10px;
    }
    button {
      width: 32px;
      height: 32px;
      border: none;
      border-radius: 12px;
      background: #3b5bfb;
      cursor: pointer;
    }
  }

  ul {
    margin-top: 30px;
  }

  opacity: ${(props) => (props.done ? 0.6 : 1)};
`;

export const AddIcon = styled(MdAdd)`
  height: 24px;
  width: 24px;
  color: #fff;
`;
