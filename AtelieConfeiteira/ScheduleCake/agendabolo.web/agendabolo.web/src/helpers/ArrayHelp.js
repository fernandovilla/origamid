export const move_item = (arr, old_index, new_index) => {
  if (new_index >= arr.length) {
    var k = new_index - arr.length + 1;
    while (k--) {
      arr.push(undefined);
    }
  }
  arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
  // return arr; // for testing
};

export const sort_object = (arr, property_name) => {
  if (arr === null || arr === undefined || arr.length === 0) return arr;
  if (property_name === undefined) property_name = 0;

  return arr.sort((a, b) => {
    if (a[property_name] > b[property_name]) return 1;
    if (a[property_name] < b[property_name]) return -1;
    return 0;
  });
};
