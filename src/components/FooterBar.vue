<template>
      <footer class="page-footer font-small blue pt-4" id="footer">
        <div class="container-fluid text-center text-md-left">
          <div class="row footer-content">
            <div class="col-md-6 mt-md-0 mt-3">
              <h5 class="text-uppercase">Footer Content</h5>
              <p>Here you can use rows and columns here to organize your footer content.</p>
            </div>
            <hr class="clearfix w-100 d-md-none pb-3">
            <div class="col-md-6 mb-md-0 mb-6">
              <h5 class="text-uppercase">Links</h5>
              <ul class="list-unstyled">
                <li>
                  <a href="#!">Link 1</a>
                </li>
                <li>
                  <a href="#!">Link 2</a>
                </li>
                <li>
                  <a href="#!">Link 3</a>
                </li>
                <li>
                  <a href="#!">Link 4</a>
                </li>
              </ul>
            </div>
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
    background-color: darkblue;
    color: white;
  }

  .footer-content{
    background-color: cornflowerblue;
  }
</style>
