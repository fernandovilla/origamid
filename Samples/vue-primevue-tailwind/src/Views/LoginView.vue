<template>
  <div class="w-screen h-screen bg-gray-100 flex items-center justify-center">
    <div class="w-80">
      <h2 class="font-bold text-lg text-center mb-4">Login</h2>

      <div class="bg-white shadow-md rounded-lg p-6 space-y-4">

        <div>
          <label for="email" class="block text-sm text-gray-800 mb-2">E-mail</label>
          <input-text id="email" />
        </div>

        <div>
          <label for="password" class="block text-sm text-gray-800 mb-2">Senha</label>
          <input-text id="password" type="password" />
        </div>

        <div class="text-right">          
          <a href="#" class="text-sm text-gray-500 hover:underline">Esqueci minha senha</a>          
        </div>

        <div class="">
          <button-view buttonType="primary" text="Login" class="w-full m-0"/>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
import InputText from '@/components/InputText.vue';
import ButtonView from '@/components/ButtonView.vue';


export default {
  name: 'login-view',
  components: {
    InputText, ButtonView
  }
}
</script>

<style>

</style>