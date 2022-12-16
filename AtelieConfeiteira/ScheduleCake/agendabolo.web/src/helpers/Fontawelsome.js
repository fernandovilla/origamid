import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

import {
  faUserSecret,
  faPen,
  faPenToSquare,
  faTrash,
  faBackwardStep,
  faForwardStep,
  faCaretRight,
  faCaretLeft,
  faCircleXmark,
} from '@fortawesome/free-solid-svg-icons';

import {
  faCirclePlus,
  faAngleDown,
  faSearch,
} from '@fortawesome/sharp-solid-svg-icons';

const FontawelsomeLibrary = (app) => {
  library.add(
    faUserSecret,
    faCirclePlus,
    faPen,
    faPenToSquare,
    faTrash,
    faBackwardStep,
    faForwardStep,
    faCaretRight,
    faCaretLeft,
    faAngleDown,
    faSearch,
    faCircleXmark,
  );

  app.component('font-awesome-icon', FontAwesomeIcon);
};

export default FontawelsomeLibrary;
