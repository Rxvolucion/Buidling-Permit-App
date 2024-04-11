<template>
<div>
    <h2>Permit ID: {{ this.$route.params.permitId }}</h2>
    <h3>Permit Inspections</h3>
    <section class="container">
        <inspection v-for="inspection in permitInspections" v-bind:key="inspection.inspectionId" v-bind:item="inspection"/>
    </section>
</div>

<!-- hard code the status selection options for user -->

</template>


<script>
import Inspection from "../components/Inspection.vue";
import InspectionService from "../services/InspectionService.js";

export default {
    name: "ApproveRejectPermit",

    data() {
        return {
            permitInspections: [],
            permitIdParse: parseInt(this.$route.params.permitId),
        }
    },

    components: {
        Inspection,
    },

    methods: {
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
    }
}

</script>

<style>


</style>