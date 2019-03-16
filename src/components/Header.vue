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
        <input class="form-control mr-sm-2" type="search" v-model="input.username" placeholder="Rechercher un(e) ami(e)" aria-label="Search">
        <button class="btn btn-outline-success my-2 my-sm-0" @click="getFriends" type="submit">Rechercher</button>
      </form>
    </div>

     <div>
       <b-dropdown variant="link" right size="lg" no-caret>
         <template slot="button-content"><img :src="this.profileImage" width="30px"/> <span class="sr-only">Search</span></template>


         <b-dropdown-item v-on:click="Reload()"> <router-link to="/tickets">Mon profil</router-link> </b-dropdown-item>
         <b-dropdown-item v-on:click="Deconnexion()"> <router-link to="/">Déconnexion </router-link></b-dropdown-item>
       </b-dropdown>

       <b-dropdown variant="link" right size="lg" no-caret>
         <template slot="button-content"><img width="30px" src="https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF"/> <span class="sr-only">Search</span></template>

         <b-dropdown-item v-on:click="Reload()"> <router-link to="/tickets">Accueil</router-link></b-dropdown-item>
         <b-dropdown-item> <router-link to="/friendRequests">Invitations</router-link> </b-dropdown-item>
         <b-dropdown-item> <router-link to="/parametres">Paramètres</router-link> </b-dropdown-item>
       </b-dropdown>
     </div>


  </nav>
</template>

<script>
    export default {
      profileImage: "../images/defaultAvatar.svg",
        name: "Header",
      data() {
        return {
          input: {
            username: ""
          },
      }
        },
      methods: {
        getFriends()
        {
          var path = 'https://localhost:5001/api/friend/search?friendUsername=' + this.input.username;
          this.$http.get(path, {
            headers: {
              Authorization: "Bearer " + localStorage.getItem("token")
            }
          }).then(response => {
            var path2 = 'https://localhost:5001/api/Client/friend';
            this.$http.get(path2, {
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
              }
            ).then(response2 => {
              var isFriend = false;
              var i;
              for (i = 0; i < response2.data.length; i++) {
                if(response2.data[i].ClientId == response.data.ClientId)
                {
                  location.reload(true);
                  isFriend = true;
                  localStorage.setItem("FriendIdForTickets", response.data.ClientId.toString());
                  localStorage.setItem("FriendNameForTickets", response.data.FirstName);
                  this.$router.push('FriendTickets');
                }
              }
              if(isFriend == false){
                alert("lui, c pas mon ami");
                location.reload(true);
                localStorage.setItem("ClientUsernameForAdding", this.input.username);
                this.$router.push('Client');
              }
            });

            this.myFriends = response.data;
          });
        },
          Reload(){
              location.reload(true);
          },
          Deconnexion(){
            localStorage.clear();
          },
          getImg() {
            this.profileImage = localStorage.getItem("profileImage");
          }
      },
      beforeMount() {
          this.getImg();
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
