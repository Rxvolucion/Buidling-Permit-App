<template>
  <div class="employee-home">
    <h1>Employee Home</h1>
    <!-- <p>You must be authenticated to see this</p> -->

      <!-- <button type="button" class="btn btn-primary" v-on:click="this.$router.push({name: 'createPermit'})">Create Permit</button>
      <button type="button" class="btn btn-primary" v-on:click="this.$router.push({name: 'searchPermit'})"> Search Permit</button>
      <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'inspectionRequests' })"> View Inspection Requests</button> 
      <button v-on:click="this.$router.push({ name: 'reports' })"> View Permit and Inspection Statistics</button> -->
  </div>
  <div class="employee-options">
    <div class="row">
          <div class="col-sm-6">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title">Create Permit</h5>
                <p class="card-text">Go here to create a permit for a customer.</p>
                <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'createPermit' })">Create</button>
              </div>
            </div>
          </div>
          <div class="col-sm-6">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title">Search Permit</h5>
                <p class="card-text">Go here to search for created permits to review them, approve, reject, close or open them.</p>
                <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'searchPermit' })">Search</button>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
              <div class="card">
                <div class="card-body">
                  <h5 class="card-title">Inspection Requests</h5>
                  <p class="card-text">Go here to view inspection requests and result them.</p>
                  <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'inspectionRequests' })">View</button>
                </div>
              </div>
            </div>
            <div class="col-sm-6">
              <div class="card">
                <div class="card-body">
                  <h5 class="card-title">Permit and Inspection Statistics</h5>
                  <p class="card-text">Go here to view a variety of statistics on permits and inspections.</p>
                  <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'reports' })">View</button>
                </div>
              </div>
            </div>
        </div>
        <div class="row">
              <div class="col-sm-6">
                <div class="card">
                  <div class="card-body">
                    <h5 class="card-title">Permit and Inspection History</h5>
                    <p class="card-text">Go here to view the history of permits and inspections.</p>
                    <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'archive' })">View</button>
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
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
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
