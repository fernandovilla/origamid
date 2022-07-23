<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link> |
    <router-link to="/fabricantes">Fabricantes</router-link> |
    <router-link to="/">Insumos</router-link>
  </nav>
  <router-view/>
</template>

<style>

  * {
    box-sizing: border-box;
  }

  #app {
    font-family: 'Segoe UI', Helvetica, Arial, sans-serif;
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
    background: url('./assets/pattern.svg') repeat top;
  }

  body, ul, li, h1, h2, p {
    padding: 0px;
    margin: 0px;
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
    padding: 10px;
    width: 100%;
  }

  @media screen and (max-width: 500px) {
    .content {
      /* grid-template-columns: 1fr; */
      display: flex;
      flex-direction: column;
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
