import debounce from './debounce.js';

export default class Slide {
  constructor(slide, wrapper) {
    this.slide = document.querySelector(slide);
    this.wrapper = document.querySelector(wrapper);

    this.dist = {
      finalPosition: 0,
      startX: 0,
      movement: 0,
    };

    this.activeClass = 'active';
  }

  transition(active){
    if (active){
      this.slide.style.transition = 'transform .3s';
    } else {
      this.slide.style.transition = '';
    }
  }

  moveSlide(distX) {
    this.dist.movePosition = distX;
    this.slide.style.transform = `translate3d(${distX}px, 0, 0)`;
  }

  updatePosition(clientX) {
    this.dist.movement = (this.dist.startX - clientX) * 1.5;
    return this.dist.finalPosition - this.dist.movement;
  }

  onStart(event) {
    if (event.type === 'mousedown'){
      event.preventDefault();
      this.dist.startX = event.clientX;
      this.wrapper.addEventListener("mousemove", this.onMove);
    } else {
      this.dist.startX = event.changedTouches[0].clientX
      this.wrapper.addEventListener("touchmove", this.onMove);
    }
    this.transition(false);
  }

  onMove(event) {
    const pointerPosition = (event.type === 'mousemove')
      ? event.clientX
      : event.changedTouches[0].clientX;
    const finalPosition = this.updatePosition(pointerPosition);
    
    this.moveSlide(finalPosition);
  }

  onEnd(event) {
    const moveType = (event.type === 'mouseup') ? 'mousemove' : 'touchmove';

    this.wrapper.removeEventListener(moveType, this.onMove);
    this.dist.finalPosition = this.dist.movePosition;
    
    this.transition(true);
    this.changeSlideOnEnd();
  }

  addSlideEvents() {
    this.wrapper.addEventListener("mousedown", this.onStart);   
    this.wrapper.addEventListener("mouseup", this.onEnd);

    this.wrapper.addEventListener("touchstart", this.onStart);
    this.wrapper.addEventListener("touchend", this.onEnd);
  }

  

  slideIndexNav(index){
    const last = this.slideArray.length-1;
    this.index = {
      prev: (index ? index - 1 : undefined),  //  Se index < 0
      active: index,
      next: (index === last ? undefined : index + 1), //  Se index === tamanho do array
    }
  }

  changeSlide(index){
    const activeSlide = this.slideArray[index];
    this.moveSlide(activeSlide.position);
    this.slideIndexNav(index);
    this.dist.finalPosition = activeSlide.position;
    this.changeActiveClass();
  }

  changeActiveClass(){
    this.slideArray.forEach(item => item.element.classList.remove(this.activeClass));
    this.slideArray[this.index.active].element.classList.add(this.activeClass);
  }

  changeSlideOnEnd(){
    if (this.dist.movement > 120 && this.index.next !== undefined){
      this.activeNextSlide();
    } else if (this.dist.movement < -120 && this.index.prev !== undefined) {
      this.activePrevSlide();
    } else {
      this.changeSlide(this.index.active);
    }
  }

  activePrevSlide(){
    if (this.index.prev !== undefined){
      this.changeSlide(this.index.prev);
    }
  }

  activeNextSlide(){
    if (this.index.next !== undefined){
      this.changeSlide(this.index.next);
    }
  }

  slidePosition(slide){
    const margin = (this.wrapper.offsetWidth - slide.offsetWidth) / 2;
    return -(slide.offsetLeft - margin);
  }

  //  Slide config
  slidesConfig(){
    const result = this.slideArray = [...this.slide.children].map(element => {
      const position = this.slidePosition(element);
      return {
        position,
        element
      }
    })
    console.log(result);
  }

  onResize(){
    setTimeout(() => {
      this.slidesConfig();
      this.changeSlide(this.index.active);  
    }, 1000);
    
  }

  addResizeEvent(){
    window.addEventListener('resize', this.onResize);
  }

  bindEvents() {
    this.onStart = this.onStart.bind(this);
    this.onMove = this.onMove.bind(this);
    this.onEnd = this.onEnd.bind(this);
    this.onResize = debounce(this.onResize.bind(this), 200);
  }

  init() {
    this.bindEvents();
    this.transition(true);
    this.addSlideEvents();
    this.addResizeEvent();
    this.slidesConfig();    
    this.changeSlide(0);
    return this;
  }
}
