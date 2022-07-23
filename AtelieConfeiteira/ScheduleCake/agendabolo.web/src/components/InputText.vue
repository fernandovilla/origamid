<template>
  <span class="wrap">
    <label :for="id">{{display}}</label>
    <input type="text" :name="id" :id="id" v-model="text" :required='this.required !== undefined' >
  </span>
</template>

<script>

export default {
  name: 'input-text',
  data() { 
    return {
      text: ''
  }},  
  props: [ 'id', 'display', 'uppercase', 'required' ],
  computed: {
    textValue(){
      if (this.uppercase !== undefined )
        return this.text.toUpperCase();
      else
        return this.text;
    }
  },watch: {
    text(){
      this.$emit('update:modelValue', this.textValue);
    }
  }
}
</script>

<style scoped>
  .wrap {
    display: flex;
    flex-direction: column;
  }

  label, input {
    width: 100%;
    text-align: start;
    font-size: 0.85rem;
  }

  input {
    border: none;
    border-bottom: 1px solid #8c8f94;
    /* border-radius: 4px; */
    padding: 5px;
    text-transform: uppercase;
    transition: border-bottom 0.2s;    
    outline: none;
  }

  input:active, input:focus {
    border-bottom: 1px solid #2271b1;
    background: #f2f2f2;
  }

</style>