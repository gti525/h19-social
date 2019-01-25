<template>
  <div id="login">
    <input type="text" v-model="input.username" placeholder="Nom d'utilisateur" />
    <input type="password" v-model="input.password" placeholder="Mot de passe" />
    <button type="button" v-on:click="login()">Se connecter</button>

    <h1>{{input.username}}</h1>
  </div>
</template>

<script>
  //import Login from '@/components/Login'

  export default {
    name: 'login',
    //components: { Login },
   // template: '<Login/>',
    data () {
      return {
        input: {
          username: "",
          password: ""
        }
      }
    },
    methods: {
      login () {
        //VERIFICATION DU USERNAME ET PASSWORD (HTTP GET)

        this.$http.get('https://localhost:44397/client/1', {
         /* params: {
            username: this.input.username,
            password: this.input.password
          }*/
        }).then(response => {

          //this.someData = response.body;
          alert(response.body);
          console.log(response);

        }, response => {
          // error callback
          alert('error');
          console.log(response);
        });

      /*  if (this.input.username == "username" && this.input.password == "password") {
            alert("Connection réussi");
        }*/
      }
    }
  }

</script>


<style>
  #Login {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
  h1 {
    color: red;
  }
</style>

