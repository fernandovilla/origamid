import store from './store/configureStore.js'
import { incrementarTempo, reduzirTempo, modificarEmail } from './store/aluno.js'

console.log(store.getState());

store.dispatch(incrementarTempo());
store.dispatch(incrementarTempo());
store.dispatch(incrementarTempo());
store.dispatch(incrementarTempo());
store.dispatch(reduzirTempo());
store.dispatch(incrementarTempo());
store.dispatch(incrementarTempo());
store.dispatch(modificarEmail('fernando@gmail.com'));