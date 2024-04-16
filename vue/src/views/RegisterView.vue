<!-- <template>
  <div id="register" class="text-center">
    <form v-on:submit.prevent="register">
      <h1>Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="user.username" required autofocus />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input type="password" id="confirmPassword" v-model="user.confirmPassword" required />
      </div>
      <div class="form-input-group">
        <label for="email">Email</label>
        <input type="text" id="email" v-model="user.email" required autofocus />
      </div>

      <div class="form-input-group">
        <label for="address">Address</label>
        <input type="text" id="address" v-model="customerDTO.address" required autofocus />
      </div>
      <div class="form-input-group">
        <label for="contractor">Contractor</label>
        <select v-model="customerDTO.contractor" id="contractor" name="contractor">
          <option value="true">Yes</option>
          <option value="false">No</option>
        </select>
      </div>

      <button type="submit">Create Account</button>
      <p><router-link v-bind:to="{ name: 'login' }">Already have an account? Log in.</router-link></p>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        email : '',
        isEmployee : false,
        role: 'user',
      },
      customerDTO: {
        address: '',
        contractor: false
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    createCustomer() {
      authService.createCustomer(this.customerDTO)
              .then((response) => {
                if (response.status == 201) {

                this.$router.push({
                path: '/login',
                query: { registration: 'success' },
                })};
    },
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
                this.createCustomer();
                }
              })
            
          }}
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
        
    
    clearErrors() {
      console.log('reached clearErrors')
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>
.form-input-group {
  margin-bottom: 1rem;
}
label {
  margin-right: 0.5rem;
}
</style> -->

<template>
  <div id="register" class="d-flex justify-content-center align-items-center min-vh-100 bg-image">
    <form v-on:submit.prevent="register" class="card p-5 shadow col-md-6 col-lg-4">
      <h1 class="mb-4">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="user.username" required autofocus class="form-control" />
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required class="form-control" />
      </div>
      <div class="form-group">
        <label for="confirmPassword">Confirm Password</label>
        <input type="password" id="confirmPassword" v-model="user.confirmPassword" required class="form-control" />
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <input type="text" id="email" v-model="user.email" required autofocus class="form-control" />
      </div>
      <div class="form-group">
        <label for="address">Address</label>
        <input type="text" id="address" v-model="customerDTO.address" required autofocus class="form-control" />
      </div>
      <div class="form-group">
        <label for="contractor">Contractor</label>
        <select v-model="customerDTO.contractor" id="contractor" name="contractor" class="form-control">
          <option value="true">Yes</option>
          <option value="false">No</option>
        </select>
      </div>
      <button type="submit" class="btn btn-primary">Create Account</button>
      <p class="mt-3">
        <router-link :to="{ name: 'login' }" class="text-muted">Already have an account? Log in.</router-link>
      </p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService.js";

export default {
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        email: "",
        isEmployee: false,
        role: "user"
      },
      customerDTO: {
        userId: 0,
        address: "",
        contractor: false
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user."
    };
  },
  methods: {
    createCustomer() {
      authService
        .createCustomer(this.customerDTO)
        .then(response => {
          this.$router.push({
            path: "/login",
            query: { registration: "success" }
          });
        })
        .catch(error => {
          // Handle error
        });
    },
    register() {
      if (this.user.password !== this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then(response => {
            this.customerDTO.userId = response.data.userId;
            this.createCustomer();
          })
          .catch(error => {
            // Handle error
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    }
  }
};
</script>

<style scoped>
.form-group {
  margin-bottom: 1rem;
}

.bg-image {
  background-image: url('../img/Blueprint_B.jpg');
  background-size: cover;
  background-position: center;
}

button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}
</style>
