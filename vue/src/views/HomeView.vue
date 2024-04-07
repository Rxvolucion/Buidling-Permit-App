<template>
  <div class="home">
    <h1>Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->
    <div>
      <button v-on:click="this.$router.push({name: 'permit'})">Create Permit</button>
    </div>
    
  </div>
</template>

<script>
export default {
};
</script>
