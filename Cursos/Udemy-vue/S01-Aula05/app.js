/* >> ABORDAGEM UTILIZANDO JS PURO
  const button = document.querySelector('button');
  const input = document.querySelector('input');
  const list = document.querySelector('ul');

  const handleClick = () => {
    const value = input.value;

    if (value !== ''){
      const li = document.createElement('li');
      li.textContent = value;
      list.appendChild(li);
      input.value = '';
    }
  }

  button.addEventListener('click', handleClick);
*/

Vue.createApp({
  data() {
    return {
      goals: [],
      enteredValue: ''
    };
  },
  methods: {
    addGoal() {
      if (this.enteredValue === '') 
        return;
        
      this.goals.push(this.enteredValue);
      this.enteredValue = '';
    }
  }
}).mount('#app');