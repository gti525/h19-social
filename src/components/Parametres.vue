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
                    <input type="mot de passe" class="form-control" id="mot de passe" placeholder="entre le nouveau mot de passe" name="mot de passe">
                  </div>
                  <div class="form-group">
                    <input type="confirmer mot de passe" class="form-control" id="confirmer mot de passe" placeholder="entre encore le nouveau mot de passe" name="confirmer mot de passe">
                  </div>
                  <div class="form-group">
                    <input type="ancien mot de passe" class="form-control" id="ancien mot de passe" placeholder="entre votre ancien mot de passe" name="ancien mot de passe">
                  </div>
                  <button type="Modifier" class="btn btn-primary" variant="primary">Modifier</button>
                </div>
              </form>
              <!-- Fin modifier le mot de passe -->






            </div>

          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: "Parametres",
    data() {
      return {
        file: ''
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
            }).catch(response=> {
            console.log(response);
          });
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
</style>
