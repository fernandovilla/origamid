import React from 'react';

/**
 * > Bootstrap 5:
 *    npm install bootstrap@next
 *    fazer os imports no index.js
 * > React Bootstrap:
 *    Utiliza 'styled-component' e Bootstrap 4
 *    Não utiliza a importação do JS
 *    npm install react-bootstrap
 * > Outros:
 *    https://material-ui.com/pt/
 *    https://tailwindcss.com/
 *
 */

import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

const App = () => {
  return (
    <div style={{ display: 'flex' }}>
      <div
        className="card bg-dark text-white m-5"
        style={{ maxWidth: '18rem' }}
      >
        <div className="card-header">Notebook</div>
        <div className="card-body">
          <h5 className="card-title">R$ 7.000,00</h5>
          <p className="card-text" style={{ fontSize: '0.8rem' }}>
            Garantia de 2 anos. 16GB de RAM, 1TB + 240GB SSD, Monitor de 15''{' '}
          </p>
        </div>
        <div className="card-footer">
          <button className="btn btn-primary">Comprar</button>
        </div>
      </div>

      <Card
        bg="dark"
        text="white"
        className="m-5"
        style={{ maxWidth: '18rem' }}
      >
        <Card.Header>Smartphone</Card.Header>
        <Card.Body>
          <Card.Title>R$ 2.500,00</Card.Title>
          <Card.Text style={{ fontSize: '0.8rem' }}>
            Garantia de 12 meses. Tela de 7'', 128GB, 4GB RAM
          </Card.Text>
        </Card.Body>
        <Card.Footer>
          <Button>Comprar</Button>
        </Card.Footer>
      </Card>
    </div>
  );
};

export default App;
