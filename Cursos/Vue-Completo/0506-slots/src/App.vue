<template>
  <div id="app">
    <modal-principal title="Busca de Clientes">        
        <form class="form-compra">
          <label for="nome">Nome do Cliente</label>
          <input type="text" id="nome">
          <button>Incluir</button>
        </form>
        
        <template v-slot:footer="{ user }">
          <footer class="footer">
            <p>Informe os dados do cliente...</p>
            <p>{{user}}</p>
          </footer>          
        </template>
    </modal-principal>
  </div>  
</template>

<script>
import ModalPrincipal from './components/ModalPrincipal.vue'

export default {
  name: 'App',  
  components: {
    ModalPrincipal
  }
}
</script>

<style>
  p {
    margin: 0px;
    padding: 10px 0;
  }

  .form-compra {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    padding: 10px 0px;    
  }
  
  .form-compra label {
    font-size: 0.85rem;
  }

  .form-compra input {
    border-radius: 0;
    border: none;
    border-bottom: 1px solid #999;
    margin-bottom: 10px;
  }


  .footer p {
    font-size: 0.7rem;
    font-style: italic;
    padding: 5px;    
  }
</style>
