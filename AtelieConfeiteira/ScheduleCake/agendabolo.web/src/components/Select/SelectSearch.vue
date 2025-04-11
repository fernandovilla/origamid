<template>
  <div ref="select" class="select" :class="{ active: isActive }" tabindex="0" @focus="selectHandleFocus">

    <div ref="select-btn" class="select-btn" @click="selectHandleClick">
      <div class="input-select">
        <span>{{selectedOptionDisplayComputed}}</span>
        <font-awesome-icon icon="fa-solid fa-caret-down" class="icon" />
      </div>
    </div>

    <div ref="content" class="content-search" >
      <div class="search">
        <font-awesome-icon icon="fa-solid fa-search" class="icon" />
        <input-base 
            ref="textSearch"
            id="textSearch" 
            v-model="textSearchValue"
            autofocus
            :focused="searchFocus"             
            :placeholder="placeholder"                      
            @keyup="handleKeyUpSearch"
            @keydown="handleKeyDownSearch"                                    
            @blur="isActive = false" />
      </div>

      <div>
        <ul v-if="haItensListados" class="options" ref="options" :style="{ maxHeight: `${this.showOptions * 30}px` }" >
          <li v-for="(option, index) in optionsSearch" class="options-item" :class="{selected: selectedClassName(index)}" :key="index" @click="handleClickLI(index, option)">
            <div v-if="option.html">
              <span v-html="option.html" ></span>
            </div>
            <div v-else>
              <span>{{option.display}}</span>
            </div>
          </li>
        </ul>
        <p v-else class="no-itens">{{this.messageNoItems}}</p>
      </div>
    </div>

  </div>
</template>

<script>
import InputBase from '@/components/Input/InputBase.vue';

export default {
  name: 'select-search-base',
  data(){
    return {
      isActive: false,
      searchFocus: false,
      optionsSearch: null,
      liSelected: undefined,
      liIndex: -1,
      selectedOptionDisplay: '',
      messageNoItems: '',
      textSearchValue: ''
    }
  },
  components: { InputBase },
  props: {
    options: {
      type: Array,
      default: null
    },
    totalOptions: {
      type: Number,
      default: 0
    },
    selectedOption: {
      type: Object,
      default: null
    },
    placeholder: {
      type: String,
      default: ''
    },
    showOptions: {
      type: Number,
      default: 10
    },
    dropDownList: {
      type: Boolean,
      default: false
    },
    charToSearch: {
      type: Number,
      default: 3
    }
  },
  computed:{
    selectedOptionDisplayComputed(){
      if (this.selectedOptionDisplay !== ''){
        return this.selectedOptionDisplay;
      }
      else if (this.selectedOption !== null) {
        return this.selectedOption.display;
      }      
      else {
        return "Selecione..."
      }
    },
    haItensListados(){
      if (this.optionsSearch !== null){
        if (this.optionsSearch.length > 0){
          return true;
        }
      }

      return false;
    }
  },
  watch: {
    options(){
      this.optionsSearch = this.options;
    },  
    liIndex(){
      if (this.totalOptions > 0){
        if (this.options.length > 0 && this.totalOptions > this.liIndex){
          if ((this.liIndex >= this.options.length * 0.7)){            
            //this.onSearchingOptionsEvent();
          }
        }
      }
    },
    textSearchValue(){
      if (this.dropDownList) return;

      if (this.totalOptions === 0 && this.textSearchValue.trim().length >= this.charToSearch){
        this.messageNoItems = "Nenhum item localizado";
      } else if ((this.totalOptions === 0 && this.textSearchValue.trim().length === 0) || (this.totalOptions >= 0 && this.textSearchValue.trim() === '')) {
        this.messageNoItems = `Informe ${this.charToSearch} caracteres para buscar`;
      } else {
        this.messageNoItems = '';
      }
    }
  },
  methods: {

    activeListItems(){
      this.isActive = !this.isActive;
      this.searchFocus = this.isActive;

      if (this.isActive){

        //this.onSearchingOptionsEvent();

        document.addEventListener("click", this.documentHandleClick);

        setTimeout(() => {
          this.$refs.content.querySelector('#textSearch').focus();               
          this.moveToSelectedOtion();
        }, 5);        

      } else {

        document.removeEventListener("click", this.documentHandleClick);

        this.$emit('hiddingOptions')
        this.liIndex = -1;
        this.liSelected = undefined;        
      }
    },

    

    documentHandleClick(event){
      if (!this.isActive)
        return;

      try{
        var select = this.$refs.select.getBoundingClientRect();
        var content = this.$refs.content.getBoundingClientRect();
      } catch {
        this.isActive = false;
      }

      if (!this.clickInside(select, event)) {
        if (!this.clickInside(content, event)){
          setTimeout(() => {
            this.activeListItems();
          }, 25);
        }
      }
    },

    handleClickLI(index, option) {
      this.liIndex = index;
      this.selectItem();
      this.$emit('clickOption', option);
    },

    selectHandleFocus(){      

      this.$nextTick(() => {
        this.activeListItems();  
      });
            
    },

    
    selectHandleClick(){            
      //this.activeListItems();      
      this.$refs.select.removeEventListener('keydown', this.selectHandleKeyDown)
    },

    selectHandleKeyDown(e){
      if (!this.isActive){
        if (e.keyCode === 13){
          setTimeout(() => {
            this.activeListItems();  
            this.$refs.select.removeEventListener('keydown', this.selectHandleKeyDown)
          }, 5);
          
        }
      }
    },

    handleKeyUpSearch(){

      const valueSearch = this.textSearchValue.toUpperCase().trim();

      if (valueSearch.length >= 1 && this.dropDownList) {
        //Se dropDownList, filtro funciona na lista estática
        this.optionsSearch = this.options.filter((item) => item.display.toUpperCase().startsWith(valueSearch));

      } else if (valueSearch.length >= this.charToSearch && !this.dropDownList) {

        //Se não dropDownList, busca é realizada após usuário informar mais que 3 caracteres        
        setTimeout(() => {
          this.onSearchingOptionsEvent(valueSearch);
        }, 100);
        
      } else {
        if (valueSearch.trim() === '') {
          this.onCleaningOptions();
        } else {
          this.optionsSearch = this.options;
        }
      }
    },

    handleKeyDownSearch(e){

      if (e.keyCode === 9){
        this.activeListItems();
        return;
      }

      switch (e.keyCode) {
        case 34:
        case 40:
          this.moveItem('down');
          return;
        case 33:
        case 38:
          this.moveItem('up');
          break;
        case 36:
          this.moveItem('home');
          break;
        case 35:
          this.moveItem('end');         
          break;
        case 13:
          this.selectItem();
          break;
        case 27:
          this.activeListItems();
          break;
      }
    },


    clickInside(elementRect, clickPos){

      if (elementRect === null || elementRect === undefined || clickPos === null || clickPos === undefined) {
        return false;
      }

      try{
        if (
          clickPos.clientX >= elementRect.left &&
          clickPos.clientX <= elementRect.right &&
          clickPos.clientY >= elementRect.top &&
          clickPos.clientY <= elementRect.bottom
        ) {
          return true;
        } else {
          return false;
        }
      }catch{
        console.log(elementRect, clickPos);
        return false;
      } 
    },

    selectedClassName(index){
      return this.liIndex === index;
    },

    removeSelected(element){
      if (element !== undefined) {
        element.classList.remove('selected');
      }
    },

    addSelected(element){
      if (element !== undefined) {
        element.classList.add('selected');
      }
    },

    scrollToSelected(direction, forced) {

      if (this.liSelected !== undefined) {
        var newPos = 0;

        if (direction === 'home' && forced) {
          newPos = 0;
        } else {
          
          var options = this.$refs.options;
          var li = options.children[this.liIndex];
          var liPos = li.getBoundingClientRect();
          var ulPos = options.getBoundingClientRect();

          var goDown =
            direction === 'down' || direction === 'down+' || direction === 'end';
          var goUp =
            direction === 'up' || direction === 'up+' || direction === 'home';

          //var atingiuBotton = li.offsetTop + li.offsetHeight >= options.offsetTop + options.offsetHeight;
          var atingiuBotton = liPos.bottom > ulPos.bottom;

          var atingiuTop = liPos.top <= ulPos.top;

          if (atingiuBotton && goDown) {
            newPos =
              li.offsetTop -
              (this.$refs.options.offsetTop + this.$refs.options.offsetHeight - li.offsetHeight);
          } else if (atingiuTop && goUp) {
            newPos = li.offsetTop - li.offsetHeight - 30;
          }
        }

        if (newPos !== 0 || forced) {
          this.$refs.options.scroll({
            top: newPos,
            left: 0,
            behavior: 'auto',
          });
        }
      }
    },

    moveItem(direction){

      var liOptions = this.$refs.options.children;
      var len = liOptions.length - 1;

      if (direction === 'down' || direction === 'down+') {
        if (this.liSelected) {
          this.liIndex++;
          if (typeof liOptions[this.liIndex] !== undefined && this.liIndex <= len) {
            //mantem o index...
          } else {
            this.liIndex = 0;
            direction = 'up';
          }
        } else {
          this.liIndex = 0;
        }
      } else if (direction === 'up' || direction === 'up+') {
        if (this.liSelected) {
          this.liIndex--;
          if (typeof liOptions[this.liIndex] !== undefined && this.liIndex >= 0) {
            //mantem o index...
          } else {
            this.liIndex = len;
            direction = 'down';
          }
        } else {
          this.liIndex = len;
        }
      } else if (direction === 'home') {
        this.liIndex = 0;
      } else if (direction === 'end') {
        this.liIndex = len;
      }

      this.liSelected = liOptions[this.liIndex];

      setTimeout(() => {
        this.scrollToSelected(direction);
      }, 5);
    },

    selectItem(){
      var option = this.optionsSearch[this.liIndex];

      if (option !== null && option !== undefined){        
        this.activeListItems();
        this.updateName(option);
        this.$emit('selectedOption', option);
        this.textSearchValue = '';
        this.optionsSearch = null;
      }
    },

    onCleaningOptions(){
      this.$emit('cleaningOptions');
    },

    onSearchingOptionsEvent(textToSearch){
      var arg = { 
        message: '', 
        textToSearch: textToSearch,
        totalOptions: (this.options === null ? 0 : this.options.length)
      };

      this.$emit('searchingOptions', arg)

      if (arg.message !== '') {
        this.messageNoItems = arg.message;
      }
    },

    updateName(option){            
        this.selectedOptionDisplay = option.display;        
    },

    moveToSelectedOtion(){

      if (this.optionsSearch === null || this.selectedOption === null)
        return;

      this.optionsSearch.map((option, i) => {
        if (option.display === this.selectedOption.display){
          this.liIndex = i;
          this.liSelected = this.$refs.options.children[i];
          this.scrollToSelected('down');
        }
      });
    },    

    clear(){
      this.selectedOptionDisplay = '';
      this.textSearchValue = '';
      this.optionsSearch = null;
    },

    focus(){
      this.$nextTick(() => {
        this.isActive = true;
        this.$refs.textSearch.focus();
      });
    }
  },
  created(){
    //document.addEventListener("click", this.documentHandleClick);
    this.optionsSearch = this.options;
  },
  mounted(){
    
  }
}
</script>

<style scoped>

  .select {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
    position: relative;
    width: 100%;
    margin: 0;
    outline: none;
  }
  .select:focus .input-select {
    border-left: 2px solid var(--border-color-blue);  
    border-top: 1px solid var(--border-color-input-focus);  
    border-right: 1px solid var(--border-color-input-focus);  
    border-bottom: 1px solid var(--border-color-input-focus);
    color: var(--text-color-dark);    
  }

  .select-btn {
    width: 100%;
    cursor: pointer;
  }

  .select-btn .input-select {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0px 5px;
    background-color: var(--background-color-white);
  }

  .select-btn.select-group i {
    cursor: pointer;
    font-size: 20px;
    transition: transform 0.3s linear;
  }


  .select .content-search {
    display: none;
    background: var(--background-color-white);
    width: 100%;
    border: 1px solid var(--border-color-light);
    border-radius: 0px 0px 5px 5px;
    padding: 5px;
  }


  .select.active .content-search {    
    position: absolute;
    z-index: 9000;    
    display: block;
    top: 26px;        
  }

  .select.active .content-search .options {
    overflow-y: auto;
  }

  .select.active .select-btn .icon {
    transform: rotate(-180deg);
  }

  .search {
    display: flex;
    align-items: center;
    border-bottom: 1px solid var(--border-color-light);
    padding-bottom: 5px;
  }

  .search .icon {
    padding-right: 5px;
  }

  .search input {
    border: none;
    padding-left: 5px;
    outline: none;
  }

  .search input:focus {
    background: var(--background-color-light);
    border-radius: 5px;
  }
  

  

  .content .options {
    margin-top: 10px;
    padding-right: 2px;
    overflow: auto;
  }

  .content .options::-webkit-scrollbar {
    width: 6px;
  }
  .content .options::-webkit-scrollbar-track {
    background: #f1f1f1;
    border-radius: 15px;
  }
  .content .options::-webkit-scrollbar-thumb {
    background: #ccc;
    border-radius: 15px;
  }

  li {
    border-radius: 5px;
    list-style: none;
    padding: 5px;
    margin-top: 1px;
  }

  li:hover,
  li.selected {
    background: #ddd;
    cursor: pointer;
    
  }

  li.selected {
    background: #ddd;
  }

  .no-itens {
    text-align: center;
    padding: 10px;

  }

</style>