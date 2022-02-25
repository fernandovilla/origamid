import styled from "styled-components";

import { Props } from './Index';

export const Button = styled.button<Props>`
  display: flex;
  align-items: center;
  justify-content: center;
  flex-shrink: 0;
  width: 48px;
  height: 48px;
  margin-bottom: 8px;
  cursor: pointer;
  background-color: ${props => props.isHome ? 'var(--discord)' : 'var(--primary)'};
  position: relative;  /*necessário para funcionar a bolinha de notificações*/
  border-radius: ${props => props.isHome ? '25%' : '50%'};

  > img {
    width: 30px;
    height: 30px;
  }

  &::before {
    content: '';
    display: ${props => props.hasNotifications ? 'inline' : 'none' };

    width: 9px;
    height: 9px;
    background-color: var(--white);
    border-radius: 50%;
    position: absolute; /* só funciona se o pai é 'position: relative' */  
    left: -17px;
    top: calc(50% - 4.5px);
  }

  &::after {    
    content: '${props => props.mentions && props.mentions}';
    display: ${props => props.mentions ? 'inline' : 'none' };
    background-color: var(--notification);
    width: auto;
    height: 16px;
    padding: 0 4px;
    position: absolute;
    bottom: -4px;
    right: -4px;
    border-radius: 10px;
    border: 4px solid var(--quaternary);
    text-align: right;
    font-size: 13px;
    font-weight: bold;
    color: var(--white);    
  }

  transition: border-radius .3s, background-color .3s;

  &.active, &:hover {
    border-radius: 25%;
    background-color: ${props => props.isHome ? 'var(--discord)' : 'var(--discord-secondary)'}
  }
`;