<template>
    <div class="permit-create d-flex flex-column align-items-center justify-content-center min-vh-100">
      <div class="card p-5 shadow col-md-6 col-lg-4">
<<<<<<< HEAD
        <h1 class="mb-4">Request Inspection</h1>
        <form @submit.prevent="createInspection" class="form">
=======
        <h1 class="mb-4">Request an Inspection</h1>
        <form @submit.prevent="createInspection()" class="form">
>>>>>>> 4b2c08c25f661445d60310fc82548d2e584221e7
        <div class="form-group">
          <label for="inspection-date">Inspection Request Date</label>
          <input id="inspection-date" name="inspection-date" type="datetime-local" v-model="newInspection.DateVariable" class="form-control" />
        </div>
        <div class="form-group">
          <label for="inspection-type-select">Inspection Type</label>
          <select name="inspection-type-select" id="inspection-type-select" v-model="newInspection.InspectionType" class="form-control" required>
            <option value="">Please select an inspection type</option>
            <option v-for="inspectionType in inspectionTypes" :value="inspectionType" :key="inspectionType">{{ inspectionType }}</option>
          </select>
        </div>
        <div class="d-flex justify-content-end mt-4">
          <button type="submit" class="btn btn-primary">Submit</button>
        </div>
      </form>
    </div>
    </div>
  </template>

<script>

import InspectionService from "../services/InspectionService.js";
import PermitService from "../services/PermitService.js";

export default {
    components: {},
    name: "CreateInspection",
    data() {
        return {
            // userRole2: "",
            // showCustomerId: false,
            // inspections: [],
            inspectionTypes: [],
            newInspection: {
                permitId: parseInt(this.$route.params.permitId),
                // status: "Pending",
                DateVariable: "",
                InspectionType: "",
            },
            
        }
    },
    computed: {
        // getInspectionTypes() {
        //     return this.inspections.map(() => {
        //         this.inspections.type;
        //         console.log(this.inspections.type);

        //     })
        // }
    },
    methods: {        
        createInspection() {

            console.log("Reached create inspection method.");
            console.log(this.newInspection.permitId);
            // console.log(this.newInspection.status);
            console.log(this.newInspection.DateVariable);
            console.log(this.newInspection.InspectionType);

            PermitService.createPermitInspection(this.newInspection)
                .then((response) => {
                    console.log(this.newInspection)
                    this.$router.push({ name: 'customer' });
                })
                .catch((error) => {
                    console.log("in new inspection of create inspection: ", error)
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error creating inspection: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error creating inspection: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error creating inspection: error making request");
                    }
                });
        }
    },

    created() {

        console.log("Reached created.")
        InspectionService
            .listInspectionTypes()
            .then((response => {
                console.log("Success getting inspection types.");
                console.log(response.data);
                this.inspectionTypes = response.data;


            }))
            .catch((error) => {
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting inspection types: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting inspection types: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting inspection types: error making request");
                }
            });

    }
}
</script>
<style>
.form {
  width: 100%;
  max-width: 600px;
  margin: 0 auto;
}
.permit-create{
    background-image: url('../../img/blueprint.jpg');
background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

</style>