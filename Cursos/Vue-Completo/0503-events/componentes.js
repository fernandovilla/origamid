// export default EventBus = Vue.createApp();

export const ComponenteA = {
  name: 'componente-a',
  template: `<p>Componente A</p>`
}

export const ComponenteB = {
  name: 'componente-b',
  template: `<p @click="emitirevento">Componente B</p>`,
  methods: {
    emitirevento(){
      // EventBus.$emit("meuevento");
    }
  }
}

