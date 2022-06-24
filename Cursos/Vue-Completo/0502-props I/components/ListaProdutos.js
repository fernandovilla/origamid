import titulo from './Title.js'

const item = {
  name:'item',
  props: ["produto"],
  template: `<li>{{produto}}</li>`
}

export default {
  data() { return { }},
  props: ["produtos", "titulo"],
  components: {
    titulo,
    item
  },
  template: `<div>
      <titulo :text="titulo" :itens="produtos.length"></titulo>
      <ul>            
        <item v-for="prod in produtos" :produto="prod" :key="prod"></item>
      </ul>
    </div>`
}