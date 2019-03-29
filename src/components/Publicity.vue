<template>
  <!-- Side navigation -->

  <div class="sidenav">
    <div class="publicity-content">
      <div id="vertical-analytic-banner"></div>
    </div>
  </div>
  <!-- Side navigation 
  <div class="sidebar">
    <div class="publicity-content">
      <div id="vertical-analytic-banner"></div>
    </div>
  </div>
  -->

</template>

<script>
     document.addEventListener("DOMContentLoaded",function()
     {const e="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTYzLCJpYXQiOjE1NTMxOTkzMDh9.avoFcsrtg5txsb4ZSQtDZnny-AajlA5RJfjCzsbRpRA";const t=function(){if("undefined"!=typeof Storage&&localStorage.getItem("gti525analytic")){const e=JSON.parse(localStorage.getItem("gti525analytic"));if(new Date(e.expiration).getTime()>(new Date).getTime())return e.clientId}return}();t?function(t){let n=new XMLHttpRequest;n.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/banners/code",!0),n.onload=function(o){4===n.readyState&&200===n.status&&Function(`return (${n.responseText})`)()(t,e)},n.setRequestHeader("x-access-token",e),n.send()}(t):function(){let t=new XMLHttpRequest;t.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/analytics/code",!0),t.onload=function(n){4===t.readyState&&200===t.status&&Function(`return (${t.responseText})`)()(e)},t.setRequestHeader("x-access-token",e),t.send()}()},!1);
</script>

<style scoped>

  /* The sidebar menu */
  
  .sidenav{
    position:sticky;

    top: 200px;
    width:20%;
    height: 575px;
  }

  .sidebar{
    position:sticky;

    top: 100px;
    width:20%;
    height: 575px;
  }

  .publicity-content{
    position:absolute;
   
    top:75px;
    width: 100%;
    height: 500px;
    left:-50px;
  }


</style>
