import React from 'react';
import styles from './Slide.module.css';

const Slide = ({ slides }) => {
  const [active, setActive] = React.useState(0);
  const [position, setPosition] = React.useState(0);
  const contentRef = React.useRef();

  React.useEffect(() => {
    const { width } = contentRef.current.getBoundingClientRect();
    //setPosition(position - width); // posição atual - width do elemento pai
    setPosition(-(width * active));
  }, [active]);

  function slideNext() {
    if (active < slides.length - 1) setActive(active + 1);
  }

  function slidePrev() {
    if (active > 0) setActive(active - 1);
  }

  return (
    <section className={styles.container}>
      <div
        className={styles.content}
        style={{ transform: `translateX(${position}px)` }}
        ref={contentRef}
      >
        {slides.map((slide) => (
          <div key={slide.id} className={styles.item}>
            {slide.text}
          </div>
        ))}
      </div>
      <nav className={styles.nav}>
        <button onClick={slidePrev}>Previou</button>
        <button onClick={slideNext}>Next</button>
      </nav>
    </section>
  );
};

export default Slide;
