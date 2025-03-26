export const getTodo = async () => {
  var data = await (
    await fetch('https://jsonplaceholder.typicode.com/todos')
  ).json();

  return data;
};
