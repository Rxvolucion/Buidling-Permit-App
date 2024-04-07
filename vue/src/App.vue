<template>
  <div id="capstone-app">
    <div id="nav">
      <span><router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;</span>
      <span><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></span>
      <span v-if="$store.state.token != ''"> | Currently signed in as {{ this.$store.state.user.username }}</span>

    </div>
    <router-view />
  </div>
</template>
