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
  <div id="register" class="text-center">
    <form v-on:submit.prevent="register">
      <h1>Create Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input
          type="password"
          id="confirmPassword"
          v-model="user.confirmPassword"
          required
        />
      </div>
      <div class="form-input-group">
        <label for="email">Email</label>
        <input type="text" id="email" v-model="user.email" required autofocus />
      </div>

      <div class="form-input-group">
        <label for="address">Address</label>
        <input
          type="text"
          id="address"
          v-model="customerDTO.address"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="contractor">Contractor</label>
        <select
          v-model="customerDTO.contractor"
          id="contractor"
          name="contractor"
        >
          <option value="true">Yes</option>
          <option value="false">No</option>
        </select>
      </div>

      <button type="submit">Create Account</button>
      <p>
        <router-link v-bind:to="{ name: 'login' }"
          >Already have an account? Log in.</router-link
        >
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
        role: "user",
      },
      customerDTO: {
        userId: 0,
        address: "",
        contractor: false,
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    createCustomer() {
      console.log("reached create customer method");
      authService.createCustomer(this.customerDTO)

        .then((response) => {
          console.log("reached success in create customer");

          this.$router.push({
            path: "/login",
            query: { registration: "success" },
          });
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error loading pets: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error loading pets: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error loading pets: error making request");
          }
        });
    },
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        console.log("reached auth service in  register");
        authService
          .register(this.user)
          .then((response) => {
            // console.log("reached success in auth service in register");
            this.customerDTO.userId = response.data.userId;
            console.log(response.data)
            console.log(response.data.userId)
            this.createCustomer();
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log("Error loading pets: ", error.response.status);
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error loading pets: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log("Error loading pets: error making request");
            }
          });
      }
    },
    clearErrors() {
      console.log("reached clearErrors");
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
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
</style>
