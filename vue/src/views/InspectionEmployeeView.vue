<template>
    <h1 class="mb-4">Inspection Requests</h1>
    <div class="inspections">
      <div class="container">
        <div class="row">
          <div class="col-md-6 col-lg-4 mb-4" v-for="inspection in inspections" :key="inspection.inspectionId">
            <div class="card">
              <div class="card-body">
                <Inspection :item="inspection" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>


<script>
import Inspection from "../components/Inspection.vue"
import InspectionService from "../services/InspectionService.js";

export default {
    name: "InspectionEmployeeView",

    data() {
        return {
            inspections: [],
        }
    },
    components: {
        Inspection,
    },
    methods: {
        getInspections() {
            InspectionService
                .listInspections()
                .then((response => {
                    console.log("Reached success on list inspections.");
                    console.log(response.data);
                    this.inspections = response.data;
                }))
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error loading inspection requests: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error loading inspection requests: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error loading inspection requests: error making request");
                    }
                });
        }
    },
    created() {
        console.log("Reached created.")
        this.getInspections();
    }
}

</script>


<style scoped>
.inspections {
    background-color: #c2bdbd75;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  padding: 2rem;
  padding: 2rem;
}


.card {
  background-color: #f5f5f5;
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}
</style>