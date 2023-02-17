<template>
  <div ref="select" class="select" :class="{ active: isActive }">

    <div ref="select-btn" class="select-btn" @click="selectHandleClick">
      <div class="input-select">
        <span>{{selectedItemDisplay}}</span>
        <font-awesome-icon icon="fa-solid fa-caret-down" class="icon" />
      </div>
    </div>

    <div ref="content" class="content" >
      <div class="search">
        <font-awesome-icon icon="fa-sharp fa-solid fa-search" class="icon" />
        <input-base :focused="searchFocus" ref="textSearch" id="textSearch" :placeholder="placeholder"
            @keyup="handleKeyUpSearch"
            @keydown="handleKeyDownSearch" />
      </div>

      <ul v-if="optionsSearch !== null" class="options" ref="options" >
        <li v-for="(option, index) in optionsSearch" class="options-item" :key="index" @click="handleClickLI(option.value)">
          <div v-if="option.html">
            <span v-html="option.html"></span>
          </div>
          <div v-else>
            <span>{{option.display}}</span>
          </div>
        </li>
      </ul>
    </div>

  </div>
</template>

<script>
import InputBase from './InputBase.vue';

export default {
  name: 'select-search-base',
  data(){
    return {
      isActive: false,
      searchFocus: false,
      optionsSearch: null,
      liSelected: undefined,
      liIndex: -1,
    }
  },
  components: { InputBase },
  props: {
    options: {
      type: Array,
      default: null
    },
    selectedItem: {
      type: Object,
      default: null
    },
    placeholder: {
      type: String,
      default: ''
    }
  },
  computed:{
    selectedItemDisplay(){
      if (this.selectedItem !== null) {
        return this.selectedItem.display;
      } else {
        return "Selecione..."
      }
    }
  },

  methods: {
    activeListItems(){
      this.isActive = !this.isActive;
      this.searchFocus = this.isActive;

      if (this.isActive){
        setTimeout(() => {
          document.getElementById('textSearch').focus();
        }, 5);        
      }
    },
    selectHandleClick(){
      this.activeListItems();
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
    handleClickLI(item){
      this.$emit('clickItem', item);
    },



    handleKeyUpSearch(e){
      const valueSearch = e.target.value.toUpperCase().trim();

      if (valueSearch.length >= 1) {
        this.optionsSearch = this.options.filter((item) => item.display.toUpperCase().startsWith(valueSearch));
      } else {
        this.optionsSearch = this.options;
      }
    },
    handleKeyDownSearch(e){
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
          //selectItem();
          console.log("Seleciona item");
          break;
        case 27:
          //activeListItems();
          console.log("Fecha a lista");
          break;
      }
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
          
          var li = this.$refs.options.children[this.liIndex];
          var liPos = li.getBoundingClientRect();
          var ulPos = this.$refs.options.getBoundingClientRect();

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

      this.removeSelected(this.liSelected);

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
        this.addSelected(this.liSelected);
        this.scrollToSelected(direction);
      }, 5);
    },
    selectItem(){
      var li = this.$refs.options.children[this.liIndexindex];
      this.updateName(li);
    },
    updateName(selectedLi){
      this.activeListItems();
      this.$refs.textSearch.value = '';
      //fillOptions(countries, selectedLi.innerText);
      //selectBtn.firstElementChild.innerText = selectedLi.innerText;
    }




  },






  created(){
    document.addEventListener("click", this.documentHandleClick);
    this.optionsSearch = this.options;
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
  }

  .select-btn.select-group i {
    cursor: pointer;
    font-size: 20px;
    transition: transform 0.3s linear;
  }



  .select .content {
    display: none;
    background: var(--background-color-white);
    width: 100%;
    border: 1px solid var(--border-color-light);
    border-radius: 4px;
    padding: 5px 10px;
  }

  .select.active .content {
    display: block;
    z-index: 1;
    position: absolute;
    top: 34px;
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
    border-radius: 4px;
  }




  .content .options {
    margin-top: 10px;
    max-height: 300px;
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
  }

  li:hover,
  li.selected {
    background: #ddd;
    cursor: pointer;
  }

  li.selected {
    background: lime;
  }

</style>