const select = document.querySelector('.select');
const selectBtn = select.querySelector('.select-btn');
const options = select.querySelector('.options');
const textSearch = select.querySelector('#textSearch');

var ismoving = false;
var movingTimeout = -1;
var direction = '';

var selectedItem;

const countries = [
  'Australia',
  'Alemanha',
  'Argentina',
  'Belgica',
  'Brasil',
  'Bulgaria',
  'Canada',
  'Costa Rica',
  'Dinamarca',
  'Estados Unidos',
  'França',
  'Groelandia',
  'Holanda',
  'Inglaterra',
  'Italia',
  'Ira',
  'Jamaica',
  'Japao',
  'Libano',
  'Lituania',
  'Mexico',
  'Noruega',
  'Portugal',
  'Qatar',
  'Quenia',
  'Romenia',
  'Russia',
  'Suecia',
  'Suica',
  'Turkia',
  'Ucrania',
  'Venezuala',
  'Zimbabue',
];

const fillOptions = (arrayValues, selectedItem) => {
  const newArray = arrayValues
    .map(
      (item, index) =>
        `<li id="item-${index + 1}" onclick="updateName(this)" class="${
          item === selectedItem ? 'selected' : ''
        }">${item}</li>`,
    )
    .join('');
  options.innerHTML = newArray ? newArray : '<p>Oops! Country not found</p>';
};

const updateName = (selectedLi) => {
  select.classList.remove('active');
  textSearch.value = '';
  fillOptions(countries, selectedLi.innerText);
  selectBtn.firstElementChild.innerText = selectedLi.innerText;
};

fillOptions(countries);

selectBtn.addEventListener('click', () => {
  select.classList.toggle('active');
  textSearch.focus();

  if (selectBtn.firstElementChild.innerText !== undefined) {
    const text = selectBtn.firstElementChild.innerText;

    moveToSelected();
  }
});

const moveToSelected = () => {
  var selectedLI = options.querySelector('.options li.selected');
  if (selectedLI !== undefined) {
    options.scroll({
      top: selectedLI.offsetTop - options.offsetTop,
      left: 0,
      behavior: 'smooth',
    });
  }
};

const selectItem = (direction) => {
  var currItem;

  if (selectedItem !== undefined) currItem = selectedItem;
  else currItem = options.querySelector(`.options li.selected`);

  console.log('currItem:', currItem);

  if (currItem !== null) {
    currItem.classList.remove('selected');

    var nextItem;
    if (direction === 'down') {
      nextItem = currItem.nextSibling;
    } else {
      nextItem = currItem.previousSibling;
    }
    nextItem.classList.add('selected');

    selectedItem = nextItem;

    moveToSelected();
    return;
  }

  var firstItem = options.querySelector(`.options li:first-child`);
  firstItem.classList.add('selected');

  selectedItem = nextItem;

  moveToSelected();
};

const startMoving = (direction) => {
  if (movingTimeout === -1) {
    moving(direction);
  }
};

const stopMoving = () => {
  clearTimeout(movingTimeout);
  movingTimeout = -1;
};

const moving = (direction) => {
  selectItem(direction);
  movingTimeout = setTimeout(moving, 150, direction);
};

textSearch.addEventListener('keydown', (events) => {
  if (events.keyCode === 40) direction = 'down';
  else if (events.keyCode === 38) direction = 'up';

  if (direction !== '') {
    startMoving(direction);
    return true;
  }

  return false;
});

textSearch.addEventListener('keyup', (events) => {
  stopMoving();

  console.log('zerou');

  const valueSearch = textSearch.value.toUpperCase().trim();
  itemSelecionado = 0;

  if (textSearch.value.length >= 1) {
    const arrFiltered = countries.filter((item) =>
      item.toUpperCase().startsWith(valueSearch),
    );

    fillOptions(arrFiltered);
  } else {
    fillOptions(countries);
  }
});

textSearch.addEventListener('focusout', () => {
  /*
  setTimeout(() => {
    select.classList.remove('active');
  }, 200);
  */
});

select.addEventListener('focusout', () => {
  setTimeout(() => {
    select.classList.remove('active');
    itemSelecionado = 0;
  }, 200);
});
