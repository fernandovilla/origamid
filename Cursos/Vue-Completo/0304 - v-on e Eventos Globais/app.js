const app = Vue.createApp({
  data(){
    return {
     mouseX: 0,
     mouseY: 0,
     github: {
       name: '',
       login: '',
       avatar_url: ''
     }
    }
  },
  methods: {
      handleMouseMove(event){
        this.mouseX = event.clientX;
        this.mouseY = event.clientY;
      },
      async obterDadosGitHub(){
        var result = await fetch('https://api.github.com/users/fernandovilla');
        
        if (result.ok){
          var json = await result.json();
          if (json !== null){
            this.github.name = json.name;
            this.github.login = json.login;
            this.github.avatar_url = json.avatar_url;
          }
        }
      }
    },
  created(){
    window.addEventListener('mousemove', this.handleMouseMove);
  },
  mounted(){
    this.obterDadosGitHub();
  },
  beforeDestroy(){
    window.removeEventListener('mousemove', this.handleMouseMove);
  }
  });

  app.mount("#app")