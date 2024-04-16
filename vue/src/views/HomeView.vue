<!-- html -->
<template>
  <section class="home-wrapper">
    <div class="home-container d-flex align-items-start justify-content-center">

      <div class="home-content card mb-4 w-100 max-w-900">
        <div class="card-body">

          <div class="welcome-content">
            <h1 class="text-center mb-4 home-title">Welcome to KPJ Permit Manager</h1>
            <!-- <div class="home-description">
            <h2 class="card-title">KPJ Permit Manager is here to simplify the permit process for all our users, from the weekend DIY enthusiast, to the professional contractor and commercial developer.</h2>
            <h4 class="card-title">
              We understand the frustrations and complexities that come with navigating the permit system, which is why we have created a modern, user-friendly solution that streamlines the entire process. Our platform establishes a direct, efficient connection between the user and the inspector, eliminating the headaches and delays often associated with obtaining permits.
            </h4>
            <h4 class="card-text">
              Our mission is to empower our customers, whether they are tackling a small home renovation or large-scale commercial project, by providing them with the tools and support they need to get the job done right, on time, and with minimal hassle.
            </h4>
          </div> -->
              <div class="home-description">
                  <p class="card-title">KPJ Permit Manager is here to simplify the permit process for all our users, from the weekend DIY enthusiast, to the professional contractor and commercial developer.</p>
                  <p class="card-title">
                    We understand the frustrations and complexities that come with navigating the permit system, which is why we have created a modern, user-friendly solution that streamlines the entire process. Our platform establishes a direct, efficient connection between the user and the inspector, eliminating the headaches and delays often associated with obtaining permits.
                  </p>
                  <p class="card-text">
                    Our mission is to empower our customers, whether they are tackling a small home renovation or large-scale commercial project, by providing them with the tools and support they need to get the job done right, on time, and with minimal hassle.
                  </p>
              </div>
          </div>

          <div class="resources">
            
            <div class="row">
              <div class="col-sm-6">
                <div class="card">
                  <div class="card-body">
                    <h5 class="card-title">Building Codes</h5>
                    <p class="card-text">Library of building codes available in each state through MuniCode:</p>
                    <a href="https://library.municode.com/"><button type="button" class="btn btn-primary btn-block">View</button></a>
                    <p class="card-text">City of Columbus Building and Zoning codes:</p>
                    <a href="https://www.columbus.gov/Templates/Detail.aspx?id=28467"><button type="button" class="btn btn-primary">View</button></a>
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

        </div>
      </div>
          

            

    
    </div>
    

    <div class="d-flex justify-content-center mt-4">
      
    </div>

  </section>
  
</template>

<style scoped>
/* .home-description {
  align-content: center;
} */

.home-wrapper {
  background-image: url('../img/Crane_home.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.home-container {
  
  min-height: 100vh;
  /* padding: 3rem; */
}

.home-content {
  /* background-color: rgba(255, 255, 255, 0.278); */
  background-color: rgba(255, 255, 255, 0.795);
  /* align-items: center; */
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin-left: 3rem;
  margin-top: 3rem;
}

.home-title {
  font-family: 'Poppins', sans-serif;
  font-weight: 700;
  color: #333;
}

.home-description {
  font-family: 'Roboto', sans-serif;
  color: #666;
  /* color: white; */

}

.resources {
  margin-top: 2rem;
}

.card {
  margin: 0.5rem;
  /* height: 10rem; */
  background-color: rgba(255, 255, 255, 0.815);
}


button {
    /* margin-top: 0rem;
    margin-bottom: 1rem;
    justify-content: center; 
    align-items: center;   */
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

.max-w-800 {
  max-width: 800px;
}

.max-w-900 {
  max-width: 900px;
}
</style>