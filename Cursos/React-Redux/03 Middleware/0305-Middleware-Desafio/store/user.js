const USER_FETCH_STARTED = 'user/FETCH_STARTED';
const USER_FETCH_SUCCESS = 'user/FETCH_SUCCESS';
const USER_FETCH_ERROR = 'user/FETCH_ERROR';

const url = 'https://dogsapi.origamid.dev/json/api/user';


const initialState = {
  loadind: false,
  data: null,
  error: null,
};

const userFetchStarted = () => {
  return { 
    type: USER_FETCH_STARTED 
  };
}

const userFetchSuccess = (data) => {
  return { 
    type: USER_FETCH_SUCCESS, 
    payload: data,
    localStorage: 'user', 
    error: null 
  };
}

const userFetchError = (error) => {
  return { 
    type: USER_FETCH_ERROR, 
    payload: error, 
  };
}

export const userFetch = (token) => async (dispatch) => {
  try {
    dispatch(userFetchStarted());

    const options = {
      method: 'GET',
      headers: { 
        Authorization: 'Bearer ' + token,
      }
    };
    const response = await fetch(url, options);
    const data = await response.json();

    dispatch(userFetchSuccess(data));

  } catch (error) {
    dispatch(userFetchError(error.message));
  }
}

const reducer = (state = initialState, action) => {

  switch(action.type) {
    case USER_FETCH_STARTED:       
      return {...state, loading: true };

    case USER_FETCH_SUCCESS: 
      return {...state, data: action.payload, loading: false, error: null };

    case USER_FETCH_ERROR: 
      return {...state, data: null, loading: false, error: action.payload };

    default: return state;
  }
}

export default reducer;