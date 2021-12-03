const logger = (store) => (next) => (action) => {
  console.group(action.type);
  console.log('ACTION: ', action);
  console.log("PREV_STATE: ", store.getState());
  const nextState = next(action);
  console.log('NEW_STATE: ', store.getState());
  console.groupEnd();
  
  return nextState;
}

export default logger;