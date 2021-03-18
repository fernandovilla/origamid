import React from 'react';
import styles from './Embalagens.module.css';

const Embalagens = (props) => {

  if (props.embalagens == null)
    return (      
      <div className={`${props.col} component-container`}>
        <h6>Embalagens</h6>
        <p>Nenhuma embalagem cadastrada</p>
      </div>
      );

  return <div className={`${props.col} component-container`} >
    <table>
      <thead>
      <tr>
        <th>EAN</th>
        <th>Frac.</th>
        <th>Un. Medida</th>
        <th>Dimensões</th>
      </tr>
      </thead>
      <tbody>
        <tr>
          <td>789123456</td>
          <td>10</td>
          <td>Caixa</td>
          <td>Alt: Larg: Prof:</td>
        </tr>
      </tbody>
    </table>
  </div>
}

export default Embalagens;