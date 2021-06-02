import getLocalStorage from './helper/getLocalStorage.js';

const TOKEN_FETCH_STARTED = 'token/FETCH_STARTED';
const TOKEN_FETCH_SUCCESS = 'token/FETCH_SUCCESS';
const TOKEN_FETCH_ERROR = 'token/FETCH_ERROR';
const url = 'https://dogsapi.origamid.dev/json/jwt-auth/v1/token';


const initialState = {
  loadind: false,
  data: getLocalStorage('token', null),
  error: null,
};

const tokenFetchStarted = () => {
  return { 
    type: TOKEN_FETCH_STARTED 
  };
}

const tokenFetchSuccess = (token) => {
  return { 
    type: TOKEN_FETCH_SUCCESS, 
    payload: token,
    localStorage: 'token', 
    error: null 
  };
}

const tokenFetchError = (error) => {
  return { 
    type: TOKEN_FETCH_ERROR, 
    payload: error, 
  };
}

export const tokenFetch = (user) => async (dispatch) => {
  try {
    dispatch(tokenFetchStarted());

    const options = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(user)
    };
    const response = await fetch(url, options);
    const { token } = await response.json();

    dispatch(tokenFetchSuccess(token));

  } catch (error) {
    dispatch(tokenFetchError(error.message));
  }
}

const reducer = (state = initialState, action) => {

  switch(action.type) {
    case TOKEN_FETCH_STARTED:       
      return {...state, loading: true };

    case TOKEN_FETCH_SUCCESS: 
      return {...state, data: action.payload, loading: false, error: null };

    case TOKEN_FETCH_ERROR: 
      return {...state, data: null, loading: false, error: action.payload };

    default: return state;
  }
}

export default reducer;