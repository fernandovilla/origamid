const select = document.querySelector('.select');
const selectBtn = select.querySelector('.select-btn');
const options = select.querySelector('.options');
const textSearch = select.querySelector('#textSearch');

var index = -1;
var liSelected;
var listItens = options.getElementsByTagName('li');

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

const updateName = (selectedLi) => {
  select.classList.remove('active');
  textSearch.value = '';
  fillOptions(countries, selectedLi.innerText);
  selectBtn.firstElementChild.innerText = selectedLi.innerText;
};

fillOptions(countries);

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

const removeClass = (element) => {
  if (element !== undefined) {
    element.classList.remove('selected');
  }
};

const addClass = (element) => {
  if (element !== undefined) {
    element.classList.add('selected');
  }
};

const moveItem = (direction) => {
  var len = listItens.length - 1;

  removeClass(liSelected);

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
    addClass(liSelected);
    scrollToSelected(direction);
  }, 30);
};

const selecionaItem = () => {
  var li = options.getElementsByTagName('li')[index];
  updateName(li);
};

const handleKeyDown = (event) => {
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
      selecionaItem();
      break;
  }
};

const handleKeyUp = (event) => {
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

textSearch.addEventListener('keydown', handleKeyDown, false);

textSearch.addEventListener('keyup', handleKeyUp, false);

select.addEventListener('focusout', () => {
  setTimeout(() => {
    scrollToSelected('home', true);
    select.classList.remove('active');
  }, 100);
});

select.addEventListener('focus', () => {
  ativaLista();
});

const ativaLista = () => {
  if (!select.classList.contains('active')) {
    select.classList.add('active');
    textSearch.focus();

    if (selectBtn.firstElementChild.innerText !== undefined) {
      const text = selectBtn.firstElementChild.innerText;
      scrollToSelected('down');
    }
  } else {
    scrollToSelected('home', true);
    select.classList.remove('active');
  }
};

selectBtn.addEventListener('keyup', (event) => {
  if (event.keyCode === 40) {
    ativaLista();
  }
});

selectBtn.addEventListener('click', () => {
  ativaLista();
});
