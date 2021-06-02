const localStorage = (store) => (next) => (action) => {

  // Por padrão e boa prática, executar a ação, antes dos efeitos colaterais...
  const result = next(action);

  if (action.localStorage !== undefined) {
    console.log(action);
    window.localStorage.setItem(action.localStorage, JSON.stringify(action.payload));
  }

  return result;
}

export default localStorage;