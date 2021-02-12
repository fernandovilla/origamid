//'use strict' -> modulos já são 'use strict';

import initScrollSuave from './modules/scroll-suave.js'
import initScrollAnimacao from './modules/scroll-animacao.js'
import initAccordion from './modules/accordion.js'
import initTabNav from './modules/tabnav.js'
//import { testando1 as x, testando2 } from './modules/teste.js'
import * as t from './modules/teste.js'

initScrollSuave();

initScrollAnimacao();

initAccordion();

initTabNav();

//x();
//testando2();
t.testando1();
t.testando2();