import React from 'react'
import { Container, Title, LocationCard, LocationIcon, ReputationCard, ReputationTermometer, ReputationRow, SuportIcon, ClockIcon, More } from '../SellerInfo/style';

const SellerInfo = () => {
  return (
    <Container>
      <Title>Informações sobre o vendedor</Title>
      <LocationCard>
        <LocationIcon />
        <div>
          <p>Localização</p>
          <strong>São Paulo, SP</strong>
        </div>
      </LocationCard>
      <ReputationCard>
        <ReputationTermometer>
          <li />
          <li />
          <li />
          <li />
          <li className='active' />          
        </ReputationTermometer>
        <ReputationRow>
          <div>
            <strong>561</strong>
            <span>Vendas nos últimos 4 meses</span>
          </div>

          <div>
            <strong><SuportIcon /></strong>
            <span>Presta um bom atendimento</span>
          </div>

          <div>
            <strong><ClockIcon /></strong>
            <span>Entrega rápida</span>
          </div>
        </ReputationRow>
      </ReputationCard>

      <More href="#">Ver mais informações do vendedor</More>
    </Container>
  )
}

export default SellerInfo