import React from 'react';

class Produtos extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      contar: 0,
    };

    this.handleClickAdd = this.handleClickAdd.bind(this);
    this.handleClickRemove = this.handleClickRemove.bind(this);
  }

  handleClickAdd() {
    this.setState((state) => ({ contar: state.contar + 1 }));
  }

  handleClickRemove() {
    this.setState((state) => ({ contar: state.contar - 1 }));
  }

  componentDidMount() {
    // Ocorre quando o componente é montado;
    // É um bom momento para fazer um fetch de um dado;
    console.log('montando o componente Produtos');
  }

  componentDidUpdate() {
    // Ocorre sempre que o componente é renderizado;
    document.title = this.state.contar;
  }

  componentWillUnmount() {
    // Ocorre antes do componente ser desmontado;
  }

  render() {
    return (
      <div>
        <h1>{this.props.titulo ? this.props.titulo : 'Título'}</h1>
        <p>Componente produto criado a moda antiga, usando classe!</p>
        <p>{this.state.contar}</p>
        <button onClick={this.handleClickAdd}>Add</button>
        <button onClick={this.handleClickRemove}>Remove</button>
      </div>
    );
  }
}

export default Produtos;
