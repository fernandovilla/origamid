import React from 'react';
import Card from '../Card';
import { Container, AddIcon } from './styles';

const List = ({ data, index: listIndex }) => {
  return (
    <Container done={data.done}>
      <header>
        <h2>{data.title}</h2>
        {data.creatable && (
          <button type="button">
            <AddIcon />
          </button>
        )}
      </header>

      <ul>
        {data.cards.map((card, index) => (
          <Card key={card.id} data={card} listIndex={listIndex} index={index} />
        ))}
      </ul>
    </Container>
  );
};

export default List;
