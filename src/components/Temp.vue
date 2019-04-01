<template>
    
</template>

<script>
  export default {
    name: "Temp",
    methods:
      {
        RedirectPage () {
          this.$router.push(localStorage.getItem("redirectPage"));
        }
      },
    beforeMount(){
      this.RedirectPage();
    },
  }
</script>

<style scoped>

</style>
