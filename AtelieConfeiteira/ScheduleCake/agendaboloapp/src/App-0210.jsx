import React from 'react';
import Header from './Header';
import Footer from './Footer';
import Form from './Form/Form';

const App = () => {
  return (
    <React.Fragment>
      <Header />
      <p>My App</p>
      <Form />
      <Footer />
    </React.Fragment> /* <React.Fragment> = <>...</> */
  );
};

export default App;
