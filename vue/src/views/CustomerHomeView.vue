<template>
  <div class="customer-home">
    <h1>Customer Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->
    <div>
      <button v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button>
      <button v-on:click="this.$router.push({ name: 'customerPermits', params: {userId: this.$store.state.user.userId} })">View My Permits</button>
    </div>
    
  </div>
</template>

<script>
export default {
};
</script>
