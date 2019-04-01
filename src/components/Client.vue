<template>
  <div  id="Client">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">{{this.pageTitle}}</h1>
    <b-list-group  class="justify-content-between align-items-center mt-4 client-row">

        <div class="friend-info">
          <div class="profile-image">
            <img v-bind:src="Client.ProfileImage" height="100%"></img>
          </div>
          <div class="friend-name">
            {{ getFirstName + " " + Client.LastName }}
          </div>
          <div class="friend-option">
            <button v-if="!isRequested()" type="button" class="btn btn-primary" variant="primary" v-on:click="sendFriendRequest(Client.ClientId)">Ajouter</button>
            <button v-else type="button" class="btn btn-secondary" disabled variant="primary">En attente</button>
          </div>
        </div>
    </b-list-group>


  </div>
</template>

<script>
  export default {
    name: "Client",
    data() {
      return {
        friendRequested: [],
        myFriendRequests: [],
        Client: [],
        pageTitle: 'Invitations'
      }
    },

    computed:
      {
        getFirstName: function () {
          return this.Client.FirstName;
        },
      },

    methods:
      {
        isRequested () {
          var friend = false;
          for(var i=0; i < this.friendRequested.length; i++)
          {
            if(this.friendRequested[i].ClientId == this.Client.ClientId){
              friend = true;
            }
          }
          return friend;
        },

        isRequest () {
          var friend = false;
          console.log("etape 3");
          console.log(this.myFriendRequests);
          for(var i=0; i < this.myFriendRequests.length; i++)
          {
            if(this.myFriendRequests[i].ClientId == this.Client.ClientId){
              friend = true;
            }
          }
          return friend;
        },

        getFriendRequested()
        {
          var path = 'https://localhost:5001/api/friend/friendrequested';
          this.$http.get(path, {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {
            this.friendRequested = response.data;
            console.log(this.friendRequested);
          }, response => {
            // error callback
            console.log(response);
          });
        },

        getFriendRequest ()
        {
          var path = 'https://localhost:5001/api/friend/friendrequest';

          this.$http.get(path, {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {
            this.myFriendRequests = response.data;
            console.log("etape 2");
            console.log(this.myFriendRequests);

          }, response => {
            // error callback
            console.log(response);
          });
        },

        getClient ()
        {
          console.log("etape 1");
          console.log(this.myFriendRequests);

          this.getFriendRequested();
         // this.getFriendRequest();

          /*console.log("etape 3");
          console.log(this.myFriendRequests);*/

          var path = 'https://localhost:5001/api/friend/search?friendUsername=' + localStorage.getItem("ClientUsernameForAdding");

          this.$http.get(path, {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {
           // alert(response.data.ClientId);
            this.Client = response.data;
            console.log(response.data)


            var path = 'https://localhost:5001/api/friend/friendrequest';

            this.$http.get(path, {
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
              }
            ).then(response => {

              this.myFriendRequests = response.data;
              console.log("etape 2");
              console.log(this.myFriendRequests);
              if(this.isRequest())
              {
                this.$router.push('FriendRequests');
              }

            }, response => {
              // error callback
              console.log(response);
            });

          }, response => {
            // error callback
            console.log(response);
          });
        },

        sendFriendRequest(){
          var data = {
            "Username": localStorage.getItem("ClientUsernameForAdding")
          };

          this.$http.post('https://localhost:5001/api/friend/friendrequest', data , {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {
            //alert(response);
            localStorage.setItem("redirectPage", 'Client')
            this.$router.push('Temp');
          }, response => {
            // error callback
            console.log(response);
          });

          document.getElementById(index).remove();
        },
      },
    beforeMount(){
      this.getClient();
    },
  }
</script>

<style scoped>
  #FriendRequests{
    width:800px;
    margin:auto;
    left:50%;
  }

  .friends{
    height: 150px;
    width: 800px;
    padding: 0px;
    margin-bottom: 20px;
    z-index: 0;
  }
  .profile-image{
    position:relative;
    left:65px;
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

  .friend-option{
    width:40%;
    position:relative;
    left:50%;
    height: 30px;
    bottom:20px;
  }

  .list-group-item:hover .friend-info{
    background-color: var(--secondary-color);
  }

  .list-group-item {
    border-style: solid;
    border-width: 2px;
    border-color: #a133f8;
  }

  .h1 {
    color: #495057;
    left:0;
  }

  .btn{
    width:150px;
    margin-bottom: 10px;
  }

  .client-row{
    height: 50px;
  }

</style>
