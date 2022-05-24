import React from 'react';

const Produto = () => {
  React.useEffect(() => {
    function handleScroll(event) {
      console.log(event);
    }
    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  return (
    <div
      style={{
        width: '300px',
        height: '200vh',
        border: '1px solid',
        borderRadius: '4px',
        padding: '10px',
        margin: '10px 0px',
      }}
    >
      <p>Meu produto!</p>
    </div>
  );
};

export default Produto;
