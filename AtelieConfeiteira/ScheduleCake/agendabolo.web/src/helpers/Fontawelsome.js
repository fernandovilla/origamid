import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

import {
  faUserSecret,
  faPen,
  faPenToSquare,
  faPlus,
  faTrash,
  faCaretRight,
  faCaretLeft,
  faCircleXmark,
  faCaretUp,
  faCaretDown,
  faPrint,
  faSave,
  faTriangleExclamation,
  faCirclePlus,
  faBars,
  faArrowLeft,
  faBackward,
  faBackwardStep,
  faForward,
  faForwardStep,
  faSearch
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
    faBackward,
    faBackwardStep,
    faForward,
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
    faTriangleExclamation,
    faCirclePlus,
    faBars,
    faArrowLeft,
    faSearch
  );

  app.component('font-awesome-icon', FontAwesomeIcon);
};

export default FontawelsomeLibrary;
