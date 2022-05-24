import React from 'react';

const Radio = ({ pergunta, options, id, onChange, value, active }) => {
  // Se não for o slide ativo, retorna 'null'
  if (!active) return null;

  return (
    <fieldset
      style={{
        padding: '20px',
        marginBottom: '1rem',
        border: '2px solid #eee',
        borderRadius: '6px',
        boxShadow: '2px 2px 2px rgba(0,0,0,0.5)',
      }}
    >
      <legend style={{ fontWeight: 'bold', color: '#444' }}>{pergunta}</legend>
      {options.map((p, index) => (
        <label
          key={index}
          style={{ marginBottom: '.8rem', fontFamily: 'monospace' }}
        >
          <input
            type="radio"
            id={id}
            value={p}
            onChange={onChange}
            checked={value === p}
          />
          {p}
        </label>
      ))}
    </fieldset>
  );
};

export default Radio;
