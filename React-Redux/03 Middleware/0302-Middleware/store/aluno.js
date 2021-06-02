const BASE = 'aluno';
const INCREMENTAR_TEMPO = `${BASE}/INCREMENTAR_TEMPO`;
const REDUZIR_TEMPO = `${BASE}/REDUZIR_TEMPO`;
const MODIFICAR_EMAIL = `${BASE}/MODIFICAR_EMAIL`;

const initialState = {
  nome: 'Fernando Villa',
  email: 'fermvilla@gmail.com',
  tempoAcesso: 120 
}

export const incrementarTempo = () => {
  return {type: INCREMENTAR_TEMPO };
}

export const reduzirTempo = () => {
  return { type: REDUZIR_TEMPO };
}

export const modificarEmail = (email) => {
  return { type: MODIFICAR_EMAIL, payload: email };
}

const reducer = immer.produce((state, action)=> {
  switch(action.type){
    case INCREMENTAR_TEMPO:       
      state.tempoAcesso++;
      break;

    case REDUZIR_TEMPO: 
      state.tempoAcesso--;
      break;

    case MODIFICAR_EMAIL: 
      state.email = action.payload;
      break;
  }
}, initialState);

export default reducer;