import React from 'react'
import { Button } from './style'
import Logo from '../../assets/logo-discord.svg';

export interface Props {
  selected ?: boolean;
  isHome ?: boolean;
  hasNotifications ?: boolean;
  mentions ?: number;
}

const ServerButton: React.FC<Props> = ({selected, isHome, hasNotifications, mentions}) => {
  return (
    <Button 
      isHome={isHome} 
      hasNotifications={hasNotifications} 
      mentions={mentions} 
      className={selected ? 'active' : ''}>
      {isHome && <img src={Logo} alt='Discord'/>}
    </Button>)
}

export default ServerButton