import React from 'react';

const App = () => {
  const [cart, setCart] = React.useState(0);
  const [notification, setNotification] = React.useState(null);
  const timeoutRef = React.useRef();

  const handleClick = () => {
    setCart(cart + 1);
    setNotification('Added item into the cart');

    clearTimeout(timeoutRef.current); // Limpa a referência e em seguida cria uma nova referencia do timeout
    timeoutRef.current = setTimeout(() => {
      setNotification(null);
    }, 2000);
  };

  return (
    <div>
      <p>Cart Items: {cart}</p>
      <button onClick={handleClick}>Add item</button>
      <p>{notification}</p>
    </div>
  );
};

export default App;
