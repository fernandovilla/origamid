import store from './store/configureStore.js'
import { incrementarTempo, reduzirTempo, modificarEmail } from './store/aluno.js'
import { fetchStart, fetchSuccess, fetchError } from './store/loading.js';



//const fetchURL = async (dispatch, url) => {
  const fetchUrl = (url) => {
    return async (dispatch, getState) => {

      console.log(getState());

      try {
        dispatch(fetchStart());

        const result = await fetch(url);

        if (result.ok){
          const json = await result.json();
          dispatch(fetchSuccess(json));
        }

      } catch (error) {
        console.log(error);
        dispatch(fetchError(error.message));
      }

      console.log(getState());
  }
}

//const result = await fetchURL(store.dispatch, 'https://dogsapi.origamid.dev/json/api/photo');
const result = store.dispatch(fetchUrl('https://dogsapi.origamid.dev/json/api/photo'));
