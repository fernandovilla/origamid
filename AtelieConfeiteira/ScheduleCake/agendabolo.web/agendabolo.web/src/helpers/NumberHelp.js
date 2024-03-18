export const TextToNumber = (value) => {
  if (value !== undefined) {
    try {
      if (isNaN(value)) {
        return Number(value.replace(',', '.'));
      } else {
        return Number(value);
      }
    } catch (e) {
      console.log(e);
    }
  }
};

export const NumberToText = (value) => {
  if (isNaN(value)) {
    return '0';
  } else {
    return value.toString().replace('.', ',');
  }
};
