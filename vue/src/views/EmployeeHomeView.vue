<template>
  <div class="employee-home">
    <h1>Employee Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->
    <div>
      <button v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button>
      <button v-on:click="this.$router.push({name: 'searchPermit'})">Search Permit</button>
    </div>
    
  </div>
</template>

<script>
export default {
};
</script>
