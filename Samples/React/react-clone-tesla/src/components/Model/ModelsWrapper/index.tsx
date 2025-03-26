import React from 'react'
import { Container } from './style'
import ModelsContext, { CarModel } from '../ModelsContext'

const ModelsWrapper: React.FC = ({ children }) => {
  const wrapperRef = React.useRef<HTMLDivElement>(null);
  const [registeredModels, setRegisteredModles] = React.useState<CarModel[]>([]);

  const registerModel = React.useCallback((model: CarModel) => {
    /* Adiciona o novo modelo o array *************/
    setRegisteredModles(state => [...state, model]);  
  }, []);

  const unregisterModel = React.useCallback((modelName: string) => {
    /* Filter vai retornar uma lista de CarModel, com excessão do CarModel cujo nome é 'modelName' *************/
    setRegisteredModles(state => state.filter(m => m.modelName !== modelName));
  }, []);

  const getModelByName = React.useCallback((modelName: string) => {
    return registeredModels.find(m => m.modelName === modelName) || null;
  }, [registeredModels]);


  return (
    <ModelsContext.Provider value={{wrapperRef, registeredModels, registerModel, unregisterModel, getModelByName}}>
      <Container ref={wrapperRef} >{children}</Container>
    </ModelsContext.Provider>
  )
}

export default ModelsWrapper