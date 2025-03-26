<template>
  <div class="home bg-gray-100">

    <div class="col1 w-1/2">

      <div class="sample">
        <h1 class="title" >Sample #1 | Font-Size Sample:</h1>
        <h2 class="text-sm text-gray-500">text-sm + text-gray-500</h2>
        <h2 class="text-base text-red-800">text-base + text-red-800</h2>
        <h2 class="text-lg text-yellow-400">text-xl + text-yellow-400</h2>
        <h2 class="text-xl">text extra-large</h2>
        <h2 class="text-2xl tracking-widest">text-2xl + tracking-widest</h2>
        <h2 class="text-3xl font-black">text-3xl + font-black</h2>
      </div>      

      <div class="sample">
        <h1 class="title">Sample 32 | Text-Alighn Sample:</h1>
        <p class="text-right">(text-right) Lorem ipsum dolor sit, amet consectetur adipisicing elit. Deleniti, repudiandae!</p>
        <p class="text-center">(text-center) Lorem ipsum dolor sit, amet consectetur adipisicing elit. Deleniti, repudiandae!</p>
      </div>

      <div class="sample">
        <h1 class="title">Sample #3 | Espaçamentos, Border</h1>

        <button class="bg-green-400 text-white px-4 py-2 rounded ring-green-300 hover:ring-2">Save</button>

        <p class="p-4 mb-5 mt-5 border-l-4 border-red-400">(p-4 + mb-10) Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sit, iste. Vitae ab in, consequuntur consectetur dolorum similique beatae doloribus. Esse qui natus autem, accusantium iste optio laborum sunt quibusdam quod voluptatibus.</p>

        <p class="px-8 border-2 border-green-400 rounded-full" >(px-8) Lorem ipsum dolor sit amet consectetur adipisicing elit. Inventore dolor explicabo tempora quis. Veniam obcaecati eveniet iure sapiente rem reprehenderit natus. Quibusdam ad voluptatem totam?</p>

        <p class="py-10" style="border: 1px solid blue">(py-10) Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eaque, impedit autem. Dicta assumenda aut aperiam similique minus? Porro reprehenderit dolorum itaque, nobis sint maiores doloribus ducimus fugiat eius beatae.</p>
        
        <p class="pl-20 mt-5" style="border: 1px solid red">(pl-20 + mt-5) Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eaque, impedit autem. Dicta assumenda aut aperiam similique minus? Porro reprehenderit dolorum itaque, nobis sint maiores doloribus ducimus fugiat eius beatae.</p>

        <p class="pr-20 pt-10 ml-5" style="border: 1px solid cyan">(pr-20 + pt-10 + ml-5) Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eaque, impedit autem. Dicta assumenda aut aperiam similique minus? Porro reprehenderit dolorum itaque, nobis sint maiores doloribus ducimus fugiat eius beatae.</p>

        <div class="space-x-20 mt-5" style="background: gray;">
          <span style="border: 1px solid lime">#1</span>
          <span style="border: 1px solid lime">#2</span>
          <span style="border: 1px solid lime">#3</span>
        </div>

        
      </div>

      <div class="sample">
        <h1 class="sample-title">Sample #4 | Background, largura e altura</h1>

        <div style="display: flex">
          <div class="m-1 p-4 bg-gray-400">
            <p>bg-gray-400</p>
          </div>
          <div class="m-1 p-4 bg-green-400">
            <p>bg-green-400</p>
          </div>

          <div class="w-40 m-1 p-4 bg-blue-800 bg-opacity-20">
            <p>bg-blue-800</p>
            <p>bg-opacity-20</p>
          </div>

          <div class="w-60 m-1 p-4 bg-gradient-to-r from-yellow-400 via-red-500 to-pink-500 text-white">
            <p>bg-gradient-to-r</p>
            <p>from-yellow-400</p>
            <p>via-red-500</p>
            <p>to-pink-500</p>
          </div>
        </div>
      </div>

      <div class="sample">
        <h1 class="title">Sample #5 | Flexbox</h1>

        <div class="flex justify-end items-center space-x-10 bg-gray-200 h-40 p-4">
          <div class="w-24 h-24 m-1 p-4 bg-gray-400">#1</div>
          <div class="w-24 h-24 m-1 p-4 bg-gray-400">#2</div>
          <div class="w-24 h-24 m-1 p-4 bg-gray-400">#3</div>
        </div>

        <div class="flex justify-end items-center space-x-10 bg-gray-200 h-40 p-4 mt-4">
          <div class="w-24 h-24 m-1 p-4 bg-gray-400">#1</div>
          <div class="flex-grow flex-shrink-0 h-24 m-1 p-4 bg-gray-400">#2</div>
          <div class="w-24 h-24 m-1 p-4 bg-gray-400">#3</div>
        </div>
      </div>

      <div class="sample">
        <h1 class="title">Sample #6 | Grid</h1>

        <div class="bg-gray-200 p-4 grid grid-cols-3 gap-2">
          <div class="col-span-2 p-4 bg-gray-400">#1</div>
          <div class="p-4 bg-gray-400">#2</div>
          <div class="p-4 bg-gray-400">#3</div>
          <div class="p-4 bg-gray-400">#4</div>
          <div class="p-4 bg-gray-400">#5</div>
          <div class="col-span-3 p-4 bg-gray-400">#6</div>                    
        </div>
      </div>

      <div class="sample">
        <h1 class="title">Sample #7 | Breakpoints</h1>        
        <div class="sm:text-small md:text-xl lg:text-2xl  p-4 bg-gray-400">#Breakpoint</div>                  
      </div>
      
    </div>

    <div class="col2 w-1/2">
      
      <div class="sample">
        <h1 class="title">Sample #8 | States: hover, focus, others</h1>

        <div class="flex gap-2">
          <div class="text-xl hover:bg-gray-300 hover:underline hover:cursor-pointer rounded-lg p-4">Lorem ipsum dolor sit amet.</div>          

          <div class="w-72 bg-gray-300 p-4 border rounded-md group">
              <h1 class="font-bold text-lg group-hover:text-blue-300">Titulo do Card</h1>
              <p class="text-gray-500 text-sm">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Voluptatibus, laborum.</p>
          </div>
          
          <div class="flex flex-col bg-gray-300 p-4 border rounded-md">
            <label for="codigo">Código</label>
            <input id="codigo" type="text" value="19" class="p-1 focus:text-blue-400 px-2 py-1">
          </div>
        </div>
      </div>

      <div class="sample">
        <h1 class="title">Sample #9 | Customizando tailwind.css | styles.css</h1>

        <div class="container2">
          <div>#1</div>
          <div>#2</div>
          <div>#3</div>
          <div>#4</div>
        </div>
      </div>

      <div class="sample bg-gray-200">
        <h1 class="title">#Sample 10 | Card, Buttons, Badge</h1>
        <card-view />
        <button-view buttonType="primary" text="#Primary" />
        <button-view buttonType="secondary" text="#Secondary"/>
        <badg-view text="Ativo" />
      </div>

      <div class="sample">
        <h1 class="title">#Sample 11 | Input, DropDown</h1>
        <input-text :placeholder="'Digite o texto'" class="mb-2" />
        <input-text :placeholder="'Digite outro texto'" class="mb-2" />

        <drop-down />

      </div>

      




    </div>
    
  </div>
</template>

<script>
import CardView from '@/components/CardView.vue';
import ButtonView from '@/components/ButtonView.vue';
import BadgView from '@/components/BadgView.vue';
import InputText from '@/components/InputText.vue';
import DropDown from '@/components/DropDown.vue';

export default {
  name: 'home-view',
  components: {
    CardView, ButtonView, BadgView, InputText, DropDown
  }

}
</script>

<style scoped>

.home {    
  padding: 10px;
  margin-left: 5px;
  border: 1px solid lightgray;
  border-radius: 5px;
  margin-top: 5px;
  width: calc(100% - 10px);
  height: calc(100% - 30px);
  display: flex;
}

.home .col1, .home .col2 {  
  padding: 20px;
}

.sample-title {
  font-size: 1.2rem;
  font-weight: bold;
  margin-bottom: 10px;
}

hr {
  margin: 10px 0;
}

</style>