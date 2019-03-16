<template>
  <div id="Home">


    <img src="../images/logo-primary.svg" class=" " alt="" width="455" height="210" id="logo">
    <nav class="navbar navbar-light justify-content-between">
      <div class="logo-section " v-on:click="Reload()">
        <a class="navbar-brand">
          <router-link to="/tickets">
            <img src="" height="50" class=" " alt="" id="logo">
          </router-link>
        </a>
      </div>

      <div class="col-12 col-md-12">
        <div>
          <b-dropdown variant="link" right size="lg" no-caret>
            <template slot="button-content"><img width="75px" src="../images/defaultAvatar.svg"/> <span class="sr-only">Search</span></template>

            <b-dropdown-item v-on:click="Reload()"> <router-link to="/Login"> Login </router-link> </b-dropdown-item>
            <b-dropdown-item v-on:click="Deconnexion()"> <router-link to="/Register">Register </router-link></b-dropdown-item>
          </b-dropdown>

          <b-dropdown variant="link" right size="lg" no-caret>
            <template slot="button-content"><img width="75px" src="https://mdbootstrap.com/img/svg/hamburger3.svg?color=FFFFF"/> <span class="sr-only">Search</span></template>

            <b-dropdown-item v-on:click="Reload()"> <router-link to="/">Home</router-link></b-dropdown-item>
            <b-dropdown-item> <router-link to="/friendRequests">Invitations</router-link> </b-dropdown-item>
            <b-dropdown-item href="#">Paramètres</b-dropdown-item>
          </b-dropdown>
        </div>
      </div>

    </nav>


    <br>
    <br>
    <h1 class="h2 mb-2 font-weight: 1100">Bienvenue sur le site de Réseau Social de Spectacles  </h1>

    <img src="../images/14.jpg" class=" " alt="" width="455" height="210" id="logo">
    <p>Cette page  permet de donner des informations sur : «« Composant Réseau social de spectacles »»</p>

    <br>
    <br>

    <div class="pt-2">
      <h2 class="h2 mb-2 font-weight-normal">Description </h2>

      <p> Ce réseau social permet à un client de s’enregistrer et de voir ses billets
        achetés sur des sites de vente de billets de spectacles ainsi que ceux de ses
        amis.</p> </div>
    <img src="../images/4.jpg" class=" " alt="" width="600" height="300" id="logo">
    <br>
    <br>
    <h3 class="h2 mb-2 font-weight-normal">Fonctionnalités clé </h3>

    <ol>
      <li>S’enregistrer </li>
      <li>S’authentifier par fédération (oAuth)</li>
      <li> Afficher la liste des billets achetés</li>
      <li> Fournir la liste des billets achetés via un API REST</li>
      <li> Imprimer un billet</li>
    </ol>
    <img src="../images/2.jpg" class=" " alt="" width="455" height="210" id="logo">
    <br>
    <img src="../images/3.jpg" class=" " alt="" width="455" height="210" id="logo">

    <br>
    <br>
    <br>
    <br>
    <h4 class="h2 mb-2 font-weight-normal">Champ de compétence des membres de l’équipe </h4>
    <lo>
      <li>Analyse d’affaire et élaboration de produit</li>
      <li>Innovation</li>
      <li>Sécurité pour le Web</li>
      <li>Gestion de l’identité</li>

      <br>
    </lo>

    <h4 class="h2 mb-2 font-weight-normal">Équipe </h4>
    <img src="../images/5.jpg" class=" " alt="" width="455" height="210" id="logo">
    <lo>
      <li>Michaël Bélanger </li>
      <li>Jacob</li>
      <li>Raphael Doye </li>
      <li>Carole Fabeleu Kouemo</li>
      <li>Moussa Kone</li>
      <li>Youssef Hammami</li>

      <br>
    </lo>




    <br>
    <br>
    <!-- ***** Single Widget ***** -->
    <!-- ***** Single Widget ***** -->
    <div class="single-widget newsletter-widget mb-50">
      <!-- Section Heading -->
      <div class="col-12 col-sm-12">
        <div class="section-heading style-2 mb-3">
          <h4>Newsletter</h4>
          <div class="line"></div>
        </div>
        <p>Abonnez-vous à notre newsletter pour être averti des nouvelles mises à jour, des informations sur les spectacles, des réductions, etc..</p>
        <!-- Newsletter Form -->
        <div class="newsletter-form">
          <form action="#" method="post">
            <input type="email" name="nl-email" class="form-control mb-15" id="emailnl" placeholder="Enter your email">
            <button type="submit" class="btn social-btn w-100">Subscribe</button>
          </form>
        </div>
      </div>
    </div>

    <br>
    <br>


    <div class="col-12 col-sm-12">
      <p> Adresse
        1100 Rue Notre-Dame Ouest, Montréal,
        QC H3C 1K3
        Téléphone: 514 396-8800
        Télécopieur : 514 396-8950
        Email: Réseausocial@gmail.com</p>

    </div>


    <div class="col-6 col-sm-12">
      <p class="copywrite-text"><!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
        Copyright &copy; All rights reserved | Réseau social de spectacles </p>

    </div>




  </div>

</template>

<style>
  #Home {
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

