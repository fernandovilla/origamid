import { createSlice } from "@reduxjs/toolkit";
import createAsyncSlice from './helper/createAsyncSlice.js';


const token = createAsyncSlice({
  name: 'token',
  fetchConfig: (payload) => ({
    url: 'https://dogsapi.origamid.dev/json/jwt-auth/v1/token',
    options: {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(payload)
    }
  })
});

console.log("token:", token);




const slice = createSlice({
  name: 'login',
  initialState: {
    token: {
      loading: false,
      data: null,
      error: null
    },
    user: {
      loading: false,
      data: null,
      error: null
    },
  },

  reducers: {
    fetchTokenStarted(state) {
      state.token.loading = true
    },
    fetchTokenSuccess(state, action) {
      state.token.loading = false;
      state.token.data = action.payload;
      state.token.error = null;
    },
    fetchTokenError(state, action) {
      state.token.loading = false;
      state.token.data = null;
      state.token.error = action.payload;
    },

    fetchUserStarted(state) {
      state.user.loading = true
    },
    fetchUserSuccess(state, action) {
      state.user.loading = false;
      state.user.data = action.payload;
      state.user.error = null;
    },
    fetchUserError(state, action) {
      state.user.loading = false;
      state.user.data = null;
      state.user.error = action.payload;
    }
  }
})

const { fetchTokenStarted, fetchTokenSuccess, fetchTokenError, fetchUserStarted, fetchUserSuccess, fetchUserError } = slice.actions;

export const fetchToken = (user) => async (dispatch) => {
  try {
    dispatch(fetchTokenStarted());
    
    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user)
    }

    const response = await fetch('https://dogsapi.origamid.dev/json/jwt-auth/v1/token', options);

    const data = await response.json();

    return dispatch(fetchTokenSuccess(data));

  } catch (error) {
    return dispatch(fetchTokenError(error.message));
  }
}

export const fetchUser = (token) => async (dispatch) => {
  try {
    dispatch(fetchUserStarted());
    
    const options = {
      method: 'GET',
      headers: {
        Authorization: `Bearer ${token}`,
      }
    }

    const response = await fetch('https://dogsapi.origamid.dev/json/api/user', options);

    const data = await response.json();

    return dispatch(fetchUserSuccess(data));

  } catch (error) {
    return dispatch(fetchUserError(error.message));
  }
}

export const login = (user) => async (dispatch) => {
  try {
    const { payload } = await dispatch(fetchToken(user));

    if (payload.token !== undefined){
      const resultUser = await dispatch(fetchUser(payload.token));
    }

  } catch (error) { }
}

export default slice.reducer;