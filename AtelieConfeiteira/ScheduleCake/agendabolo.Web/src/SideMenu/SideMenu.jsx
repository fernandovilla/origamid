import React from 'react'
import InputSearchMenu from './InputSearchMenu';
import './SideMenu.css';

const SideMenu = () => {
  return (
      <div className='menu'>
      <section className='menu-top'>
        <p>Logo</p>
      </section>

      <section className='menu-items'>
        <div className='menu-search'>
          <div>
            <InputSearchMenu />
            <nav>
              <ul>
                <li>Cadastros</li>
                <li>Relatórios</li>
                <li>Configurações</li>
              </ul>
            </nav>
          </div>
        </div>
      </section>

      <section className='menu-footer'>
        <p>Footer</p>
      </section>
      </div>
  )
}

export default SideMenu
