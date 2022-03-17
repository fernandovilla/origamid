import React from 'react'
import useModel from '../useModel'
import { Container } from './style'

interface Props extends React.HtmlHTMLAttributes<HTMLDivElement> {
  modelName: string
  overlayNode: React.ReactNode
}

const ModelSection: React.FC<Props> = ({modelName, overlayNode, children, ...props}) => {
  const { registerModel } = useModel(modelName);

  const sectionRef = React.useRef<HTMLDivElement>(null);

  React.useEffect(() => {
    if (sectionRef.current){
      registerModel({
        modelName, overlayNode, sectionRef
      })
    }
  }, [modelName, overlayNode, sectionRef]);

  return (
    <Container ref={sectionRef} {...props}>
      {children}
    </Container>
  )
}

export default ModelSection