<template>
  <div  id="Client">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">{{this.pageTitle}}</h1>
    <b-list-group class="justify-content-between align-items-center mt-4">
        <div class="profile-image">
          <img v-bind:src="Client.ProfileImage" height="100%"></img>
        </div>
        <div class="friend-info">
          <div class="friend-name">
            {{ Client.FirstName + " " + Client.LastName }}
          </div>
          <div class="friend-option">
            <button type="button" class="btn btn-primary" variant="primary" v-on:click="sendFriendRequest(Client.ClientId)">Ajouter</button>
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
        Client: [
          {
            FirstName:"michaël",
            LastName: 'bélanger',
            ProfileImage: 'https://images.lpcdn.ca/924x615/201305/23/693504-michael-belanger-62-ans-accuse.jpg',
            ClientId: 1
          }
        ],
        pageTitle: 'Invitations'
      }
    },

    methods:
      {
        getClient ()
        {


          var path = 'https://localhost:5001/api/friend/search?friendUsername=' + localStorage.getItem("ClientUsernameForAdding");

          this.$http.get(path, {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {
            alert(response.data.ClientId);
            this.Client = response.data;

          }, response => {
            // error callback
            console.log(response);
          });
        },

        sendFriendRequest(){
          var data = {
            "Username": localStorage.getItem("ClientUsernameForAdding")
          };

          this.$http.post('https://localhost:5001/api/friend/friendrequest?friendUsername=', data , {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {

            alert(response);

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

</style>
