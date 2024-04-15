html
<template>
  <div class="home-container d-flex align-items-start justify-content-center">
    <div class="home-content card mb-4 w-100 max-w-800">
      <div class="card-body">
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
    </div>
  </div>
  <div class="d-flex justify-content-center mt-4">
    
  </div>
</template>

<style scoped>
/* .home-description {
  align-content: center;
} */
.home-container {
  background-image: url('../img/Crane_home.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  min-height: 100vh;
  padding: 3rem;
}

.home-content {
  /* background-color: rgba(255, 255, 255, 0.278); */
  background-color: rgba(255, 255, 255, 0.795);
  /* align-items: center; */
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin-left: 3rem;
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

.max-w-800 {
  max-width: 800px;
}
</style>