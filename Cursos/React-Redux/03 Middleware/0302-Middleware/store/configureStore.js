import aluno from './aluno.js'
import aulas from './aulas.js'

const reducer = Redux.combineReducers({ aluno, aulas });


//const store = Redux.createStore(reducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

const loggerMiddleware = (store) => (next) => (action) => {
  
  console.group(action.type);
    console.log('ACTION.......: ', action);
    console.log('PREV_STATE...: ', store.getState());
    const result = next(action);
    console.log('NEW_STATE....: ', store.getState());
  console.groupEnd();

  return result;
}

const reduzirMiddleware = (store) => (next) => (action) => {
  if (action.type === "aluno/REDUZIR_TEMPO") console.log("REDUZINHO...");
  return next(action);
}

// Inclusão de middlewares + Redux_DevTools_Extension
const {applyMiddleware, compose} = Redux;
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const enhancer = composeEnhancers(applyMiddleware(loggerMiddleware, reduzirMiddleware));
const store = Redux.createStore(reducer, enhancer);

//const middleware = applyMiddleware(logger);
//const store = Redux.createStore(reducer, middleware);

export default store;