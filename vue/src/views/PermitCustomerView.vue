<template>
    <div class="permit">
      <h1 class="mb-4">My Permits</h1>
      <div class="container">
        <div class="row">
          <div class="col-md-6 col-lg-4 mb-4" v-for="permit in permits" :key="permit.permitId">
            <div class="card">
              <div class="card-body">
                <Permit :item="permit" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>

<script>
import Permit from '../components/Permit.vue';
import PermitService from '../services/PermitService.js';
import AuthService from '../services/AuthService.js'

export default {
    name: "MyPermits",
    data() {
        return {
            userId: 0,
            permits: [],
            customerId: 0,
        }
    },
    computed: {

    },
    components: {
        Permit,
    },

    methods: {
        getMyPermits() {
            PermitService
                .listPermitsByCustomer(this.customerId)
                .then((response) => {
                    this.permits = response.data;
                    console.log(this.permits)
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
        }
    },
    created() {
        console.log("reached created")
        this.userId = this.$route.params.userId;
        console.log(this.userId)

        AuthService
            .getCustomerByUserId(this.userId)
            .then((response) => {
                this.customerId = response.data.customerId;
                console.log("Success getting customer by user id.")
                console.log(this.customerId);
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

        this.getMyPermits();


    }

}

</script>

<style scoped>
.permit {
  
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  padding: 2rem;
}

.card {
  background-color: #f5f5f5;
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}
</style>