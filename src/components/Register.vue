<template>
  <div id="register">
    <input type="text" v-model="input.username" placeholder="Nom d'utilisateur"/>
    <br/>
    <input type="password" v-model="input.password" placeholder="Mot de passe"/>
    <br/>
    <input type="text" v-model="input.firsname" placeholder="Prénom"/>
    <br/>
    <input type="text" v-model="input.lastname" placeholder="Nom de Famille"/>
    <br/>
    <input type="date" v-model="input.birth"/>
    <br/>
    <input type="text" v-model="input.number" placeholder="Numéro de Porte"/>
    <br/>
    <input type="text" v-model="input.street" placeholder="Rue"/>
    <br/>
    <input type="text" v-model="input.city" placeholder="Ville"/>
    <br/>
    <input type="text" v-model="input.postal" placeholder="Code Postal"/>
    <br/>
    <input type="text" v-model="input.state" placeholder="État/Province"/>
    <br/>
    <input type="text" v-model="input.country" placeholder="Pays"/>
    <br/>

    <button type="button" v-on:click="register()">S'enregistrer</button>

    <h1>{{input.username}}</h1>
  </div>
</template>

<script>

  export default {
    name: 'register',

    data () {
      return {
        input: {
          username: "",
          password: "",
          firsname: "",
          lastname: "",
          birth: "",
          number: "",
          street: "",
          city: "",
          postal: "",
          state: "",
          country: "",
        }
      }
    },

    methods: {
      register () {
        //AJOUT DE L'USAGER (HTTP POST)
           // alert("Enregistrement réussi");


        const formData = {
          client_id: 1,
          email
            :
          this.input.username,
          password
            :
          this.input.password,
          first_name
            :
          this.input.firsname,
          last_name
            :
          this.input.lastname,
          birth_date
            :
          this.input.birth,
          address
            :
            this.input.number + ' ' + this.input.street,
          city
            :
          this.input.city,
          postal_code
            :
          this.input.postal,
          province
            :
          this.input.state,
          country
            :
          this.input.country
        };

        var data = {
         /* client: {*/
            //"client_id": 1,
            "client": "bobby",
            /*"password": this.input.password,
            "first_name": this.input.firsname,
            "last_name": this.input.lastname,
            "birth_date": this.input.birth,
            "address": this.input.number + ' ' + this.input.street,
            "city": this.input.city,
            "postal_code": this.input.postal,
            "province": this.input.state,
            "country": this.input.country*/
        //  }
      };

        this.$http.post('https://localhost:44397/client',"bob" /*, {emulateJSON: true}, {headers: {
          'Content-Type': 'application/json'}}*/
        ).then(response => {

          //this.someData = response.body;
          alert("Enregistrement réussi! \n Bienvenue " + this.input.username);

        }, response => {
          // error callback
          alert("Erreur d'enregistrement");
        });
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

