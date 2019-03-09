<template>
      <footer class="page-footer font-small blue pt-4" id="footer">


        <div class="footer-copyright text-center py-3">
          © 2019 Copyright: MyEventory
        </div>
      </footer>
</template>

<script>
    export default {
        name: "FooterBar"
    }
</script>

<style scoped>
  .footer-copyright{
    background-color: var(--tertiary-color);
    color: white;
  }

  .footer-content{
    background-color: var(--secondary-color);
  }
</style>
