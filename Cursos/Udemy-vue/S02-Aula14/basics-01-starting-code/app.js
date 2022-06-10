
const calculateNumber = () => {
  this.number = Math.random();

  console.log(this.number);

  if (this.number < 0.5)
    return "Learning Vue!";
  else
    return "<h3>Master Vue!</h3>";
}

const app = Vue.createApp({
  data() {
    return {
      courseGoal: 'Finish the course and learn Vue.JS!',
      vueLink: 'https://vuejs.org/',
      inputValue: 'oi',
      number: 0,
    };
  },
  methods: {
    calculateNumber
  }

});

app.mount('#user-goal');