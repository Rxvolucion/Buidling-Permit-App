<template>
  <div id="capstone-app" class="d-flex flex-column min-vh-100">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container d-flex justify-content-between align-items-center">
        <a class="navbar-brand" href="#">KPJ PERMIT MANAGER</a>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav ms-auto d-flex align-items-center">
            <li class="nav-item">
              <router-link to="/" class="nav-link">Home</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{ name: $store.state.token == '' ? 'login' : 'logout' }" class="nav-link">{{ loginOrLogoutText }}</router-link>
            </li>
            <li class="nav-item" v-if="$store.state.token == ''">
              <router-link :to="{ name: 'register' }" class="nav-link">Register</router-link>
            </li>
            <li class="nav-item" v-if="$store.state.token != ''">
              <span class="nav-link">Currently signed in as {{ $store.state.user.username }}</span>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="content-wrapper flex-grow-1">
      <router-view />
    </div>

    <footer class="footer bg-dark text-white py-3 d-flex">
      <div class="container d-flex justify-content-between align-items-center">
        <div class="d-flex flex-column">
          <h5>Contact Us</h5>
          <p>
            Phone: (614) 456-7890<br>
            Email: info@kpjpermitmanager.com<br>
            Address: 49 N Merkle, Columbus OH 43205
          </p>
        </div>
        <p class="mb-0">&copy; 2023 KPJ Permit Manager. All rights reserved.</p>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: "app",
  computed: {
    loginOrLogoutText() {
      return this.$store.state.token == '' ? 'Login' : 'Logout';
    }
  }
};
</script>

<style>
#capstone-app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

.content-wrapper {
  padding: 2rem;
}

.footer {
  height: 135px;
}
</style>