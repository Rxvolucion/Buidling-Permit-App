<template>
            <h3 class="mb-4">Permit ID: {{ this.$route.params.permitId }}</h3>
    <div>

      <div class="container">

        <form @submit.prevent="editPermitStatus" class="form">
          <div class="form-group">
            <label for="permit-status-select">New Permit Status:</label>
            <select name="permit-status-select" id="permit-status-select" v-model="updatedPermit.permitStatus" class="form-control" required>
              <option value="">Please select the status</option>
              <option value="Approved">Approve</option>
              <option value="Rejected">Reject</option>
            </select>
          </div>
          <div class="d-flex justify-content-end">
            <button type="submit" class="btn btn-primary w-25 mt-4">Submit</button>
          </div>
        </form>
      </div>
      <div class="container mt-4">
        <div class="row">
          <div class="col-md-6 col-lg-4 mb-4" v-for="inspection in permitInspections" :key="inspection.inspectionId">
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
import Inspection from "../components/Inspection.vue";
import InspectionService from "../services/InspectionService.js";
import PermitService from "../services/PermitService.js";
// import AuthService from "../services/AuthService.js";

export default {
    name: "ApproveRejectPermit",

    data() {
        return {
            permitInspections: [],
            permitIdParse: parseInt(this.$route.params.permitId),
            updatedPermit: {
                permitStatus: "",
                permitId: parseInt(this.$route.params.permitId),
            },
            // cloudinaryFiles: [],
        }
    },

    components: {
        Inspection,
    },

    methods: {
        // getCloudinaryFiles() {
        //     AuthService
        //         .getCloudinaryLibrary()
        //         .then((response) => {
        //             console.log("Reached success on getting Cloudinary files.")
        //             console.log(response.data)
        //             this.cloudinaryFiles = response.data;
        //         })
        // },
        editPermitStatus() {
            PermitService
                .updatePermitStatus(this.updatedPermit)
                .then((response) => {
                    console.log("Reached success on update permit status")
                    console.log(this.updatedPermit)
                    console.log(response)
                    this.$router.push({ name: "searchPermit"})
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error updating permit status: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error updating permit status: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error updating permit status: error making request");
                    }
                });
        },
        getInspectionsByPermitId() {
            InspectionService
                .getInspectionsByPermitId(this.permitIdParse)
                .then((response => {
                    console.log("Reached success on get inspections by permit ID")
                    console.log(response.data)
                    this.permitInspections = response.data;
                }))
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error loading inspections by permit ID: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error loading inspections by permit ID: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error loading inspections by permit ID: error making request");
                    }
                });

        }
    },

    created() {
        console.log("Reached created.")
        this.getInspectionsByPermitId();
        // this.getCloudinaryFiles();
    }
}

</script>

<style scoped>
.form {
  background-color: #efededa8;
  padding: 2rem;
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}

.card {
  background-color: #f5f5f5;
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}
</style>