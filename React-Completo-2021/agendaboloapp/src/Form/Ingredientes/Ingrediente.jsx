import React from 'react'
import { useParams } from 'react-router-dom'

export const Ingrediente = () => {

  const params = useParams();

  return (
    <div>
      <h1>Produto ID: {params.id}</h1>
    </div>
  )
}
