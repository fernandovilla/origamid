import React from 'react';
import PropTypes from 'prop-types';

const Button = (props) => {
  const styles = {
    width: `${props.width}px`,
    height: `${props.width / 3}px`,
    margin: props.margin,
  };

  return (
    <button style={styles} onClick={props.onClick}>
      {props.children}
    </button>
  );
};

Button.defaultProps = {
  width: 200,
  margin: '10px',
};

Button.propTypes = {
  width: PropTypes.number,
  margin: PropTypes.string,
  onClick: PropTypes.func,
};

export default Button;
