import React from 'react';

const types = {
  cep: {
    regex: /^\d{5}-?\d{3}$/,
    messageError: 'CEP inválido',
  },
  email: {
    regex: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    messageError: 'E-mail inválido',
  },
};

const useForm = (type) => {
  const [value, setValue] = React.useState('');
  const [error, setError] = React.useState(null);

  function validate(value) {
    value = value.trim();

    if (type === false) return true;

    if (value.length === 0) {
      setError(types[type].messageError);
      return false;
    }

    const validacao = types[type] && types[type].regex.test(value);
    if (!validacao) {
      setError(types[type].messageError);
      return false;
    }

    setError(null);
    return true;
  }

  function onChange({ target }) {
    if (error) validate(target.value);
    setValue(target.value);
  }

  return {
    value,
    setValue,
    error,
    onChange,
    onBlur: () => validate(value),
    validate: () => validate(value),
  };
};

export default useForm;
