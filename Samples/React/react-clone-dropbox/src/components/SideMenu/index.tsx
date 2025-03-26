import React from 'react'
import { Container } from './styles'

interface Props {
  children: JSX.Element[] | JSX.Element
}

declare global {
  interface Window { 
    toggleActiveMenu: (() => void) | undefined;
  }
}

const scrollThreshold = 300;

const SideMenu: React.FC<Props> = ( {children} ) => {
  const [scrollY, setScrollY] = React.useState(0);
  const [isActive, setIsActive] = React.useState(false);

  React.useEffect(() => {
    const onScroll = () => {
      setScrollY(window.scrollY);
      setIsActive(false);
    };

    window.addEventListener('scroll', onScroll);

    return () => window.removeEventListener('scroll', onScroll);
  },[]);

  const toggleActiveMenu = () => {
    setIsActive(prev => !prev); /* inverte o valor do useState */
  }

  window.toggleActiveMenu = toggleActiveMenu;

  const classes = [
    isActive ? 'open': '', 
    scrollY <= scrollThreshold ? 'scrollOpen': ''
  ]

  return (
    <Container className={classes.join(' ').trim()}>{children}</Container>)
}

export default SideMenu