async function getDadosAsync() {
  try {
    const responseDados = await fetch("./dados.json");
    const jsonDados = await responseDados.json();

    console.log(jsonDados);
  } catch (erro) {
    console.log("Ocorreu erro:" + erro);
  } finally {
    console.log("Fim");
  }
}
//getDadosAsync();

async function getDadosAsync2() {
  try {
    const promiseDados = fetch("./dados.json");
    const promiseClientes = fetch("./clientes.json");

    const jsonDados = await (await promiseDados).json();
    const jsonClientes = await (await promiseClientes).json();

    console.log(jsonDados);
    console.log(jsonClientes);
  } catch (erro) {
    console.log("Ocorreu erro:" + erro);
  } finally {
    console.log("Fim");
  }
}
getDadosAsync2();
