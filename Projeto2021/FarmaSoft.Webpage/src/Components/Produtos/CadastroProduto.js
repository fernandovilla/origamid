import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import InputText from '../Forms/InputText';

const CadastroProduto = (props) => {
  return (
    <div className="container">
      <div className="row">
        <InputText name="descricao" label="Descricao" col="col-6" />
      </div>
    </div>
  );
};

export default CadastroProduto;
