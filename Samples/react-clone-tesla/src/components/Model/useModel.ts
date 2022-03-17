import React from 'react'
import ModelsContext from './ModelsContext'

const useModel = (modelName: string) => {
  const { registerModel, unregisterModel, getModelByName } = React.useContext(ModelsContext);

  React.useEffect(() => {
    return () => unregisterModel(modelName);
  }, [modelName, unregisterModel]);

  const getModel = React.useCallback(() => getModelByName(modelName), [getModelByName, modelName]);

  return { registerModel, getModel };
}

export default useModel