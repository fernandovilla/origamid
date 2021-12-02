import { createSlice } from '@reduxjs/toolkit'

const slice = createSlice({
  name: 'contador',
  initialState: { total: 0},
  reducers: {
    incrementar(state) { state.total++ },
    decrementar(state) { return { total: state.total - 1} },
  }
})

export const { incrementar, decrementar } = slice.actions;
export default slice.reducer;


//import { createAction, createSlice } from '@reduxjs/toolkit'
//
// export const incrementar = createAction('INCREMENTAR');
// export const decrementar = createAction('DECREMENTAR');
//
// const reducer = (state = 0, action) => {
//   switch (action.type){
//     case incrementar.type:
//       console.log("incrementando...");
//       return state + 1;
//     case decrementar.type:
//       console.log("decrementando...");
//       return state - 1;
//     default: 
//       return state;
//   }
// };
//
//export default reducer;