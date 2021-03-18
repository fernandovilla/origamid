import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import InputText from '../Forms/InputText';
import Select from '../Forms/Select';
import Embalagens from './Embalagens';

const obterListaTipos = () => {
  return [    
    {label: "Mercadoria", value:0, disabled: false},
    {label: "Serviço", value:1, disabled: false}
  ];
}

const obterListaStatus = () => {
  return [
    {label: "Normal", value: 0, disabled: false},
    {label: "Bloqueado", value: 1, disabled: false},
    {label: "Excluído", value: 2, disabled: false},
    {label: "Oculto", value: 3, disabled: false},
  ];
}

const obterListaEmbalagens = () => {
  return null;
}

const CadastroProduto = (props) => {
  const [tipo, setTipo] = React.useState(0);  //mercadoria
  const [status, setStatus] = React.useState(0);  //normal

  const listaTipos = obterListaTipos();
  const listaStatus = obterListaStatus();
  const listaEmbalagens = obterListaEmbalagens();

  return (
    <div className="container card p-3 mt-3">
      <h4 className="mb-3">cadastro de produto:</h4>
      <div className="row">
        <InputText name="codigo" label="Código" col="col-md-2 col-12" />
        <InputText name="descricao" label="Descricao" col="col-md-10 col-12" />
      </div>
      <div className="row">
        <Select id="tipo" label="Tipo" col="col-md-4 col-12" options={listaTipos} defaultValue={tipo} />
        <Select id="status" label="Status" col="col-md-4 col-12" options={listaStatus} defaultValue={status} />
      </div>
      <Embalagens embalagens={listaEmbalagens} />
    </div>
  );
};

export default CadastroProduto;
