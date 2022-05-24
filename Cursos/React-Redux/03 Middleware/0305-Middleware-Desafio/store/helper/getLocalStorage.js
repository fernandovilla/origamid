const getLocalStorage = (key, defaultValue) => {
  try {
    return JSON.parse(window.localStorage.getItem(key));
  } catch (error) {
    return defaultValue;
  }
}

export default getLocalStorage;