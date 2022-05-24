import { combineReducers, configureStore, getDefaultMiddleware } from '@reduxjs/toolkit';
import contador from './contador.js';
import modal from './modal.js';
import logger from './middleware/logger.js';


//const middlewaresJaExistentes = getDefaultMiddleware();
const middleware = [...getDefaultMiddleware(), logger ];

const reducer = combineReducers({ contador, modal });
const store = configureStore({ reducer, middleware });

export default store;