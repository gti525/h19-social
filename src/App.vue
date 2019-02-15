<template>
  <div id="app">
    <component :is="layout">
      <router-view/>
    </component>
  </div>
</template>

<script>
  const default_layout = "default";

export default {
  name: 'App',
  computed:{
    layout(){
      return (this.$route.meta.layout || default_layout) + '-layout';
    }
  }
}
</script>

<style>

  html{
    height: 100%;
  }

  body, #app{
    height: 100%;
    display: flex;
    flex-direction: column;
  }

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

</style>
