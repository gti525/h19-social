<template>
  <div  id="MyFriends">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">{{this.pageTitle}}</h1>
    <b-list-group class="justify-content-between align-items-center mt-4">
      <b-list-group-item class="friends" v-bind:id="index" button v-for="(friend,index) in myFriends" v-b-modal.modallg v-on:click="OpenFriendPage(friend.ClientId, friend.FirstName)">
        <div class="profile-image">
          <img v-bind:src="friend.ProfileImage" height="100%"></img>
        </div>
        <div class="friend-info">
          <div class="friend-name">
            {{ friend.FirstName + " " + friend.LastName }}
          </div>
        </div>
      </b-list-group-item>
    </b-list-group>


  </div>
</template>

<script>
import api from '../App'

  export default {
    name: "MyFriends",
    data() {
      return {
        myFriends: [],
        ClientId :0,
        pageTitle: 'Mes ami(e)s'
      }
    },

    methods:
      {
          getFriends()
          {
            var path = api.data().url + 'api/Client/friend';
              this.$http.get(path, {
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
            }
          ).then(response => {
              this.myFriends = response.data;
          });
        },
        OpenFriendPage(id, name)
        {
          localStorage.setItem("FriendIdForTickets", id);
          localStorage.setItem("FriendNameForTickets", name);
          this.$router.push('FriendTickets');
        },
      },
    beforeMount() {
      this.getFriends();
    }
  }
</script>

<style scoped>
  #MyFriends{
    width:800px;
    margin:auto;
    left:50%;
  }

  .friends{
    height: 150px;
    width: 700px;
    padding: 0px;
    margin-bottom: 20px;
    z-index: 0;
  }
  .profile-image{
    width: 20%;
    height: 100%;
    float: left;
    border-style: solid;
    border-width: 0px 2px 0px 0px;
    border-color: var(--primary-color);
  }

  .friend-info{
    width:80%;
    float: right;
    height:100%;
    background-color: white;
  }

  .friend-name{
    width:60%;
    float:left;
    font-size: 25px;
    position: relative;
    top:25%;
  }


  .list-group-item:hover .friend-info{
    background-color: var(--secondary-color);
  }


  .h1 {
    color: #495057;
    left:0;
  }


</style>
