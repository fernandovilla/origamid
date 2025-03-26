import './Contador.css'
import React from 'react'
import Display from './Display'
import StepForm from './StepForm';
import Buttons from './Buttons';

export default class Contador extends React.Component {

  constructor(props){
    super(props);

    this.state = { 
      step: props.step || 1, 
      value: props.value || 0,
    };

    this.Add = this.Add.bind(this);
    this.Sub = this.Sub.bind(this);
    //this.StepChange = this.StepChange(this);
  }

  state = { 
    step: 1, 
    value: 0 
  }

  Add(){
    this.setState({
      value: this.state.value + this.state.step
    });
  }

  Sub() {
    this.setState({
      value: this.state.value - this.state.step
    });
  }

  // Se criar a função como arrow function, não é necessário fazer o bind
  StepChange = (newStep) => {
    this.setState({
      step: newStep
    })
  }

  render() {
    return <div className="contador">
      <h2>Contador</h2>
      
      <StepForm step={this.state.step} onStepChange={this.StepChange} />
      
      <Display value={this.state.value} />

      <Buttons onAddValue={this.Add} onSubValue={this.Sub} />  
    </div>
  }
}