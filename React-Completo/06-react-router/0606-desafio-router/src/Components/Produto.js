import React from 'react';
import styles from './Produto.module.css';
import { useParams } from 'react-router-dom';
import Head from './Head';

const Produto = (props) => {
  const { id } = useParams();
  const [produto, setProduto] = React.useState(null);
  const [loading, setLoading] = React.useState(false);
  const [error, setError] = React.useState(null);

  React.useEffect(() => {
    async function fetchProduto(url) {
      setError(null);
      setLoading(true);
      try {
        const resp = await fetch(url);
        const json = await resp.json();
        setProduto(json);
      } catch (err) {
        setError('Ocorreu erro ao carregar o produto');
      } finally {
        setLoading(false);
      }
    }

    fetchProduto('https://ranekapi.origamid.dev/json/api/produto/' + id);
  }, [id]);

  if (loading) return <Loading />;
  if (error) return <Error error={error} />;
  if (produto === null) return <ProdutoNaoEncontrado />;

  return <ProdutoDados produto={produto} />;
};

const ProdutoDados = ({ produto }) => {
  return (
    <section className={styles.produto + ' animeLeft'}>
      <Head
        title={produto.nome}
        description={`Esse é o produto ${produto.nome}`}
      />
      <div>
        {produto.fotos.map((foto) => (
          <img key={foto.src} src={foto.src} alt={foto.titulo} />
        ))}
      </div>

      <div>
        <h1>{produto.nome}</h1>
        <span className={styles.preco}>R$ {produto.preco}</span>
        <p className={styles.descricao}>{produto.descricao}</p>
      </div>
    </section>
  );
};

const Error = ({ error }) => {
  return (
    <div>
      <p style={{ color: 'red' }}>Ocorreu erro: {error}</p>
    </div>
  );
};

const Loading = () => {
  return <div className="loading"></div>;
};

const ProdutoNaoEncontrado = () => {
  return (
    <div>
      <h1>Produto não encontrado</h1>
    </div>
  );
};

export default Produto;
