<template>
    <div class="permit-create d-flex flex-column align-items-center justify-content-center min-vh-100">
      <div class="card p-5 shadow col-md-6 col-lg-4">
        <h1 class="mb-4">Input Permit Information</h1>
        <form @submit.prevent="createPermit" class="form">
          <div class="form-group">
            <label for="permit-type-select">Permit Type</label>
            <select name="permit-type-select" id="permit-type-select" v-model="newPermit.permitType" class="form-control" required>
              <option value="">Please select a permit type</option>
              <option value="New Home">New Home</option>
              <option value="New Garage">New Garage</option>
              <option value="Building Addition">Building Addition</option>
              <option value="Electrical Work">Electrical Work</option>
              <option value="HVAC Work">HVAC Work</option>
              <option value="Interior Alterations">Interior Alterations</option>
            </select>
          </div>
          <div class="form-group">
            <label for="permit-address">Permit Address</label>
            <input id="permit-address" name="permit-address" type="text" v-model="newPermit.permitAddress" class="form-control" required />
          </div>
          <div class="form-group">
            <label for="is-commercial">Is it commercial?</label>
            <select v-model="newPermit.Commercial" id="is-commercial" name="is-commercial" class="form-control">
              <option :value=true>Yes</option>
              <option :value=false>No</option>
            </select>
          </div>
  
          <div class="form-group" v-if="userRole === 'user' ? false : true">
            <label for="customer-id-select">Customer ID:</label>
            <select name="customer-ids" id="customer-id-select" v-model="newPermit.customerId" class="form-control" required>
              <option value="">Please select a customer ID</option>
              <option v-for="customerId in customerIds" :value="customerId" :key="customerId">{{ customerId }}</option>
            </select>
          </div>
          <div class="form-group" v-if="userRole === 'user' ? true : false">
          <label for="permit-customer-details">Additional Details</label>
          <textarea id="permit-customer-details" name="permit-customer-details" v-model="newPermit.customerDetails" class="form-control" rows="5" required></textarea>
        </div>
        <div class="d-flex justify-content-center mt-4">
          <button type="submit" class="btn btn-primary w-75">Submit</button>
        </div>
        </form>
      </div>
    </div>
  </template>

<script>
import PermitService from "../services/PermitService.js";
import AuthService from "../services/AuthService.js";

export default {
    components: {},
    name: "CreatePermit",
    data() {
        return {
            // userRole2: "",
            // showCustomerId: false,
            permitTypes: [],
            newPermit: {
                customerId: "",
                permitType: "",
                permitAddress: "",
                Commercial: false,
                isActive: true,
                permitStatus: "Pending",
                customerDetails: "",
            },
            customerIds: [

            ],
            userToken: this.$store.state.token,
            userRole: this.$store.state.user.role,            
        }
    },
    computed: {
        // currentUserRole() {
        //     console.log("Reached current user role computed")
        //     let userRole = this.getCurrentUserRole();
        //     console.log(userRole)
        //     return userRole;
        // },
        // currentUserRole: {
        //     return this.getCurrentUserRole()
        // }
        // userRole() {
        //     //console.log(this.currentUserRole)
        //     this.currentUserRole = this.getCurrentUserRole;
        //     return this.currentUserRole;

        // }
        // shortText() {
        //     let testUserRole = this.getCurrentUserRole;

        //     return testUserRole;
        // }


    },
    methods: {
        createPermit() {
            console.log("Reached create permit method.");
            PermitService.createPermit(this.newPermit)
                .then(response => {
                    if(this.$store.state.user.role == 'user'){
                        this.$router.push({ name: 'customer' });
                    }
                    else{
                        this.$router.push({ name: 'employee' });
                    }
                    
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error adding owner: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log(
                            "Error adding owner: unable to communicate to server"
                        );
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error adding owner: make request");
                    }
                });
        },
        // getCurrentUserRole() {
        //     console.log("Reached get current user role method.")
        //     AuthService.getRole()
        //         // console.log("reached method")
        //         .then((response) => {
        //             let tempUserRole = response.data
        //             console.log(response.data)
        //             console.log(tempUserRole)
        //             return tempUserRole;
        //         })
        //         .catch((error) => {
        //             if (error.response) {
        //                 // error.response exists
        //                 // Request was made, but response has error status (4xx or 5xx)
        //                 console.log("Error adding owner: ", error.response.status);
        //             } else if (error.request) {
        //                 // There is no error.response, but error.request exists
        //                 // Request was made, but no response was received
        //                 console.log(
        //                     "Error adding owner: unable to communicate to server"
        //                 );
        //             } else {
        //                 // Neither error.response and error.request exist
        //                 // Request was *not* made
        //                 console.log("Error adding owner: make request");
        //             }
        //         });
        // },
    },

    created() {
        //service call to get customerId by username (set customerId in data)
        console.log("Reached created.")
        AuthService
            .getCustomerByUserId(this.$store.state.user.userId)
            .then((response) => {
                console.log("Success on getting customer by username.");
                // if new customer ID is empty, means it hasn't been set by the employee creating it
                if (this.newPermit.customerId === "") {
                    this.newPermit.customerId = response.data.customerId;
                }
                
            })
            .catch((error) => {
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting customer: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting customer: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting customer: error making request");
                }
            });
        AuthService
            .getCustomerIds()
            .then((response => {
                console.log("Reached get customer ids.");
                this.customerIds = response.data;
            }))
            .catch((error) => {
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting customer ids: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting customer ids: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting customer ids: error making request");
                }
            });
        // PermitService
        //     .getPermitTypes()
        //     .then((response => {

        //     }))
            


        // this.newPermit.userId = this.$store.state.user.userId;
        // console.log("Reached created")
        // this.userRole = this.getCurrentUserRole();
        // console.log(this.userRole)
        // AuthService.getRole()
        //     .then(response => {
        //         this.userRole2 = response.data;
        //     })
        //     .catch(error => {
        //         console.error("Failed to fetch user role: ", error);
        //     });
    }
}
</script>
<style scoped>
.permit-create {
  background-image: url('../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  min-height: 100vh;
  padding: 3rem;
}

.form { 
    width: 100%;
    max-width: 800px;
}

h1 {
    padding: 0rem;
}

button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

</style>