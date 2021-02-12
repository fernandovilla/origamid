import React from 'react';
import FeedModal from './FeedModal';
import FeedPhotos from './FeedPhotos';
import PropTypes from 'prop-types';

const Feed = ({ user }) => {
  const [modalPhoto, setModalPhoto] = React.useState(null);
  const [pages, setPages] = React.useState([1]);
  const [infinite, setInfinite] = React.useState(true);

  React.useEffect(() => {
    let wait = false;
    function inifiniteScroll(event) {
      if (infinite) {
        const scroll = window.scrollY;
        const height = document.body.offsetHeight - window.innerHeight;

        if (!wait && scroll > height * 0.75) {
          setPages((pages) => [...pages, pages.length + 1]);
          wait = true;

          // Deixa o wait como false após 500ms, para que não seja feito fetch em todo wheel/scroll
          setTimeout(() => (wait = false), 500);
        }
      }
    }

    window.addEventListener('wheel', inifiniteScroll);
    window.addEventListener('scroll', inifiniteScroll);

    return () => {
      window.removeEventListener('wheel', inifiniteScroll);
      window.removeEventListener('scroll', inifiniteScroll);
    };
  }, [infinite]);

  return (
    <div>
      {modalPhoto && (
        <FeedModal photo={modalPhoto} setModalPhoto={setModalPhoto} />
      )}
      {pages.map((page) => (
        <FeedPhotos
          key={page}
          page={page}
          user={user}
          setModalPhoto={setModalPhoto}
          setInfinite={setInfinite}
        />
      ))}
    </div>
  );
};

Feed.defaultProps = {
  user: 0,
};

Feed.propTypes = {
  //user: PropTypes.string.isRequired,
  user: PropTypes.oneOfType([
    PropTypes.string.isRequired,
    PropTypes.number.isRequired,
  ]),
};

export default Feed;
