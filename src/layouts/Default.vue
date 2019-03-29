<template>
    <div class="all-content">
      <div id="wrapper">
        <header-bar id="header"/>

        <div class="main-content">
          <publicity id="publicity-left"/>
          <publicity id="publicity-right"/>
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

  .main-content{
    height: 100%;
  }

  #publicity-left{
    float:left;
    left:5%;
  }

  #publicity-right{
    float:right;
    right:-100%;
  }

  slot{
    width:70%;
  }

</style>
