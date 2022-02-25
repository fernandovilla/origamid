import React from "react";
import { Container, Role, User, Avatar } from "./style";

interface UserProps {
  nickname: string;
  isBot ?: boolean;
}

const UserRow: React.FC<UserProps> = ({nickname, isBot}) => {
  return (
    <User>
      <Avatar className={isBot ? 'bot': ''} />
      <strong>{nickname}</strong>
      {isBot && <span >BOT</span>}
    </User>
  )
}

const UserList: React.FC = () => {
  return (
  <Container>
      <Role>Disponível - 1</Role>
      <UserRow nickname="Fernando Villa" />

      <Role>Offline - 18</Role>
      <UserRow nickname="Diego Fernandez" isBot />
      <UserRow nickname="Fulano" isBot />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Beltrano" isBot />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
      <UserRow nickname="Fulano"  />
  </Container>)
}

export default UserList;