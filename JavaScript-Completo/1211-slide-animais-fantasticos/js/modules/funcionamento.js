export default class Funcionamento {
  constructor(funcionamento, activeClass) {
    this.funcionamento = document.querySelector(funcionamento);

    if (activeClass === undefined) {
      this.activeClass = 'aberto';
    } else {
      this.activeClass = activeClass;
    }
  }

  getDadosFuncionamento() {
    this.diasSemana = this.funcionamento.dataset.semana.split(',').map(Number);
    this.horarioSemana = this.funcionamento.dataset.horario
      .split(',')
      .map(Number);
  }

  getDadosAgora() {
    const dataAgora = new Date();
    this.diaAgora = dataAgora.getDay();
    this.horarioAgora = dataAgora.getUTCHours() - 3; //  horário Brasil
  }

  verificarAberto() {
    const semanaAberto = this.diasSemana.indexOf(this.diaAgora) !== -1;
    const horarioAberto =
      this.horarioAgora >= this.horarioSemana[0] &&
      this.horarioAgora < this.horarioSemana[1];

    return semanaAberto && horarioAberto;
  }

  ativaAberto() {
    if (this.verificarAberto()) {
      this.funcionamento.classList.add(this.activeClass);
    }
  }

  init() {
    this.getDadosFuncionamento();
    this.getDadosAgora();
    this.ativaAberto();

    return this;
  }
}
