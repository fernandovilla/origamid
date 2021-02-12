import React from 'react';

const useFetch = () => {
  const [data, setData] = React.useState(null);
  const [error, setError] = React.useState(null);
  const [loading, setLoading] = React.useState(null);

  const request = React.useCallback(async (url, options) => {
    setError(null);
    setLoading(true);

    let response;
    let json;

    try {
      response = await fetch(url, options);
      json = await response.json();
    } catch (err) {
      setError(err);
      json = null;
    } finally {
      setLoading(false);
      setData(json);
      return { response, json };
    }
  }, []);

  return { data, error, loading, request };
};

export default useFetch;
