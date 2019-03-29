<template>
  <div id="Parametres">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">Paramètres</h1>

    <div class="container">
      <div class="row justify-content-center align-items-center" >
        <div class="col-8">
          <div class="card">
            <div class="card-body">

              <!-- Modifier la photo de profile-->
              <form class="row justify-content-center" action="" v-on:submit.prevent="Parametres" >
                <div class="col-6">
                  <label for="image">Choisissez une nouvelle photo de profile:</label>

                  <div class="form-group">
                    <input id="image" type="file" name="profile_photo" placeholder="Photo" @change="imgSelected">
                  </div>
                  <button type="Modifier" class="btn btn-primary" variant="primary" @click="uploadImg">Modifier</button>
                </div>
              </form>
              <!-- Fin modifier la photo de profile -->


              <!-- Modifier le compte email ->
              <form class="row justify-content-center" action="" v-on:submit.prevent="Parametres" >

               <div class="col-6">
                 <label for="email">Modifier le compte email:</label>

                 <div class="form-group">
                  <input class="form-control"  type="text"  id="email"  placeholder="Entre la nouvelle adresse email " >
                 </div>

                 <div class="form-group">
                   <input class="form-control"  type="text"  id="email" placeholder="Entre à nouveau la nouvelle adresse email " >
                 </div>

                 <button type="Modifier" class="btn btn-primary" variant="primary">Modifier</button>
                 <button type="Annuler" class="btn btn-primary" variant="primary">Annuler</button>

               </div>

              </form>
              <!-- Fin Modifier le compte email -->


              <!-- Modifier le mot de passe -->
              <form class="row justify-content-center" action="" v-on:submit.prevent="Parametres">
                <div class="col-6">
                  <label for="mot de passe">Modifier le mot de passe:</label>
                  <div class="form-group">
				    <input type="password" class="form-control" id="old mot de passe" v-model="input.oldPassword" placeholder="entrez votre ancien mot de passe" name="old mot de passe">
					<input type="password" class="form-control" id="mot de passe" v-model="input.password" placeholder="entrez le nouveau mot de passe" name="mot de passe">
                    <input type="password" class="form-control" id="mot de passe confirme" v-model="input.passwordConfirmed" placeholder="confirmez le nouveau mot de passe" name="mot de passe confirme">
                  </div>
                  <button type="Modifier" class="btn btn-primary" variant="primary" @click="changePassword">Modifier</button>
                </div>
              </form>
              <!-- Fin modifier le mot de passe -->
            </div>
           
          </div>
          
        </div>
          

      </div>
         <div class="publicity-content">
          <div id="horizontal-analytic-banner"></div>
        </div>

    </div>
  </div>
</template>


<script> 
   document.addEventListener("DOMContentLoaded",function()
     {const e="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTYzLCJpYXQiOjE1NTMxOTkzMDh9.avoFcsrtg5txsb4ZSQtDZnny-AajlA5RJfjCzsbRpRA";const t=function(){if("undefined"!=typeof Storage&&localStorage.getItem("gti525analytic")){const e=JSON.parse(localStorage.getItem("gti525analytic"));if(new Date(e.expiration).getTime()>(new Date).getTime())return e.clientId}return}();t?function(t){let n=new XMLHttpRequest;n.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/banners/code",!0),n.onload=function(o){4===n.readyState&&200===n.status&&Function(`return (${n.responseText})`)()(t,e)},n.setRequestHeader("x-access-token",e),n.send()}(t):function(){let t=new XMLHttpRequest;t.open("GET","https://gti525-analitycs.herokuapp.com/api/v1/analytics/code",!0),t.onload=function(n){4===t.readyState&&200===t.status&&Function(`return (${t.responseText})`)()(e)},t.setRequestHeader("x-access-token",e),t.send()}()},!1);
  export default {
    name: "Parametres",
    data() {
      return {
        file: '',
		input: {
		oldPassword: "",
		password: "",
		passwordConfirmed: ""
        }
      }
    },
    methods:
      {
        uploadImg: function() {
          let formData = new FormData();
          formData.append('file', this.file);

          this.$http.post('https://localhost:5001/api/Client/uploadImage',
            formData,
            {
              headers: {
                'Content-Type': 'multipart/form',
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            })
            .then(response=> {
              alert("Enregistrement rĂ©ussi! \n " + this.file.name);
              localStorage.setItem("profileImage", response.data);
              location.reload();
            }).catch(response=> {
            console.log(response);
          });
        },
		changePassword: function() {
		if (this.input.password == this.input.passwordConfirmed){
			var data = {
				"OldPassword" : this.input.oldPassword,
				"Password": this.input.passwordConfirmed
			  };
			
			  this.$http.patch('https://localhost:5001/api/Client/resetpassword',
				data,
				{
				  headers: {
					Authorization: "Bearer " + localStorage.getItem("token")
				  }
				})
				.then(response=> {
				  alert("Mot de pass réinitialisé! \n ");
				}).catch(response=> {
				alert("Ancien mot de passe invalide !\n ");
				console.log(response);
			  });
			}	
			else {
				alert("Les nouveaux mots de passe ne sont pas identiques !\n ");
			}
        },
        imgSelected: function($event) {
          this.file = $event.target.files[0];
        }
      }
  }
</script>


<style scoped>
  .Parametres{
    background-color:#3db7cc;
    width: 800px;
    margin: auto;
    left: 50%;
  }
  form{
    padding-top: 20px;
  }

  .publicity-content{
    position:center;
    margin-block-start: 50px;
  }

</style>
