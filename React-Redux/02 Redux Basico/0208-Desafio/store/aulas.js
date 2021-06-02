const COMPLETAR_AULA =  'aulas/COMPLETAR_AULA';
const COMPLETAR_CURSO = 'aulas/COMPLETAR_CURSO';
const RESETAR_CURSO = 'aulas/RESETAR_CURSO';

const initialState =  [
  { id: 1, nome: 'Design', completa: true },
  { id: 2, nome: 'HTML', completa: false },
  { id: 3, nome: 'React', completa: false },
]

export const completarAula = (aulaId) => {
  return { type: COMPLETAR_AULA, payload: aulaId };
}

export const completarCurso = () => {
  return { type: COMPLETAR_CURSO };
}

export const resetarCurso = () => {
  return { type: RESETAR_CURSO };
}

const reducer = immer.produce((state, action)=> {
  switch(action.type){
    case COMPLETAR_AULA:
      const index = state.findIndex((i) => i.id === action.payload); 
      if (!isNaN(index) && state[index]) state[index].completa = true;
      break;

    case COMPLETAR_CURSO:
      state.forEach(aula => aula.completa = true);
      break;

    case RESETAR_CURSO:
      state.forEach(aula => aula.completa = false);
      break;
  }
}, initialState);

export default reducer;