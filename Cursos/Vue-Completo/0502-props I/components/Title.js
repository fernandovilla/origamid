export default {
  name: 'titulo',
  props: {
    text: { type: String, required: true },
    itens: { type: Number, default: 0 }
  },
  template: `<h1>{{text}} | Itens: {{itens}}</h1>`
}