import React from 'react'
import products from '../../data/products';

const Catalogo = (props) => {
  
  function getProdutosListItem(){
    return products.map(prod => (<li key={prod.id}>Id: {prod.id} - {prod.name} - {prod.preco}</li>));
  }

  return (
    <div>
      <h2>Produtos:</h2>
      <ul>
        {getProdutosListItem()}
      </ul>
    </div>
  )
}

export default Catalogo;