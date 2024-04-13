<template>
    <div class="inspections">
        <h1>Inspection Results</h1>
        <h2>Permit ID: {{ this.$route.params.permitId }}</h2>
        <section class="container">
            <inspection v-for="inspection in inspections" v-bind:key="inspection.inspectionId" v-bind:item="inspection"/>
            <!-- {{ parseInt(this.$router.params.permitId) }}
            {{ this.$router.params }} -->
            
        </section>
    </div>

</template>


<script>
import Inspection from "../components/Inspection.vue"
import InspectionService from "../services/InspectionService.js";

export default {
    name: "InspectionResults",

    data() {
        return {
            inspections: [],
        }
    },
    components: {
        Inspection,
    },
    methods: {
        getInspectionsByPermitId() {
            InspectionService
                .getInspectionsByPermitId(parseInt(this.$route.params.permitId))
                
                .then((response) => {
                    console.log("Reached success on get inspections by permit ID.")
                    this.inspections = response.data;
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error loading inspection results for this permit: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error loading inspection results for this permit: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error loading inspection results for this permit: error making request");
                    }
                });
        },


    
    },
    created() {
        this.getInspectionsByPermitId();
    }
}

</script>


<style>


</style>