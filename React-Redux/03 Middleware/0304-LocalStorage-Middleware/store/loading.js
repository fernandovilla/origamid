const FETCH_STARTED = "FETCH_STARTED";
const FETCH_SUCCESS = 'FETCH_SUCCESS';
const FETCH_ERROR = 'FETCH_ERROR';

const getLocalStorageData = () => {
  try {
    return JSON.parse(window.localStorage.getItem('data'));
  } catch (error) {
    return null;
  }
}

const initialState = {
  loading: false,
  data: getLocalStorageData(),
  error: null,
};

export const fetchStart = () => {
  return {type: FETCH_STARTED };
}

export const fetchSuccess = (data) => {  
  return { type: FETCH_SUCCESS, payload: data, localStorage: 'data' }
};

export const fetchError = (error) => {
  return { type: FETCH_ERROR, payload: error };
}

function reducer(state = initialState, action) {
  
  switch(action.type){

    case FETCH_STARTED:
      return {...state, loading: true};
    
    case FETCH_SUCCESS:      
      return { loading: false, data: action.payload, error: null,  };

    case FETCH_ERROR:
      return { loading: false, data: null, erros: action.payload };

    default: return state;
  }
}

export default reducer;