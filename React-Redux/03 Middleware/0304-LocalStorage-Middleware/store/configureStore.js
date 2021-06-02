import aluno from './aluno.js'
import aulas from './aulas.js'
import loading from './loading.js';
import thunk from './middlewares/thunk.js';
import localStorage from './middlewares/localStorage.js';

const reducer = Redux.combineReducers({ aluno, aulas, loading });

// Inclusão de middlewares + Redux_DevTools_Extension
const {applyMiddleware, compose} = Redux;
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const enhancer = composeEnhancers(applyMiddleware(thunk, localStorage));
const store = Redux.createStore(reducer, enhancer);

export default store;