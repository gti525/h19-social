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
    top: 0;
    float:left;
    width:20%;
    height: 800px;
    left: 5%;
  }

  .publicity-content{
    background-image: url("../images/fakePublicity.png");
    position:absolute;
    top:100px;
    width: 100%;
    height: 500px;
  }


</style>
