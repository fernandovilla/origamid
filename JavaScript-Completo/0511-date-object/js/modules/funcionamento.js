export default function initFuncionento() {
  const funcionamento = document.querySelector("[data-semana]");
  const diasSemana = funcionamento.dataset.semana.split(",").map(Number);
  const horarioSemana = funcionamento.dataset.horario.split(",").map(Number);

  const dataAgora = new Date();
  const diaAgora = dataAgora.getDay();
  const horarioAgora = dataAgora.getHours();

  const semanaAberto = diasSemana.indexOf(diaAgora) > -1;
  const horarioAberto =
    horarioAgora >= horarioSemana[0] && horarioAgora < horarioSemana[1];

  if (semanaAberto && horarioAberto) {
    funcionamento.classList.add("aberto");
  } else {
    funcionamento.classList.remove("aberto");
  }
}

/*
   //Exemplo...
   const agora = new Date();
   const natal = new Date("Dec 24 2020 23:59:00");

   function converterEmDias(time) {
   return time / (24 * 60 * 60 * 1000); //horas_dia * minutos_hora * segundos_minuto * milessigundos_segundo
   }

   const diasAgora = converterEmDias(agora);
   const diasNatal = converterEmDias(natal);

   const faltamDiasParaNatal = diasNatal - diasAgora;
   console.log(faltamDiasParaNatal);
*/
