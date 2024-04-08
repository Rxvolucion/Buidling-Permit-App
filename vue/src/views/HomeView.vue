<template>
  <div class="home">
    <h1>Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->
    <div>
      <button v-if="this.$store.state.token == ''" v-on:click="this.$router.push({name: 'login'})">Login</button>
    </div>
    
  </div>
</template>

<script>
export default {
};
</script>
