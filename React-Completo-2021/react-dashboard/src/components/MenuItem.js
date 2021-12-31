import React from 'react'
import { NavLink } from 'react-router-dom'

const MenuItem = ({text, icon, to, subMenus, onClick}) => {

  const [expanded, setExpanded] = React.useState(false);

  const handleClick = () => {
    if (subMenus !== null){      
      setExpanded(!expanded)
    }
  }

  return (
    <li onClick={onClick}>              
      <NavLink to={to} className="menu-item" onClick={handleClick}>        
        <div className='menu-icon'>
          {icon && (<img src={icon} alt={text} />)}
        </div>
        <span>{text}</span>              
      </NavLink>
      {subMenus && 
        (<ul className={`sub-menu ${expanded ? "expanded" : ""}`}>
          {subMenus.map((menu,index) => (
            <li key={index}>
              <NavLink to={menu.to}>{menu.text}</NavLink>
            </li>            
          ))}</ul>)}
    </li>
  )
}

export default MenuItem;
