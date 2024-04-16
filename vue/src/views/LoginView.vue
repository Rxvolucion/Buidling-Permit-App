<template>
  <div id="login" class="d-flex justify-content-center align-items-center min-vh-100 bg-image">
    <form v-on:submit.prevent="login" class="card p-5 shadow col-md-6 col-lg-4">
      <h1 class="mb-4">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div class="form-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="user.username" required autofocus class="form-control" />
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required class="form-control" />
      </div>
      <button type="submit" class="btn btn-primary">Sign in</button>
      <p class="mt-3">
        <router-link :to="{ name: 'register' }" class="text-muted">Need an account? Sign up.</router-link>
      </p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            if (this.$store.state.user.role == "admin") {
              this.$router.push({ name: "employee" });
            } else {
              this.$router.push({ name: "customer" });
            }
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
.form-group {
  margin-bottom: 1rem;
}

button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

.bg-image {
  background-image: url('../img/Blueprint_B.jpg');
  background-size: cover;
  background-position: center;
}
</style>