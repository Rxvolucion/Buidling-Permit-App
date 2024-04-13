<template>
  <div class="customer-home">
    <h1>Customer Home</h1>

    <div>
      <!-- <button v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button> | 
      <button v-on:click="this.$router.push({ name: 'customerPermits', params: {userId: this.$store.state.user.userId} })">View My Permits</button> -->
    </div>

    <div class="customer-options">

      <div class="row">
        <div class="col-sm-6">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Create Permit</h5>
              <p class="card-text">Go here to apply for a permit.</p>
              <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'createPermit' })">Apply</button>
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">View My Permits</h5>
              <p class="card-text">Go here to view your permits.</p>
              <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'customerPermits', params: { userId: this.$store.state.user.userId } })">View</button>
            </div>
          </div>
        </div>
      </div>
        

    
    </div>
      
  </div>
    


    
</template>

<script>
export default {
};
</script>

<style scoped>
.customer-options {
  background-image: url('../../img/landscape-blueprint-paul-hanaoka-40JmKOnu6Cc-unsplash.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  min-height: 100vh;
  padding: 3rem;
}

.card {
  margin: 0.5rem;
  /* height: 10rem; */
  background-color: rgba(255, 255, 255, 0.815);
}

/* button {
  padding: 1rem;
  margin: 0.5rem;
} */

.image img {
  opacity: 75%;
}

/* .image {
  background-color: red;
  background-image: url('../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg');
} */


</style>
