import React from 'react'
import './Page.css'

const Page3 = () => {

  const handleClick = () => {
    //não faz nada...
  }

  return (
    <div className='page page3'>
      <h2>Page 3</h2>
      <button onClick={handleClick}>Go Back</button>
    </div>
  )
}

export default Page3