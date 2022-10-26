import { createApp } from 'vue';
import App from './App.vue';

/* Fontawesome ***********************************************************************/
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

/* Solid Sharp Style */
import { faAlien, faHouse } from '@fortawesome/sharp-solid-svg-icons';

/* Solid Style */
import {
  faAddressCard,
  faCirclePlus,
  faUserSecret,
  faUser,
  faBookBookmark,
} from '@fortawesome/free-solid-svg-icons';

library.add(
  faUserSecret,
  faCirclePlus,
  faAddressCard,
  faAlien,
  faHouse,
  faUser,
  faBookBookmark,
);

/*************************************************************************************/

const globalApp = createApp(App);
globalApp.component('font-awesome-icon', FontAwesomeIcon);
globalApp.mount('#app');
