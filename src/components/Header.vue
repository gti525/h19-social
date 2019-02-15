<template>
   <nav class="navbar navbar-light bg-light justify-content-between">
    <div class="logo-section ">
      <a class="navbar-brand" href="#">
        <img src="../images/logo.svg" height="50" class=" " alt="" id="logo">
      </a>
    </div>
    <div class="search-section">
      <form class="form-inline my-2 my-lg-0">
        <input class="form-control mr-sm-2" type="search" placeholder="Rechercher un(e) ami(e)" aria-label="Search">
        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Rechercher</button>
      </form>
    </div>

     <div>
       <b-dropdown variant="link" right size="lg" no-caret>
         <template slot="button-content"><img width="30px" src="../images/defaultAvatar.svg"/> <span class="sr-only">Search</span></template>

         <b-dropdown-item href="#">Modifier le profil</b-dropdown-item>
         <b-dropdown-item href="#">Déconnexion</b-dropdown-item>
       </b-dropdown>

       <b-dropdown variant="link" right size="lg" no-caret>
         <template slot="button-content"><img width="30px" src="https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF"/> <span class="sr-only">Search</span></template>

         <b-dropdown-item href="#">Action</b-dropdown-item>
         <b-dropdown-item href="#">Another action</b-dropdown-item>
         <b-dropdown-item href="#">Something else here...</b-dropdown-item>
       </b-dropdown>
     </div>


  </nav>
</template>

<script>
    export default {
        name: "Header"
    }
</script>

<style scoped>

  .navbar-toggler-icon{
  background-image: url("https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF");
  }

  .form-control{
    width:500px;
  }

  #ddown-account{
    background-image: none;
    background-image: url("https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF");
  }

</style>
