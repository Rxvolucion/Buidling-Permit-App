
<template>
<div id="nav">
    <span><router-link v-bind:to="{ name: this.$store.state.user.role == 'user'? 'customer': 'employee' }">Home</router-link>&nbsp;|&nbsp;</span>
    <span><router-link v-bind:to="{ name: this.$store.state.token == '' ? 'login' : 'logout' }">{{ loginOrLogoutText }}</router-link>&nbsp;|&nbsp;</span>
    <!-- <span><router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">Login</router-link></span>

    <span><router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></span> -->
    <span v-if="$store.state.token != ''"> | Currently signed in as {{ this.$store.state.user.username }}</span> 
  </div>
</template>

<script>
export default {
  computed: {
    loginOrLogoutText() {
      return this.$store.state.token == '' ? 'Login' : 'Logout';
    }
  }
};
</script>