<template>
<div>
    <h2>Permit ID: {{ this.$route.params.permitId }}</h2>
    <h3>Permit Inspections</h3>
</div>
<div>
    <section class="container">
        <inspection v-for="inspection in permitInspections" v-bind:key="inspection.inspectionId" v-bind:item="inspection"/>
    </section>
</div>
<div>
    <form v-on:submit.prevent="editPermitStatus">
        <label for="permit-status-select">New Permit Status: </label>
        <!-- hard code the status selection options for user -->
        <select name="permit-status-select" id="permit-status-select" v-model="updatedPermit.permitStatus" required>
            <option value="">Please select the status</option>
            <option value="Approved">Approve</option>
            <option value="Rejected">Reject</option>
        </select>
        <button type="submit">Submit</button>
    </form>
</div>


</template>


<script>
import Inspection from "../components/Inspection.vue";
import InspectionService from "../services/InspectionService.js";
import PermitService from "../services/PermitService.js";
import AuthService from "../services/AuthService.js";

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
            cloudinaryFiles: [],
        }
    },

    components: {
        Inspection,
    },

    methods: {
        getCloudinaryFiles() {
            AuthService
                .getCloudinaryLibrary()
                .then((response) => {
                    console.log("Reached success on getting Cloudinary files.")
                    console.log(response.data)
                    this.cloudinaryFiles = response.data;
                })
        },
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
        this.getCloudinaryFiles();
    }
}

</script>

<style>


</style>