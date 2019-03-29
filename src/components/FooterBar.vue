<template>
      <footer class="page-footer font-small blue pt-4" id="footer">
        <div class="publicity-content">
      <div id="vertical-analytic-banner"></div>
      </div>
        <div class="container-fluid text-left">
          <div class="row footer-content">
            <div class="col-md-6 mt-md-0 mt-3">
              <h5 class="text-uppercase"></h5><p></p>
            </div>
            <hr class="clearfix w-100 d-md-none pb-3">
          </div>
        </div>

        <div class="footer-copyright text-center py-3">
          © 2019 Copyright: MyEventory
        </div>
      </footer>
</template>

<script>
    export default {
        name: "FooterBar"
    }
    document.addEventListener("DOMContentLoaded",function()
     {const e="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTYzLCJpYXQiOjE1NTMxOTkzMDh9.avoFcsrtg5txsb4ZSQtDZnny-AajlA5RJfjCzsbRpRA";const t=function(){if("undefined"!=typeof Storage&&localStorage.getItem("gti525analytic")){const e=JSON.parse(localStorage.getItem("gti525analytic"));if(new Date(e.expiration).getTime()>(new Date).getTime())return e.clientId}return}();t?function(t){let n=new XMLHttpRequest;n.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/banners/code",!0),n.onload=function(o){4===n.readyState&&200===n.status&&Function(`return (${n.responseText})`)()(t,e)},n.setRequestHeader("x-access-token",e),n.send()}(t):function(){let t=new XMLHttpRequest;t.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/analytics/code",!0),t.onload=function(n){4===t.readyState&&200===t.status&&Function(`return (${t.responseText})`)()(e)},t.setRequestHeader("x-access-token",e),t.send()}()},!1);
</script>

<style scoped>
  .footer-copyright{
    background-color: var(--tertiary-color);
    color: white;
  }

  .footer-content{
    background-color: var(--secondary-color);
  }

  .publicity-content{
    position:absolute;
   
    top:75px;
    width: 100%;
    height: 500px;
    left:-50px;
  }

</style>
