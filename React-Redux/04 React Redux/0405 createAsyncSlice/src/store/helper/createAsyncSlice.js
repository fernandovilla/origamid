import {createSlice} from '@reduxjs/toolkit'

const createAsyncSlice = (config) => {
  const slice = createSlice({
    name: config.name,
    initialState: {
      loading: false,
      data: null,
      error: null,
      ...config.initialState,     /** DESESTRUTURA E ADICIONA NOVAS PROPRIEDADES **/
    },
    reducers: {
      fetchStarded(state){
        state.loading = true;
      },
      fetchSuccess(state, action){
        state.loading = false;
        state.data = action.payload;
        state.error = null;
      },
      fetchError(state, action){
        state.loading = false;
        state.data = null;
        state.error = action.payload;
      },
      ...config.reducers,
    }
  });

  const { fetchStarded, fetchSuccess, fetchError } = slice.actions;
  
  const asyncAction = (payload) => async(dispatch) => {
    try {
      dispatch(fetchStarded());

      const { url, options } = config.fetchConfig(payload);

      const response = await fetch(url, options);

      const data = await response.json();

      return dispatch(fetchSuccess(data));

    } catch (error) {
      dispatch(fetchError(error.message));
    }
  }

  return {...slice, asyncAction };
};

export default createAsyncSlice;