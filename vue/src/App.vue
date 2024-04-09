<template>
  <div id="capstone-app">
    <!-- <img> -->
    <PageNav />

    <!-- <div id="nav">
      <span><router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;</span>
      <span><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></span>
      <span v-if="$store.state.token != ''"> | Currently signed in as {{ this.$store.state.user.username }}</span>

    </div> -->
    <router-view />
  </div>
</template>

<script>
import PageNav from "../src/components/PageNav.vue"

export default{
  name: "app",

  components: {
    PageNav,
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

section.container {
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
  justify-content: center;
}

@media (max-width: 800px) {
  section.container {
    flex-direction: column;
  }
}


</style>