<template>
      <footer class="page-footer font-small blue pt-4" id="footer">

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
