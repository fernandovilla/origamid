import React from 'react';

const Pergunta = ({ pergunta, value, onChange, active }) => {
  if (!active) return null;

  return (
    <fieldset
      style={{
        marginBottom: '1rem',
        fontWeight: 'bold',
        padding: '2rem',
        border: '2px solid #ddd',
        borderRadius: '10px',
      }}
    >
      <legend style={{ padding: '0.5rem' }}>{pergunta.pergunta}</legend>
      {pergunta.options.map((option, index) => (
        <label
          htmlFor={index}
          key={index}
          style={{ marginBottom: '1rem', fontFamily: 'monospace' }}
        >
          <input
            type="radio"
            id={pergunta.id}
            name={pergunta.id}
            value={option}
            onChange={onChange}
            checked={option === value}
          />
          {option}
        </label>
      ))}
    </fieldset>
  );
};

export default Pergunta;
