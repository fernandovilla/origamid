import { combineReducers, configureStore, getDefaultMiddleware } from '@reduxjs/toolkit';
import contador from './contador.js';
import modal from './modal.js';
import login from './login.js';
//import logger from './middleware/logger.js';


//const middlewaresJaExistentes = getDefaultMiddleware();
//const middleware = [...getDefaultMiddleware(), logger ];
const middleware = [...getDefaultMiddleware()];

const reducer = combineReducers({ contador, modal, login });
const store = configureStore({ reducer, middleware });

export default store;