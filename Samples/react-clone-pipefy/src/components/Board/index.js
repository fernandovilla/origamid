import React, { useState } from 'react';
import List from '../List';
import BoardContext from './context';
import { Container } from './styles';
import { loadLists } from '../../services/api';

const data = loadLists();

const Board = () => {
  const [lists, setLists] = useState(data);

  function move(fromListIndex, toListIndex, fromCardIndex, toCardIndex) {
    const newList = [...lists];
    const dragCard = newList[fromListIndex].cards[fromCardIndex];
    newList[fromListIndex].cards.splice(fromCardIndex, 1);
    newList[toListIndex].cards.splice(toCardIndex, 0, dragCard);
    setLists(newList);
  }

  return (
    <BoardContext.Provider value={{ lists, move }}>
      <Container>
        {data.map((lista, index) => (
          <List key={lista.title} data={lista} index={index} />
        ))}
      </Container>
    </BoardContext.Provider>
  );
};

export default Board;
