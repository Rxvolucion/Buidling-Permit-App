<template>
<h1>Permit and Inspection History</h1>
<permitAndInspectionArchive v-for="permitAndInspectionArchive in permitAndInspectionsArchive" v-bind:key="permitAndInspectionArchive.permitAddress" v-bind:item="permitId" />
</template>

<script>
import ArchivedPermitsAndInspections from '../components/ArchivedPermitsAndInspections.vue';
import permitService from '../services/PermitService.js';
export default {
    name: "ArchiveResults",
    data() {
        return {
            permitAndInspectionsArchive: [],
        }
    },
    methods: {
        getInactivePermitsWithInspections() {
            permitService
                .getInactivePermitsWithInspections()
                .then((response) => {
                    this.permitAndInspectionsArchive = response.data;
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error loading inspection results for this value: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error loading value for permits: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error loading value for permits: error making request");
                    }
                });
        },
    },
    created() {
        this.getInactivePermitsWithInspections();
    },
    components: ArchivedPermitsAndInspections
}
</script>


<style>

</style>