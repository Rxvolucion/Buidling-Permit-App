<template>
    <div class="inspections">
        <h1>Inspection Requests</h1>
        <section class="container">
            <inspection v-for="inspection in inspections" v-bind:key="inspection.inspectionId" v-bind:item="inspection"/>
            
        </section>
    </div>

</template>


<script>
import Inspection from "../components/Inspection.vue"
import InspectionService from "../services/InspectionService.js";

export default {
    name: "InspectionRequests",

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


<style>


</style>