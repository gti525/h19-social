<template>
    <div class="all-content">
      <div id="wrapper">
        <header-bar id="header"/>

        <div class="main-content">
          <publicity id="publicity"/>
          <slot id="main-view"/>
        </div>
      </div>
      <footer-bar id="footer"/>
    </div>
</template>

<script>
  import FooterBar from "@/components/FooterBar.vue";
  import HeaderBar from "@/components/Header.vue";
  import Publicity from "@/components/Publicity.vue";

  export default {
        name: "Default",
      components:{
          FooterBar,
          HeaderBar,
          Publicity
      }
    }

</script>

<style scoped>

  .all-content {
    height: 100%;
    display:flex;
    flex-direction: column;
    flex: 1;
  }
  #wrapper {
    flex: 1;
  }

  #header{
    z-index: 1;
  }

  #footer{
  }

  .main-content{
    height: 100%;
  }

  #publicity{
  }

  #main-view{
  }

  slot{
    width:70%;
  }


 /* #push {
    height:224px;
  }*/

</style>
