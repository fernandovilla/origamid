import React from 'react';

const App = () => {
  const [count, setCount] = React.useState(1);
  const [items, setItems] = React.useState(['Item1']);

  const handleClick = () => {
    //setCount((c) => c + 1);
    //setItems((i) => [...i, `Item${count + 1}`]);

    setCount(count + 1);
    setItems([...items, `Item${count + 1}`]);
  };

  return (
    <div>
      {items.map((item) => (
        <li key={item}>{item}</li>
      ))}
      <button onClick={handleClick}>{count}</button>
    </div>
  );
};

export default App;
