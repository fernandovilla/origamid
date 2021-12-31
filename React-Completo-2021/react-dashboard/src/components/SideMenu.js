import './SideMenu.css';
import React from 'react'
import logo from '../assets/logo.png'
import search from '../assets/search.svg'
import toggleIconClose from '../assets/close.svg'
import toggleIcon from '../assets/menu-hamb.svg'
import dashboardChartIcon from '../assets/dashboard-chart.svg'
import contentIcon from '../assets/paper.svg'
import designIcon from '../assets/design.svg'
import userIcon from '../assets/user.jpg'
import MenuItem from './MenuItem';


const SideMenu = (props) => {
  const [toggle, setToggle] = React.useState(false);

  const toggleHandleClick = () => {    
    setToggle(!toggle);
  }

  const menuItemHandleClick = () => {
    if (toggle) 
      setToggle(false);
  }
  
  React.useEffect(() => {
    if (toggle){
      document.querySelectorAll('.sub-menu').forEach(i => i.classList.remove('expanded'));
    }

    props.onCollapse(toggle);

  }, [toggle]);


  const menu = [
    { text: 'Dashboard', icon: dashboardChartIcon, to: '/', subMenus: null },
    { text: 'Content', icon: contentIcon, to: '/content', 
      subMenus: [{text: 'Courses', to: '/content/courses'}, {text: 'Videos', to: '/content/videos'}]},
    { text: 'Design', icon: designIcon, to: '/design', subMenus: null}
  ];
  

  return (
    <div className={`side-menu ${toggle ? 'inactive' : 'active'}`}>

      <div className='top-section'>
        <div className="logo">
          <img src={logo} alt="Logo" />
        </div>
        
        <div className='toggle-menu-btn'>
          <button onClick={toggleHandleClick}>            
              <img src={toggle ? toggleIcon : toggleIconClose} alt="Menu Close" />              
          </button>
        </div>

        <div className='search-controller'>
          <button className='search-btn'>
            <img src={search} alt="Search" />
          </button>          
          <input type="text" name="search" id="search" placeholder='Search...' />
        </div>
      </div>

      <div className="divider" />

      <div className="main-menu">
        <ul>
          {menu.map((m, i) => (
            <MenuItem 
              key={i} 
              text={m.text} 
              icon={m.icon} 
              to={m.to} 
              subMenus={m.subMenus}
              onClick={menuItemHandleClick}/>
          ))}          
        </ul>
      </div>

      <div className="side-menu-footer">  
        <div className="avatar">
          <img src={userIcon} alt="User" />   
        </div>  
        <div className="user-info">
          <h5>Fernando Villa</h5>
          <p>fermvilla@gmail.com</p>
        </div>      
      </div>
    </div>
  )
}

export default SideMenu;