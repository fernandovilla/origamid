import styled from "styled-components";

/*
  SL - Server List
  SN - Server Name
  CI - Channel Info
  CL - Channel List
  CD - Channel Data
  UL - User List
*/

export const Grid = styled.div`
  display: grid;
  grid-template-columns: 71px 240px auto 240px;   /* Largura das colunas */
  grid-template-rows: 46px auto 52px;             /* Altura das linhas */
  grid-template-areas: 
    'SL SN CI CI'
    'SL CL CD UL'
    'SL UI CD UL';
  height: 100vh;
`;