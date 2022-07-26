<template>
  <header class="header">
    <router-link to="/">Home</router-link> |    
  </header>
    
  <div class="main">
    <menu-lateral class="menu-lateral" />
    <router-view class="body"/>
  </div>
</template>

<script>
import MenuLateral from './components/MenuLateral.vue'

export default {
  components: {
    MenuLateral
  }
}
</script>

<style>
  .header {
    background: #1d2327;
    height: 30px;    
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .header a {
    color: #fff;
  }

  .main {
    display: flex;   
  }
  
  .menu-lateral {
    flex-grow: 0;
    flex-shrink: 0;
    overflow: hidden;
    flex-basis: 160px;
  }

  .body {
    padding: 20px;
    flex-grow: 1;
    flex-shrink: 1;
    overflow: auto;
    height: calc(100vh - 30px);
  }

  * {
    box-sizing: border-box;
  }

  #app {
    font-family: 'Segoe UI', Helvetica, Arial, sans-serif;
    font-size: 0.853rem;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #1D2327
  }

  h1 {
    font-size: 1.4rem;
    font-weight: 400;  
  }

  h2 {
    font-size: 1.2rem;
    font-weight: 300;
  }

  body {        
    /* background: url('./assets/pattern.svg') repeat top; */
    background-color: #f0f0f1;
  }

  body, ul, li, h1, h2, p {
    padding: 0px;
    margin: 0px;
  }

  label, input {
    width: 100%;
    text-align: start;
    font-size: 0.85rem;
  }

  input {
    border: none;
    border-bottom: 1px solid #8c8f94;    
    line-height: 20px;    
    padding: 5px 5px;
    text-transform: uppercase;
    /* transition: border-bottom 0.1s;     */
    margin-bottom: 2px;
    outline: none;    
  }

  input:active, input:focus {
    /*border-bottom: 2px solid #2271b1;*/
    /* box-shadow: 0px 0px 0px 1px red inset; */
    /* outline: 2px solid red;
    outline-offset: -10px; */
    border-bottom: 2px solid #2271b1;
    margin-bottom: 1px;
    background: #f0f0f1;
  }
  
  .input-group {
    display: flex;
    flex-direction: column;
  }

  ul {
    list-style: none;
  }

  a {
    color: #345;
    text-decoration: none;
  } 

  h1{
    text-align: start;
  }

  .content {
    display: grid;
    grid-template-columns: repeat(12,1fr);
    grid-gap: 10px;
    max-width: 1200px;
  }

  @media screen and (max-width: 500px) {
    .content {
      /* grid-template-columns: 1fr; */
      display: flex;
      flex-direction: column;
    }

    .menu-lateral {
      display: none;
    }
  }

  .row1 {
    grid-row: 1;
  }

  .row2 {
    grid-row: 2;
  }

  .row3 {
    grid-row: 3;
  }

  .row4 {
    grid-row: 4;
  }

  .row5 {
    grid-row: 5;
  }

  .row6 {
    grid-row: 6;
  }

  .row7 {
    grid-row: 7;
  }

  .row8 {
    grid-row: 8;
  }

  .row9 {
    grid-row: 9;
  }

  .row10 {
    grid-row: 10;
  }

  
  .span1 {
    grid-column: span 1;
  }

  .span2 {
    grid-column: span 2;
  }

  .span3 {
    grid-column: span 3;
  }

  .span4 {
    grid-column: span 4;
  }

  .span5 {
    grid-column: span 5;
  }

  .span6 {
    grid-column: span 6;
  }

  .span7 {
    grid-column: span 7;
  }

  .span8 {
    grid-column: span 8;
  }

  .span9 {
    grid-column: span 9;
  }

  .span10 {
    grid-column: span 10;
  }

  .span11 {
    grid-column: span 11;
  }

  .span12 {
    grid-column: span 12;
  }
  
  .btn {
    display: block;
    border: none;
    border-radius: 4px;
    padding: 10px 20px;
    font-size: 0.8rem;    
    font-family: 'Segoe UI', Helvetica, Arial, sans-serif;
    text-align: center;
    box-shadow: 0 4px 8px rgba(30,60,90,0.2);
    cursor: pointer;
    transition: all .3s;
    max-width: 150px;
    outline: none;
  }

  .btn.primary {    
    background: #2271b1;    
    color: #fff;
  }

  .btn:hover {
    opacity: .95;
    transform: scale(1.04);
  }

</style>
