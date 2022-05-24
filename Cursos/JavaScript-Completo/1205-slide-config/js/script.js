import Slide from './slide.js';

const slide = new Slide('.slide', '.slide-wrapper');
slide.init();
slide.changeSlide(0); //vai para o primeiro slide
slide.activeNextSlide(); //vai para o próximo slide
