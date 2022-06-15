const ComponentLocal = {
  name: 'component-local',
  data(){ return {
      mensagem: "Local"
  }},
  template: `<p>{{mensagem}}</p>`
}

const Titulo = {
  name: 'titulo',
  template: `<h1>Título</h1>`
}

const ComponentGlobal = {
  name: 'component-global',
  data() { return { 
    mensagem: "Global"
  }},
  template: `
    <div>
      <p>{{mensagem}}</p>
      <titulo></titulo>
    </div>`
}

const ButtonCounter =  {
  name:  'button-counter',
  data() { return { count: 0 }},
  template: `<button @click="count++">Counter: {{count}}</button>`
}

const ButtonCounter2 =  {
  name:  'button-counter2',
  data() { return { count: 0 }},
  methods: {
    contar(){
      this.count++;
    }
  },
  template: `<button @click="contar">Counter 2: {{count}}</button>`
}


// Cria uma aplicação Vue
const app = Vue.createApp({
  data(){
    return {
      mensagem: 'Rodou o component?'
    }
  },
  components: {
    Titulo,
    ComponentLocal,
    ComponentGlobal,
    ButtonCounter,
    ButtonCounter2
    
  }
})



// app.component('componente-global', {
//   template: `<p>Isso é um component global</p>`
// })

// // Define um novo componente global chamado button-counter
// app.component('button-counter', {
//   data() {
//     return {
//       count: 0
//     }
//   },
//   template: `
//     <button v-on:click="count++">
//       Você me clicou {{ count }} vezes.
//     </button>`
// })

app.mount('#app');