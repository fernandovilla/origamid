import React from 'react'
import { Container, Separator } from './style';
import ServerButton from '../ServerButton/Index';

const ServerList: React.FC = () => {
  return (
    <Container>
      <ServerButton isHome mentions={5} />
      <Separator />
      <ServerButton />
      <ServerButton hasNotifications />
      <ServerButton mentions={3} />
      <ServerButton />
      <ServerButton />
      <ServerButton hasNotifications />
      <ServerButton />
      <ServerButton mentions={72} />
      <ServerButton />
      <ServerButton />
      <ServerButton />
    </Container>
  )
}

export default ServerList;