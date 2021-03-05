PREPARAÇÃO:

1. Criar o projeto React:

   - npx create-react-app <nome_peojtso>
   - O comando acima já cria o projeto com a estrutura de pastas "\\projeto\\src\\..." e "\\projeto\\public\\...";

2. Instalação de pacotes auxiliares:

   - npm i history
   - npm i react-router-dom@next

3. Limpeza opcional:

   - Deixar na pasta source, apenas os arquivos "index.js" e "App.js";
   - Remover no src\index.js:
     - import \* serviceWorker from './serviceWorker';
     - import './index.css';
     - serviceWorker.unregister();
   - Remover no src\App.js:
     - import logo from './logo.svg';
     - import './App.css';
     - Deixar o App() retornando uma '<div>' pura;
   - Remover no public\index.html:
     - <meta name="description" content="Informar aqui o nome do aplicativo">
     - <title>Nome do aplicativo</title>

4. Configuração opcional ".vscode";
   - Criar a pasta .vscode na raiz do projeto;
   - Criar o arquivo settings.json com o conteúdo:
     '''
     {
     "git.enabled": false,
     "files.exclude": {
     "node_modules": true,
     ".vscode": true,
     ".gitignore": true,
     "package.json": true,
     "package-lock.json": true,
     "public": true,
     }
     }
     '''
