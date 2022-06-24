const weather = {
  data() {
    return {
      weather: 0
    }
  },
  template: `
    <div>
      <p>Temperatura máxima, Rio: {{weather}}ºC</p>
      <button @click="refreshWeatherAsync">Refresh</button>
    </div>
  `,
  methods: {
    async refreshWeatherAsync(){
      this.weather = "...";

      const response = await fetch("https://api.origamid.dev/weather/rio");

      if (response.ok){
        const json = await response.json();
        this.weather = json.consolidated_weather[0].max_temp.toFixed(1);
      }
    }
  },
  created(){
    this.refreshWeatherAsync();
  }
}

export default weather;