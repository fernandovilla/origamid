import React from 'react';

// Classe de realiza acesso e modificações na tag 'Head'
const Head = (props) => {
  React.useEffect(() => {
    console.log(props);
    document.title = 'Site | ' + props.title;
    document
      .querySelector('meta[name="description"]')
      .setAttribute('content', props.description);
  }, [props]);

  return <></>;
};

export default Head;
