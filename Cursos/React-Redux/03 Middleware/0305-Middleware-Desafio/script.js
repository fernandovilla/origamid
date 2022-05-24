import store from './store/configureStore.js'
// import { incrementarTempo, reduzirTempo, modificarEmail } from './store/aluno.js'
// import { fetchStart, fetchSuccess, fetchError } from './store/loading.js'
import { tokenFetch } from './store/token.js';
import { userFetch } from './store/user.js';


//const fetchURL = async (dispatch, url) => {
const fetchUrl = (url) => {
  return async (dispatch, getState) => {

    try {
      dispatch(fetchStart());

      const result = await fetch(url);

      if (result.ok){
        const json = await result.json();
        dispatch(fetchSuccess(json));
      }
    } catch (error) {
      // console.log(error);
      dispatch(fetchError(error.message));
    }      
  }
}

const obterPhotos = () => {
  //const result = await fetchURL(store.dispatch, 'https://dogsapi.origamid.dev/json/api/photo');

  // Garante q só vai fazer o fetch caso os dados ainda não tenham sido carregados no localstorage
  const state = store.getState();
  if (state.data === null) {
    const result = store.dispatch(fetchUrl('https://dogsapi.origamid.dev/json/api/photo'));
  }
}

const obterToken = async () => {

  let state = store.getState();

  if (state.token.data === null) {
    await store.dispatch(tokenFetch({username: 'dog', password: 'dog'}));
    state = store.getState();
  }
  
  await store.dispatch(userFetch(state.token.data));
}

await obterToken();

