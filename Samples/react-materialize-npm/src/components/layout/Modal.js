import React from 'react';

const Modal = ({ modalId }) => {
  const initialization = () => {
    document.addEventListener('DOMContentLoaded', function () {
      const M = window.M;
      const options = {};
      var elems = document.querySelectorAll('.modal');
      var instances = M.Modal.init(elems, options);
    });
  };

  initialization();

  return (
    <div>
      {/* Modal Trigger */}
      <a
        className="waves-effect waves-light btn modal-trigger"
        href={`#${modalId}`}
      >
        Incluir
      </a>

      {/*  Modal Structure  */}
      <div id={`${modalId}`} className="modal">
        <div className="modal-content">
          <h4>Modal Header</h4>
          <p>A bunch of text</p>
        </div>
        <div className="modal-footer">
          <a
            href="#!"
            className="modal-close waves-effect waves-green btn-flat"
          >
            Agree
          </a>
        </div>
      </div>
    </div>
  );
};

export default Modal;
