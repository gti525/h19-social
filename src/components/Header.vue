<template>
   <nav class="navbar navbar-light justify-content-between">
    <div class="logo-section " v-on:click="Reload()">
      <a class="navbar-brand">
        <router-link to="/tickets">
          <img src="../images/logo-primary.svg" height="50" class=" " alt="" id="logo">
        </router-link>
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

         <b-dropdown-item v-on:click="Reload()"> <router-link to="/tickets">Mon profil</router-link> </b-dropdown-item>
         <b-dropdown-item v-on:click="Deconnexion()"> <router-link to="/">Déconnexion </router-link></b-dropdown-item>
       </b-dropdown>

       <b-dropdown variant="link" right size="lg" no-caret>
         <template slot="button-content"><img width="30px" src="https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF"/> <span class="sr-only">Search</span></template>

         <b-dropdown-item v-on:click="Reload()"> <router-link to="/tickets">Accueil</router-link></b-dropdown-item>
         <b-dropdown-item> <router-link to="/friendRequests">Invitations</router-link> </b-dropdown-item>
         <b-dropdown-item href="#">Paramètres</b-dropdown-item>
       </b-dropdown>
     </div>


  </nav>
</template>

<script>
    export default {
        name: "Header",
      methods: {
          Reload(){
              location.reload(true);
          },
          Deconnexion(){
            //clearCache here
          }
      }
    }
</script>

<style scoped>
  .navbar{
    position:sticky;
    top: 0;
    background-color: var(--light-color);
  }
  .form-control{
    width:500px;
  }
</style>
