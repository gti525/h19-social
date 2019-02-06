<template>
  <div id="register">

    <h1 class="h3 mb-3 font-weight-normal">Enregistrez-Vous</h1>

    <div class="container">
      <div class="row justify-content-center align-items-center" >
        <div class="col-8">
          <div class="card">
            <div class="card-body">
              <form class="row justify-content-center" action="" @submit="onSubmit" >

                <div class="col-6">
                  <div class="form-group">
                    <input class="form-control" name="email" type="text" v-model="input.email" placeholder="Adresse Courriel">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="password" type="password" v-model="input.password" placeholder="Mot de passe">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="name" type="text" v-model="input.firsname" placeholder="Prénom">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="lastName" type="text" v-model="input.lastname" placeholder="Nom de Famille">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="birth" type="date" v-model="input.birth">
                  </div>
                </div>
                <div class="col-6">
                  <div class="form-group">
                    <input class="form-control" name="address"  type="text" v-model="input.address" placeholder="Adresse">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="city" type="text" v-model="input.city" placeholder="Ville">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="postalCode" type="text" v-model="input.postal" placeholder="Code Postal">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="province"type="text" v-model="input.state" placeholder="État/Province">
                  </div>

                  <div class="form-group">
                    <input class="form-control" name="country" type="text" v-model="input.country" placeholder="Pays">
                  </div>
                </div>


                  <button type="submit" class="btn btn-primary" variant="primary" v-on:click="register()">S'enregistrer</button>


              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="pt-3 mb-4">
      Vous avez déjà un compte?
      <router-link to="/">
        <a>Connectez-vous</a>
      </router-link>
    </div>

  </div>
</template>

<script>

  export default {
    name: 'register',

    data () {
      return {
        input: {
          email: "",
          password: "",
          firsname: "",
          lastname: "",
          birth: "",
          address: "",
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

        var data = {
          //"client_id": 1,
          "email": this.input.email,
          "password": this.input.password,
           "first_name": this.input.firsname,
           "last_name": this.input.lastname,
           //"birth_date": this.input.birth,
           "address": this.input.address,
           "city": this.input.city,
           "postal_code": this.input.postal,
           "province": this.input.state,
           "country": this.input.country
      };

        this.$http.post('https://localhost:5001/api/client', data , {headers: {
          'Content-Type': 'application/json'}}
        ).then(response => {

          alert("Enregistrement réussi! \n Bienvenue " + this.input.email);
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

