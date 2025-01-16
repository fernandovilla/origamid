import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

import {
  faUserSecret,
  faPen,
  faPenToSquare,
  faPlus,
  faTrash,
  faBackwardStep,
  faForwardStep,
  faCaretRight,
  faCaretLeft,
  faCircleXmark,
  faCaretUp,
  faCaretDown,
  faPrint,
  faSave,
} from '@fortawesome/free-solid-svg-icons';

// import {
//   faCirclePlus,
//   faCircleTrash,
//   faAngleDown,
//   faSearch,
// } from '@fortawesome/sharp-solid-svg-icons';

const FontawelsomeLibrary = (app) => {
  library.add(
    faUserSecret,
    /*faCirclePlus,*/
    /*faCircleTrash,*/
    faPen,
    faPenToSquare,
    faTrash,
    faPlus,
    faBackwardStep,
    faForwardStep,
    faCaretRight,
    faCaretLeft,
    /*faAngleDown,*/
    /*faSearch,*/
    faCircleXmark,
    faCaretUp,
    faCaretDown,
    faPrint,
    faSave,
  );

  app.component('font-awesome-icon', FontAwesomeIcon);
};

export default FontawelsomeLibrary;
