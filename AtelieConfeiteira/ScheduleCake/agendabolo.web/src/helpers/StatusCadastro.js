const StatusCadastro = (value) => {
  switch (value) {
    case 1:
      return 'Ativo';
    case 2:
      return 'Bloqueado';
    case 3:
      return 'Excluído';
  }
};

export default StatusCadastro;
