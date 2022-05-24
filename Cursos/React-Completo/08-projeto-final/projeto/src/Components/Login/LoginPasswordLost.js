import React from 'react';
import Input from '../Forms/Input';
import Button from '../Forms/Button';
import useForm from '../../Hooks/useForm';
import useFetch from '../../Hooks/useFetch';
import { PASSWORD_LOST } from '../../Api';
import Error from '../Helper/Error';
import Head from '../Helper/Head';

const LoginPasswordLost = () => {
  const login = useForm();
  const { data, loading, request, error } = useFetch();

  async function handleSubmit(event) {
    event.preventDefault();

    if (!login.validate()) return;

    const { url, options } = PASSWORD_LOST({
      login: login.value,
      url: `${window.origin}/login/resetar`,
    });
    await request(url, options);
  }

  return (
    <section className="animeLeft">
      <Head title="Perdeu a senha" />
      <h1 className="title">Perdeu a senha?</h1>

      {data ? (
        <p style={{ color: '#4c1' }}>E-mail enviado</p>
      ) : (
        <form onSubmit={handleSubmit}>
          <Input label="E-mail / Usuário" type="text" name="login" {...login} />
          {loading ? (
            <Button disabled>Enviando...</Button>
          ) : (
            <Button>Enviar E-mail</Button>
          )}
        </form>
      )}
      <Error error={error} />
    </section>
  );
};

export default LoginPasswordLost;
