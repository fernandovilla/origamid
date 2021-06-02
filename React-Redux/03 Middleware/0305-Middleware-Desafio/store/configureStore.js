
const { createStore, applyMiddleware, compose, combineReducers } = Redux;

// Middlewares...
import thunk from './middlewares/thunk.js';
import localStorage from './middlewares/localStorage.js';

// Reducers...
import token from './token.js';
//import user from './user.js';


const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const enhancer = composeEnhancers(applyMiddleware(thunk, localStorage));
const reducer = combineReducers({ token });
const store = Redux.createStore(reducer, enhancer);

export default store;