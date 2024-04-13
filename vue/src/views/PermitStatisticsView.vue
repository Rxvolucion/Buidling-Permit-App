<template>
    <h1>Permit And Inspection Reports</h1>
    <p2>Number of Active Permits: {{ numberOfActivePermits }}</p2> |
    <p2>Number of Inactive Permits: {{ numberOfInactivePermits }}</p2> |
    <p2>Number of Pending Inspections: {{ numberOfPendingInspections }}</p2>  |
</template>

<script>
import reportsService from '../services/ReportsService.js';

export default {
    name: "PermitResults",

    data() {
        return {
            numberOfActivePermits: 0,
            numberOfInactivePermits: 0,
            numberOfPendingInspections: 0,
        }
    },

    methods: {
        getActivePermits() {
            reportsService
                .getNumberOfActivePermits()
                .then((response) => {
                    
                    this.numberOfActivePermits = response.data;
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
        getInactivePermits() {
            reportsService
                .getNumberOfInactivePermits()
                .then((response) => {
                    
                    this.numberOfInactivePermits = response.data;
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
        getPendingInspections() {
            reportsService
                .getNumberOfPendingInspections()
                .then((response) => {
                    
                    this.numberOfPendingInspections = response.data;
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
        this.getActivePermits();
        this.getInactivePermits();
        this.getPendingInspections();
    }
}
</script>

<style></style>
