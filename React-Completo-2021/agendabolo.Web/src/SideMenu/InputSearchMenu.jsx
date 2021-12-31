import React from 'react'
import searchIcon from '../Assets/search-white.svg'
import './InputSearchMenu.css';

const InputSearchMenu = () => {
  return (
    <div className='inputSearch'>
      <input type="text" id='search' placeholder='Procurar...' />
      <button><img src={searchIcon} alt="Procurar" /></button>      
    </div>
  )
}

export default InputSearchMenu
