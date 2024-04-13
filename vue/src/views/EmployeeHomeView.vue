<template>
  <div class="employee-home">
    <h1>Employee Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->
    <div class="buttons">
      <!-- <button v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button>
      <button v-on:click="this.$router.push({name: 'searchPermit'})"> Search Permit</button>
      <button v-on:click="this.$router.push({ name: 'inspectionRequests' })"> View Inspection Requests</button>
      <button v-on:click="this.$router.push({ name: 'reports' })"> View Permit and Inspection Statistics</button> -->
 </div>
    <div class="employee-options">

      <!-- <button type="button" class="btn btn-primary" v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button>
      <button type="button" class="btn btn-primary" v-on:click="this.$router.push({name: 'searchPermit'})"> Search Permit</button>
      <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'inspectionRequests' })"> View Inspection Requests</button> -->

      <div class="row">
        <div class="col-sm-6">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Create Permit</h5>
              <p class="card-text">Go here to create a permit for a customer.</p>
              <a href="#" class="btn btn-primary">Create</a>
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Search Permit</h5>
              <p class="card-text">Go here to search for created permits to review them, approve, reject, close or open them.</p>
              <a href="#" class="btn btn-primary">Search</a>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
          <div class="col-sm-6">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title">View Inspection Requests</h5>
                <p class="card-text">Go here to view inspection requests and result them.</p>
                <a href="#" class="btn btn-primary">View</a>
              </div>
            </div>
          </div>
          <!-- <div class="col-sm-6">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title">Special title treatment</h5>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div>
          </div> -->
      </div>

    </div>

    <!-- <div class="image">
        <img src="../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg" alt="blueprint drawing" class="img-fluid">
    </div> -->
    
    
  </div>
</template>

<script>
export default {
};
</script>

<style scoped>
/* .buttons {
  display: flex;
  justify-content: center;
} */

.employee-options {
  background-image: url('../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg');
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

button {
  padding: 1rem;
  margin: 0.5rem;
}

.image img {
  opacity: 75%;
}

/* .image {
  background-color: red;
  background-image: url('../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg');
} */


</style>
