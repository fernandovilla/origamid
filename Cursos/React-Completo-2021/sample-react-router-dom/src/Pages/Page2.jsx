import React from 'react'
import './Page.css'

const Page2 = () => {

  const handleClick = () => {
    //não faz nada..
  }

  return (
    <div className='page page2'>
      <h2>Page 2</h2>
      <button onClick={handleClick}>Go Back</button>
    </div>
  )
}

export default Page2
