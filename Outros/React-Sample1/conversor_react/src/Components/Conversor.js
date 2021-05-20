import React from 'react';
import styles from './Conversor.module.css';

const Conversor = ({moedaA, moedaB}) => {
  
  const [moedas, setMoedas] = React.useState({moedaA_valor: '', moedaB_valor: 0});

  const converter = async (event) => {
    let de_para = `${moedaA}_${moedaB}`;
    let url = `https://free.currconv.com/api/v7/convert?q=${de_para}&compact=ultra&apiKey=bd250157843e5eb45f88`
    
    const result = await fetch(url);

    

    if (result.ok){
      const json = await result.json();
      const cotacao = parseFloat(json[de_para]);
      const moedaA = parseFloat(moedas.moedaA_valor);

      console.log(cotacao);
      console.log(moedaA);

      let moedaB_convertida = moedaA * cotacao;
      console.log(moedaB_convertida);

      setMoedas({moedaB_valor: moedaB_convertida})      
    }
  };

  return (
    <div className={styles.conversor}>
      <h2>{moedaA} para {moedaB}</h2>
      <input type="text" onChange={(event) => setMoedas({moedaA_valor: event.target.value, moedaB_valor: 0})} />      
      <input type="button" onClick={converter} />
      <h2>Valor Convertido: {moedas.moedaB_valor.toFixed(2)}</h2>

    </div>
  );
};

export default Conversor;