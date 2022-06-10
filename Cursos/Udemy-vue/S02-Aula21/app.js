const counterAdd = (counter) => {  
  return counter + 1 ;
}

const counterReduce = (counter) => {
  if (counter > 0)
    return counter - 1;

  return 0;
}

const app = Vue.createApp({
  data() {
    return {
      counter: Math.random() * 1000,
      value: 10,
      name: '',
      lastName: '',
      // fullname: '',
      confirmedName:''
    };
  },
  computed: {
    fullname() {
      console.log("fullname");
      if (this.name === '' && this.lastName === '')
        return ' ';

      return `${this.name} ${this.lastName}`;
    }
  },
  watch: {
    // name(value, oldValue) {
    //   if (value === '')
    //     this.fullname = '';
    //   else 
    //     this.fullname = (`${value} ${this.lastName}`).toUpperCase();
    // },
    // lastName(value){
    //   if (value === '')
    //     this.fullname = '';
    //   else 
    //     this.fullname = (`${this.name} ${value}`).toUpperCase();
    // }
    counter(value) {
      if (value >= 1000){
        const that = this;
        setTimeout(function () {
          that.counter = 0;
        }, 2000);
        this.counter = 0;
      }
    }
  },
  methods: {    
    add() { this.counter = counterAdd(this.counter); },
    reduce() { this.counter = counterReduce(this.counter); },
    addCounter(num) { 
      this.counter = this.counter + num
    },
    setName(event, lastName){ 
      //this.name = event.target.value.toUpperCase() + ' ' + lastName.toUpperCase(); 
      this.name = event.target.value.toUpperCase();
    },
    submitForm(event){
      //event.preventDefault();
      alert("OK");
    },
    confirmarNameInput(){
      this.confirmedName = this.fullname;
    }, 
    resetName(){
      this.name = '';
      this.lastName = '';
    }
   }

});

app.mount('#events');