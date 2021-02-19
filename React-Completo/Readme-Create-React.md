Criação de um projeto React:
https://www.origamid.com/slide/react-completo/#/0204-webpack-e-babel/5

PREPARAÇÃO:

1. Iniciar um pacote npm:

   - npm init -y

2. Instalar o webpack, webpack-cli e o webpack-dev-server:

   - npm install webpack webpack-cli webpack-dev-server --save-dev

3. Criar arquivos:

   - index.html
       <body>
         <div id="root"></div>
         <script src="main.js"></script>
       </body>

   - src/index.js
     import React from 'react';
     import ReactDOM from 'react-dom';
     import App from './App';
     ReactDOM.render(<App />, document.getElementById('root'));

   - src/App.js
     import React from 'react';
     const App = () => return <a href="">React.JS App</a>;
     export default App;

4. Alterar o package.json
   "scripts": {
   "start": "webpack serve --mode development --open --hot",
   "build": "webpack --mode production"
   }

   -> OBS: Executando: 'npm start' no terminal, o webpack serve será carregado em modo desenvolvimento;

5. Instalação do React:

   - npm install react react-dom

6. Instalar o Babel mínimo:

   - Babel transforma JS novo em JS antigo, para manter a compatibilidade com os browsers;
   - npm install @babel/core @babel/preset-react babel-loader --save-dev
   - Criar o webpack.config.js na raiz do projeto;

7. Executando:

   - Projeto já está pronto para ser executado: 'npm start'

8. Arquivos CSS:

   - Por padrão o react já vem configurado para utilização dos CSS module;
   - Basta criar os arquivos de CSS com a seguinte nomemclatura: Arquivo.module.css;
   - Em seguida importa-lo para o arquivo .js que deseja utilizado: import styles from './Arquivo.module.css';
   - Para utiliza-lo, incluir className={styles.formatacao} nos elementos desejados;

9. Arquivos CSS II (OPCIONAL):
   - Instalação do Loader;
   - npm install style-loader css-loader --save-dev
   - Incluir nova regra no webpack.config.js:
     rules: {
     teste: /\.css/$, /_ arquivos terminados em css_/
     use: ['style-loader', 'css-loader']
     }
