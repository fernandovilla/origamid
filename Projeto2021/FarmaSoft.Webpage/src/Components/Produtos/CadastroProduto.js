import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import InputText from '../Forms/InputText';

const CadastroProduto = (props) => {
  return (
    <div className="container card p-3 mt-3">
      <h4 className="mb-3">cadastro de produto:</h4>
      <div className="row">
        <InputText name="descricao" label="Descricao" col="col" />
      </div>
    </div>
  );
};

export default CadastroProduto;
