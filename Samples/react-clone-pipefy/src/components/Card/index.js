import React from 'react';
import { useDrag, useDrop } from 'react-dnd';
import { Container, Label } from './styles';
import BoardContext from '../Board/context';

const Card = ({ data, index, listIndex }) => {
  const ref = React.useRef();
  const { move } = React.useContext(BoardContext);

  const [{ isDragging }, dragRef] = useDrag({
    type: 'CARD',
    item: { index, id: data.id, content: data.content, listIndex },
    collect: (monitor) => ({ isDragging: monitor.isDragging() }),
  });

  const [, dropRef] = useDrop({
    accept: 'CARD',
    hover(item, monitor) {
      // console.log(`${item.id} => ${data.id}`);
      // console.log(`${item.index} => ${index}`);

      const draggedListIndex = item.listIndex;
      const targetListIndex = listIndex;

      const draggedIndex = item.index; /* item q está sendo arrastado */
      const targetIndex = index; /* item q vai receber o item arrastado */

      if (draggedIndex === targetIndex && draggedListIndex === targetListIndex)
        return;

      const targetSize = ref.current.getBoundingClientRect();
      const targetCenter = (targetSize.bottom - targetSize.top) / 2;

      const draggedOffset = monitor.getClientOffset();
      const draggedTop = draggedOffset.y - targetSize.top;

      /* NÃO FAZ NADA, POIS O ITEM ARRASTADO JÁ ESTÁ NA POSIÇÃO ANTERIOR AO ITEM ALVO */
      if (draggedIndex < targetIndex && draggedTop < targetCenter) {
        return;
      }

      /* NÃO FAZ NADA, POIS O ITEM ARRASTADO JÁ ESTÁ NA POSIÇÃO POSTERIOR AO ITEM ALVO */
      if (draggedIndex > targetIndex && draggedTop > targetCenter) {
        return;
      }

      move(draggedListIndex, targetListIndex, draggedIndex, targetIndex);

      item.index = targetIndex;
      item.listIndex = targetListIndex;
    },
  });

  // Usado para o container poder receber ora 'dragRef, ora 'dropRef';
  dragRef(dropRef(ref));

  return (
    <Container ref={ref} isDragging={isDragging}>
      <header>
        {data.labels.map((label) => (
          <Label key={label} color={label} />
        ))}
      </header>
      <p>{data.content}</p>

      {data.user && <img src={data.user} alt="avatar usuario" />}
    </Container>
  );
};

export default Card;
