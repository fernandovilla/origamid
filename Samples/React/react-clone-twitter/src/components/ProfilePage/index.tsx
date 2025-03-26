import React from 'react'
import {Container,Banner,Avatar, ProfileData, LocationIcon, CakeIcon, Followage} from './styles';

export const ProfilePage = () => {
  return (
    <Container>
      <Banner>
        <Avatar />
      </Banner>

      <ProfileData>
        {/* <EditButton outlined>Editar perfil</EditButton> */}
        <h1>Fernando Villa</h1>
        <h2>@fernandovilla123</h2>
        <p>
          Confeiteiro at <a href="#">@ateliedaconfeiteiraoficial</a>
        </p>

        <ul>
          <li>
            <LocationIcon />
            Leme, SP, Brasil
          </li>
          <li>
            <CakeIcon />
            Nascido(a) em 2 de Junho de 1983
          </li>
        </ul>

      <Followage>
        <span>seguindo <strong> 94</strong></span>
        <span><strong>675 </strong> seguidores</span>
      </Followage>

      </ProfileData>

    </Container>
  )
}
