<template>
  <div id="capstone-app">
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