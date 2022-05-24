import React from 'react';
import { Link } from 'react-router-dom';
import Head from './Head';
import styles from './Produtos.module.css';

const Produtos = () => {
  const [produtos, setProdutos] = React.useState(null);

  React.useEffect(async () => {
    const resp = await fetch('https://ranekapi.origamid.dev/json/api/produto');
    const json = await resp.json();

    setProdutos(json);
  }, []); /* Array vazia como dependencia para que seja carregado ao iniciar e não quando mudar o array */

  if (produtos === null)
    return (
      <div>
        <h1>Nenhum Produto</h1>
      </div>
    );

  return (
    <section className={styles.produtos + ' animeLeft'}>
      <Head title="Produtos" description="Esses são os produtos disponíveis" />
      {produtos.map((prod) => (
        <Link key={prod.id} to={`produto/${prod.id}`}>
          <h1>{prod.nome}</h1>
          <img src={prod.fotos[0].src} alt={prod.fotos[0].titulo} />
        </Link>
      ))}
    </section>
  );
};

export default Produtos;
