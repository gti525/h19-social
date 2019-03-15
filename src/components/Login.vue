<template>
  <div id="login">

    <h1 class="h2 mb-2 font-weight-normal">Connectez-Vous</h1>

    <div class="container">
      <div class="row justify-content-center align-items-center" >
        <div class="col-4">
          <div class="card">
            <div class="card-body">
              <form action="" v-on:submit.prevent="login" >
                <div class="form-group">
                  <input class="form-control" name="email" type="email" v-model="input.email" required autofocus placeholder="Adresse Courriel">
                </div>
                <div class="form-group">
                  <input class="form-control" name="password" type="password" v-model="input.password" required placeholder="Mot de passe">
                </div>
                <button type="submit" class="btn btn-primary" variant="primary">Se Connecter</button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div>
      <b-alert variant="warning" :show="validAuthentification" class="mt-2">
        Votre adresse courriel et/ou votre mot de passe est invalide
      </b-alert>
    </div>

    <div class="pt-2">
      Pas de compte?
      <router-link to="/register">
        <a>Enregistrez-vous</a>
      </router-link>
    </div>

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
          email: "",
          password: ""
        },
        validAuthentification: false
      }
    },
    methods: {
      login () {
        //VERIFICATION DU USERNAME ET PASSWORD (HTTP GET)

		var data = {
		"email": this.input.email,
        "password": this.input.password
      };
		
        this.$http.post('https://localhost:5001/api/client/login', data, {headers: {
          'Content-Type': 'application/json'}}
        ).then(response => {

          alert("Bienvenue " + this.input.email);
		  localStorage.setItem("token", response.data.Token);

        }, response => {
          // error callback
          this.validAuthentification = true;
          console.log(response);
        });
      }
    }
  }

</script>


<style>
  #login {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 55px;
  }
  
  .btn-primary {
	 background-color: #a133f8;	
	 color: white;	
  }
  
  .btn-primary:hover {
	 background-color: white;;	
	 color: #a133f8;	
  }
  
  .h2 {
	color: #a133f8;
  }
  
  a {
	color: #007bff;
  }
</style>

