import './StepForm.css'
import React from 'react'

const StepForm = (props) => {
  return (
    <div>
        <label htmlFor="step">Step: </label>
        <input 
          id="step" 
          type="number" 
          value={props.step} 
          onChange={e => props.onStepChange(+e.target.value)} 
          max={100} min={0} maxLength={3}/>
      </div>
  );
}

export default StepForm;