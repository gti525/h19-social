<template>
    <div  id="tickets">
<!--
      <div id="overlay" v-on:click="CloseOverlay()">
        <div id="text">Overlay Text</div>
      </div>
-->

      <div class="container mb-4">
        <div class="row justify-content-center align-items-center" >
          <div class="col-10">


                <b-list-group class="row" button v-for="ticket in tickets">
                  <b-list-group-item class="col-2" >
                      <h4>Date</h4>

                  </b-list-group-item>

                  <b-list-group-item class="col">
                    {{ ticket.message }}
                  </b-list-group-item>
                </b-list-group>

          </div>
        </div>
      </div>

      <div class="container">
        <div class="list-group col-10"  button v-for="ticket in tickets">
          <button type="button" class="row list-group-item ">
            <div class="">Date</div>
            <div class="">{{ ticket.message }}</div>
          </button>
        </div>
      </div>

    </div>
</template>

<script>
    export default {
        name: "Tickets",

      data() {
          return {
            tickets: [
              {message: 'Céline Dion'},
              {message: 'Blue man group'},
              {message: 'Bones'}
            ]
          }
      },

      methods:
        {
          CloseOverlay()
          {
            document.getElementById("overlay").style.display = "none";
          },
          OpenOverlay()
          {
             document.getElementById("overlay").style.display = "block";
          }
        }
    }

</script>

<style scoped>

  #overlay {
    position: fixed; /* Sit on top of the page content */
    display: none; /* Hidden by default */
    width: 100%; /* Full width (cover the whole page) */
    height: 100%; /* Full height (cover the whole page) */
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0,0,0,0.5); /* Black background with opacity */
    z-index: 2; /* Specify a stack order in case you're using a different order for other elements */
    cursor: pointer; /* Add a pointer on hover */
  }

  #text {
    position: absolute;
    width: 50%;
    height: 100%;
    background-color: rgba(40,40,40,1);
    top: 50%;
    left: 50%;
    font-size: 50px;
    color: white;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
  }

  #tickets {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }

  #ticketsList{
    position: absolute;
    width: 50%;
    height: 10%;
    left: 50%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
  }

  ul {
list-style-position: inside;
    text-align: center;
  }

</style>
