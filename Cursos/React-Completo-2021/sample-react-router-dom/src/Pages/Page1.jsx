import React from 'react'
import './Page.css'

const Page1 = () => {

  const handleClick = () => {
    //não faz nada...
  }

  return (
    <div className='page page1'>
      <h2>Page 1</h2>
      <button onClick={handleClick}>Go Back</button>
    </div>
  )
}

export default Page1
