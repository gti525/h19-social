<template>

    <div class="full-page">
      <div class="header">
        <img src="../images/logo.svg" class=" " alt="" id="logo">

      </div>
      <slot/>
    </div>

</template>

<script>
    export default {
        name: "Credentials"
    }
</script>

<style scoped>

  .full-page{
    height: 100%;
  }

  .header{
    background-color: var(--primary-color);
    height: 300px;
  }

  #logo{
    margin-top: 50px;
    height: 200px;
  }

</style>
