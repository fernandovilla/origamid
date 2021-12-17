import React from 'react'
import useFetch from '../../Hooks/useFetch';

export const useIngredientes = () => {
  const { request, data, loading, error } = useFetch();
  const baseURL = 'http://localhost:42916';
  
  const cadastrarIngrediente = React.useCallback(async (ingrediente) => {    
    const url = baseURL + '/ingredientes';

    const options = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json;charset=utf-8' },
      body: JSON.stringify(ingrediente),
    };

    try {
      const { response, json } = await request(url, options);

      if (response !== undefined && response.ok && error === null) {        
        return { status: response.status, message: response.message, data: json }
      } else {    
        return { status: response.status, message: response.message, error };
      }

    } catch(ex) {
      return null;
    }

  }, []);

  const listarIngredientes = React.useCallback(async () => {
    const url = baseURL + '/ingredientes';

    const options = {
      method: 'GET',
      headers: { 'Content-Type': 'application/json;chaset=utf-8'}
    }

    try {
      const { response, json } = await request(url, options);

      if (response !== undefined && response.ok && error === null){        
        return { status: response.status, message: response.message, data: json };
      } else {        
        return { status: response.status, message: response.message, error };
      }

    } catch(ex) {
      return null;
    }
  }, []);



  return { cadastrarIngrediente, listarIngredientes };
}
