const select = document.querySelector('.select');
const content = document.querySelector('.content');
const selectBtn = select.querySelector('.select-btn');
const options = select.querySelector('.options');
const textSearch = select.querySelector('#textSearch');
var listItens = options.getElementsByTagName('li');

var index = -1;
var liSelected;

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

const listaAtivada = () => select.classList.contains('active');

const fillOptions = (arrayValues, selectedItem) => {
  var classItem = '';
  const newArray = arrayValues
    .map((item, i) => {
      if (item == selectedItem) {
        index = i;
        liSelected = listItens[index];
        classItem = 'selected';
      } else {
        classItem = '';
      }

      return `<li id="item-${i}" onclick="updateName(this)" class="${classItem}">${item}</li>`;
    })
    .join('');
  options.innerHTML = newArray ? newArray : '<p>Oops! Country not found</p>';
};
fillOptions(countries);

const updateName = (selectedLi) => {
  select.classList.remove('active');
  textSearch.value = '';
  fillOptions(countries, selectedLi.innerText);
  selectBtn.firstElementChild.innerText = selectedLi.innerText;
};

const scrollToSelected = (direction, forced) => {
  if (liSelected !== undefined) {
    var newPos = 0;

    if (direction === 'home' && forced) {
      newPos = 0;
    } else {
      var li = options.getElementsByTagName('li')[index];
      var liPos = li.getBoundingClientRect();
      var ulPos = options.getBoundingClientRect();

      var goDown =
        direction === 'down' || direction === 'down+' || direction === 'end';
      var goUp =
        direction === 'up' || direction === 'up+' || direction === 'home';

      //var atingiuBotton = li.offsetTop + li.offsetHeight >= options.offsetTop + options.offsetHeight;
      var atingiuBotton = liPos.bottom > ulPos.bottom;

      var atingiuTop = liPos.top <= ulPos.top;

      if (atingiuBotton && goDown) {
        newPos =
          li.offsetTop -
          (options.offsetTop + options.offsetHeight - li.offsetHeight);
      } else if (atingiuTop && goUp) {
        newPos = li.offsetTop - li.offsetHeight - 30;
      }
    }

    if (newPos !== 0 || forced) {
      options.scroll({
        top: newPos,
        left: 0,
        behavior: 'auto',
      });
    }
  }
};

const removeSelected = (element) => {
  if (element !== undefined) {
    element.classList.remove('selected');
  }
};

const addSelected = (element) => {
  if (element !== undefined) {
    element.classList.add('selected');
  }
};

const moveItem = (direction) => {
  var len = listItens.length - 1;

  removeSelected(liSelected);

  if (direction === 'down' || direction === 'down+') {
    if (liSelected) {
      index++;
      if (typeof listItens[index] !== undefined && index <= len) {
        //mantem o index...
      } else {
        index = 0;
        direction = 'up';
      }
    } else {
      index = 0;
    }
  } else if (direction === 'up' || direction === 'up+') {
    if (liSelected) {
      index--;
      if (typeof listItens[index] !== undefined && index >= 0) {
        //mantem o index...
      } else {
        index = len;
        direction = 'down';
      }
    } else {
      index = len;
    }
  } else if (direction === 'home') {
    index = 0;
  } else if (direction === 'end') {
    index = len;
  }

  liSelected = listItens[index];

  setTimeout(() => {
    addSelected(liSelected);
    scrollToSelected(direction);
  }, 30);
};

const selectItem = () => {
  var li = options.getElementsByTagName('li')[index];
  updateName(li);
};

const activeListItems = () => {
  if (!listaAtivada()) {
    select.classList.add('active');
    textSearch.focus();

    if (selectBtn.firstElementChild.innerText !== undefined) {
      const text = selectBtn.firstElementChild.innerText;
      textSearch.value = text;
      scrollToSelected('down');
    }
  } else {
    scrollToSelected('home', true);
    select.classList.remove('active');
  }
};

const textSearchHandleKeyDown = (event) => {
  switch (event.keyCode) {
    case 34:
    case 40:
      moveItem('down');
      return;
    case 33:
    case 38:
      moveItem('up');
      break;
    case 36:
      moveItem('home');
      break;
    case 35:
      moveItem('end');
      break;
    case 13:
      selectItem();
      break;
    case 27:
      activeListItems();
      break;
  }
};

const textSearchHandleKeyUp = (event) => {
  var navigateKeys = [33, 34, 38, 40];
  if (navigateKeys.includes(event.keyCode)) return;

  const valueSearch = textSearch.value.toUpperCase().trim();

  if (textSearch.value.length >= 1) {
    const arrFiltered = countries.filter((item) =>
      item.toUpperCase().startsWith(valueSearch),
    );

    fillOptions(arrFiltered);
  } else {
    fillOptions(countries);
  }
};

const docHandleClick = (event) => {
  var posSelect = select.getBoundingClientRect();
  var x = event.clientX + 1;
  var y = event.clientY + 1;
  var ativado = select.classList.contains('active');

  var clicouDentroSelect = false;
  if (
    x >= posSelect.left &&
    x <= posSelect.right &&
    y >= posSelect.top &&
    y <= posSelect.bottom
  ) {
    clicouDentroSelect = true;

    if (!ativado) {
      activeListItems();
      return;
    } else {
      activeListItems();
    }
  }

  var clicouDentroContent = false;
  var posContent = content.getBoundingClientRect();

  if (
    x >= posContent.left &&
    x <= posContent.right &&
    y >= posContent.top &&
    y <= posContent.bottom
  ) {
    clicouDentroContent = true;
  }

  if (!clicouDentroSelect && !clicouDentroContent) {
    setTimeout(() => {
      scrollToSelected('home', true);
      select.classList.remove('active');
    }, 50);
  }
};

const selectHandleKeyUp = (event) => {
  if (
    (event.keyCode === 40 || event.keyCode === 13 || event.keyCode === 27) &&
    !listaAtivada()
  ) {
    activeListItems();
  }
};

textSearch.addEventListener('keydown', textSearchHandleKeyDown, false);

textSearch.addEventListener('keyup', textSearchHandleKeyUp, false);

select.addEventListener('keyup', selectHandleKeyUp, false);

document.addEventListener('click', docHandleClick, false);
