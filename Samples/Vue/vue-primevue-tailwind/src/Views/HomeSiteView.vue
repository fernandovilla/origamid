

<template>
  <div class="body bg-gray-50 text-gray-600 w-screen h-screen">

    <!-- Header: Inicio -->
    <div class="header">
      <div class="container max-w-5xl mx-auto px-4 h-24 flex items-center justify-between">
        <div class="font-black">
          Logo
        </div>

        <div>
          <ul class="flex items-center ml-auto">
            <li><a href="#" class="text-sm text-gray-600 hover:text-gray-800 hover:underline mr-2">Como reservar</a></li>
            <li><a href="#" class="text-sm text-gray-600 hover:text-gray-800 hover:underline mr-2">Sobre nós</a></li>
            <li><a href="#" class="text-sm text-gray-600 hover:text-gray-800 hover:underline mr-2">Informações</a></li>
            <li><a href="#" class="text-sm text-gray-600 hover:text-gray-800 hover:underline">Contato</a></li>
          </ul>
        </div>
      </div>
    </div>
    <!-- Header: Fim -->
    
    <!-- Banner: Inicio -->
    <div class="banner ">
      <div class="container max-w-5xl mx-auto px-4 h-full flex items-center justify-center">
        <div class="text-center">
          <div>
            <h1 class="text-gray-200 text-3xl mb-2">Onde você quer ir?</h1>
            <p class="text-green-100">Escolha o estado e cidade para achar os melhores resorts.</p>
          </div>

          <div class="mt-7">
            <form class="grid grid-cols-2 lg:grid-cols-3 gap-2" >              
              <select class="select">
                <option value="">Escolha o estado</option>
              </select>

              <select class="select">
                <option value="">Escolha a cidade</option>
              </select>

              <button class="btn col-span-2 lg:col-span-1">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 mr-2">
                  <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-5.197-5.197m0 0A7.5 7.5 0 105.196 5.196a7.5 7.5 0 0010.607 10.607z" />
                </svg>
                Pesquisar resorts
              </button>              
            </form>
          </div>

        </div>
      </div>
    </div>
    <!-- Banner: Fim -->


    <!-- Destaque: Inicio -->
    <div class="destaque">
      <div class="container max-w-5xl mx-auto px-4 py-10">
        <div class="text-sm text-gray-400 font-semibold mb-2">RESORT EM DESTAQUE</div>
        <div class="flex flex-col-reverse md:flex-row">          
          <div class="md:pr-10">            
            <div class="text-2xl">Ecoresort Praia do Forte Bahia</div>
            <div class="text-sm text-gray-400 font-semibold mt-4">Hotel qualidade 5 estrelas</div>
            <div class="text-sm text-gray-400 mt-4">
              <p class="mb-4">Lorem ipsum dolor sit amet consectetur adipisicing elit. Itaque ipsam ut recusandae voluptatum, cum ullam perspiciatis adipisci eligendi voluptas cumque, accusantium quas ipsum quia pariatur, voluptatem odit nihil fugiat velit!</p>
              <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Reiciendis, ea voluptatibus laborum quia accusamus ipsa?</p>

              <button class="btn mt-4">
                <span class="mr-2">Solicitar reserva</span>
                
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4">
                  <path stroke-linecap="round" stroke-linejoin="round" d="M13.5 4.5L21 12m0 0l-7.5 7.5M21 12H3" />
                </svg>

              </button>
            </div>
          </div>
          <div class="flex-shrink-0 lg:ml-auto">        
            <img src="../assets/resort.webp" width="450px" alt="">    
          </div>
        </div>
      </div>
    </div>
    <!-- Destaque: Fim -->


    <!-- Resorts grid: Inicio -->
    <div class="resorts">
      <div class="container max-w-5xl mx-auto px-4">
        <div>
          <h3 class="text-2xl text-gray-500 font-semibold text-center mb-8">Conheça mais resorts</h3>

          <div class="md:grid md:grid-cols-4 md:grid-rows-2 md:gap-6 md:h-[500px] space-y-4 md:space-y-0">
            <div class="relative md:col-span-2 md:row-span-2 rounded-lg overflow-hidden">
              <div class="absolute bottom-0 pl-2 pb-2 text-white text-sm z-20">Beach Park Resort</div>
              <img src="../assets/resort4.jpg" class="w-full h-full object-cover">              
            </div>

            <div class="relative md:col-span-2 rounded-lg overflow-hidden">
              <div class="absolute bottom-0 pl-2 pb-2 text-white text-sm z-20">Salinas do Maragogi Resort</div>
              <img src="../assets/resort3.jpg" class="w-full h-full object-cover">              
            </div>

            <div class="relative rounded-lg overflow-hidden">
              <div class="absolute bottom-0 pl-2 pb-2 text-white text-sm z-20">Grand Palladim</div>
              <img src="../assets/resort2.jpg" class="w-full h-full object-cover">              
            </div>

            <div class="relative rounded-lg overflow-hidden">
              <div class="absolute bottom-0 pl-2 pb-2 text-white text-sm z-20">Arraial D'Ajuda Eco Resort'</div>
              <img src="../assets/resort1.jpg" class="w-full h-full object-cover">              
            </div>
          </div>    
        </div>
      </div>
    </div>
    <!-- Resorts grid: Fim -->


    <!-- Form Search: Inicio -->
    <div class="search py-20">
      <div class="container max-w-5xl mx-auto px-4 flex items-center justify-center">
        <form class="grid grid-cols-2 md:grid-cols-3 gap-2">
          <select class="select">
            <option value="">Escolha o estado</option>
          </select>

          <select class="select">
            <option value="">Escolha a cidade</option>
          </select>

          <button class="btn col-span-2 md:col-span-1">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 mr-2">
              <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-5.197-5.197m0 0A7.5 7.5 0 105.196 5.196a7.5 7.5 0 0010.607 10.607z" />
            </svg>
            Pesquisar resorts
          </button>              
        </form>
      </div>
    </div>
    <!-- Form Search: Fim -->


    <!-- Footer: Inicio -->
    <div class="border-t border-gray-300 bg-gray-200">
      <div class="container max-w-5xl mx-auto p-4 flex items-start justify-between h-24">
        <div class="text-gray-400 font-black">
          Logo
        </div>

        <div class="flex items-center space-x-3">
          <a href="#" class="mr-2"><img src="../assets/icon-instagram.svg">XX</a>
          <a href="#"><img src="../assets/icon-facebook.svg"></a>
        </div>
      </div>
    </div>
    <!-- Footer: Fim -->

  </div>
</template>

<script>
export default {
  name: 'home-site'

}
</script>

<style scoped>
  .banner {
    background: url('~/src/assets/banner.webp');
    height: 450px;
  }
  
  .button-reserva {
    color: #7a3408;
    border: 1 solid #7a3408;
    border-radius: 4px;
    background: #fb903c;
  }
  
  .select {
    @apply bg-gray-50 px-4 py-2 border border-gray-300 rounded text-gray-500;
  }

  .btn {
    @apply bg-yellow-500 text-yellow-800 px-4 py-2 rounded inline-flex items-center justify-center;
  }
  

</style>