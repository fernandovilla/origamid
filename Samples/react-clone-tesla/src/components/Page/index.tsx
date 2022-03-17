import React from 'react'
import DefaultOverlayContent from '../DefaultOverlayContent';
import ModelSection from '../Model/ModelSection';
import ModelsWrapper from '../Model/ModelsWrapper';
import { Container } from './style'

const Page = () => {
  return  (
    <Container>
      <ModelsWrapper>
        <div>
          {[ 'Model One', 'Model Two', 'Model Three', 'Model Four', 'Model Five', 'Model Six', 'Model Seven'].map((modelName, n) => (
              <ModelSection 
                key={n}
                className='colored'
                modelName={modelName}
                overlayNode={<DefaultOverlayContent label={modelName} description='Order online for delivery' />} 
              />
            ))
          }
          
        </div>
      </ModelsWrapper>
    </Container>
  )
};

export default Page