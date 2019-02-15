<template>
  <!-- Side navigation -->
  <div class="sidenav">
    <div class="publicity-content">

    </div>
  </div>
</template>

<script>
    export default {
        name: "publicity"
    }
</script>

<style scoped>

  /* The sidebar menu */
  .sidenav {
    position:sticky;
    top: 20px;
    float:left;
    width:20%;
    height: 575px;
    left: 5%;
  }

  .publicity-content{
    background-image: url("../images/fakePublicity.png");
    position:absolute;
    top:75px;
    width: 100%;
    height: 500px;
  }


</style>
