const select = document.querySelector('.select');
const selectBtn = select.querySelector('.select-btn');
const options = select.querySelector('.options');
const textSearch = select.querySelector('#textSearch');

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
      (item) =>
        `<li onclick="updateName(this)" class="${
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

    var selectedLI = options.querySelector('li.selected');
    if (selectedLI !== undefined) {
        options.scroll({
        top: selectedLI.offsetTop - options.offsetTop,
        left: 0,
        behavior: 'smooth',
      });
    }
  }
});

textSearch.addEventListener('keyup', () => {
  const valueSearch = textSearch.value.toUpperCase().trim();

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
  setTimeout(() => {
    select.classList.remove('active');
  }, 200);
});
