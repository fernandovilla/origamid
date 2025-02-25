import React from 'react';
import GlobalStyles from './styles/GlobalStyles';
import Section from './components/Section';
import SideMenu from './components/SideMenu';
import data from './data';
import MenuForm from './components/MenuForm';

function App() {
  return (
    <>
      <Section 
        variant='blue' 
        title={data[0].title}
        description={data[0].description}
      />      

      <Section 
        variant='beige' 
        title={data[1].title}
        description={data[1].description}
      />      

      <Section 
        variant='blue' 
        title={data[2].title}
        description={data[2].description}
      />      

      <Section 
        variant='white' 
        title={data[3].title}
        description={data[3].description}
      />      

      <Section 
        variant='black' 
        title={data[4].title}
        description={data[4].description}
      /> 

      <SideMenu>
        <MenuForm />
      </SideMenu>

      <GlobalStyles />
    </>

  );
}

export default App;
