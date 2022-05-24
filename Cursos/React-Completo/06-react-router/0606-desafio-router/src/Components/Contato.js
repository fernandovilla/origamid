import React from 'react';
import styles from './Contato.module.css';
import fotoContato from '../img/contato.jpg';
import Head from './Head';

// animeLeft não está em Contato.module.css, por isso deve ser usado em forma de string normal no className

const Contato = () => {
  return (
    <section className={`${styles.contato} animeLeft`}>
      <Head title="Contato" description="Entre em contato" />
      <img src={fotoContato} alt="Máquina de escrever" />
      <div>
        <h1>Entre em contato</h1>
        <ul className={styles.dados}>
          <li>fernando@microleme.com</li>
          <li>(19)99172-0846</li>
          <li>Rua dos Crisântemos, 455</li>
          <li>Jardim Nova Leme - Leme/SP</li>
          <li>CEP: 13612-030</li>
        </ul>
      </div>
    </section>
  );
};

export default Contato;
