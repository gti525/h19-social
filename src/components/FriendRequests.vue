<template>
  <div  id="FriendRequests">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">{{this.pageTitle}}</h1>
    <b-list-group class="justify-content-between align-items-center mt-4">
      <b-list-group-item class="friends" v-bind:id="index" button v-for="(friend,index) in friendRequests" v-b-modal.modallg>
        <div class="profile-image">
          <img v-bind:src="friend.ProfileImage" height="100%"></img>
        </div>
        <div class="friend-info">
          <div class="friend-name">
            {{ friend.FirstName + " " + friend.LastName }}
          </div>
          <div class="friend-option">
            <button type="button" class="btn btn-primary" variant="primary" v-on:click="acceptFriendRequest(friend.ClientId)">Accepter</button>
            <button type="button" class="btn btn-danger" variant="primary" v-on:click="denyFriendRequest(friend.ClientId)">Refuser</button>
          </div>
        </div>
      </b-list-group-item>
    </b-list-group>


  </div>
</template>

<script>
    export default {
        name: "FriendRequests",
      data() {
        return {
          friendRequests: [],
          pageTitle: 'Invitations'
        }
      },

      methods:
        {
          getFriendRequest ()
          {
            var path = 'https://localhost:5001/api/friend/friendrequest';

            this.$http.get(path, {
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
              }
            ).then(response => {

              this.friendRequests = response.data;

            }, response => {
              // error callback
              console.log(response);
            });
          },

          acceptFriendRequest(FriendId){
		  var path = 'https://localhost:5001/api/friend/accept?FriendId=' + FriendId;
            this.$http.get(path,{
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
              }
            ).then(response => {

              this.friendRequests = response.data;

            }, response => {
              // error callback
              console.log(response);
            });
            alert("demande accepté");
            document.getElementById(index).remove();
          },
          denyFriendRequest(FriendId){
		  var path = 'https://localhost:5001/api/friend/accept?FriendId=' + FriendId;
            this.$http.get(path,{
                headers: {
                  Authorization: "Bearer " + localStorage.getItem("token")
                }
              }
            ).then(response => {

              this.friendRequests = response.data;

            }, response => {
              // error callback
              console.log(response);
            });

            alert("demande refusé");
            document.getElementById(index).remove();
          }
        },
      beforeMount(){
        this.getFriendRequest();
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
    left:60%;
  }

  .list-group-item:hover .friend-info{
    background-color: var(--secondary-color);
  }

  .list-group-item {
    border-style: solid;
    border-width: 2px;
    border-color:var(--primary-color);
  }

  .h1 {
    color: #495057;
    left:0;
  }

  .btn{
    width:150px;
    margin-bottom: 10px;
  }

</style>
