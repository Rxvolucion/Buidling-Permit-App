html
<template>
  <div id="nav">
    <nav class="navbar navbar-expand-lg navbar-dark bg-secondary">
      <div class="container d-flex justify-content-between align-items-center">
        <a class="navbar-brand d-flex align-items-left" href="#">
          <span class="me-3">KPJ PERMIT MANAGER</span>
        </a>
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
              <router-link v-if="this.$store.state.user.role = 'admin'" to="/employee" class="nav-link">Employee Dashboard</router-link>
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
  </div>
</template>

<script>
export default {
  computed: {
    loginOrLogoutText() {
      return this.$store.state.token == '' ? 'Login' : 'Logout';
    }
  }
};
</script>

<style scoped>
.navbar-brand {
  display: flex;
  align-items: center;
}

.navbar-brand span {
  margin-right: 0.5rem;
}
</style>