export const status_cadastro_description = (value) => {
  switch (value) {
    case 0:
      return 'Ativo';
    case 1:
      return 'Bloqueado';
    case 2:
      return 'Excluído';
    case 3:
      return 'Oculto';
    default:
      return 'Indefinido';
  }
};

export const texto_contracao = (value, maxLength) => {
  if (value.length >= maxLength)
    return value.substring(0, maxLength - 3) + '...';
  else return value;
};
