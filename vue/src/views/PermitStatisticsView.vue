<template>
    <h1>Permit And Inspection Reports</h1>
    <ul>
        <li>Number of Active Permits: {{ numberOfActivePermits }}</li>
        <li>Number of Inactive Permits: {{ numberOfInactivePermits }}</li>
        <li>Number of Pending Inspections: {{ numberOfPendingInspections }}</li>
        <li>Number of Passed Inspections: {{ numberOfPassedInspections }}</li>
        <li>Number of Failed Inspections: {{ numberOfFailedInspections }}</li>
    </ul>
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
            numberOfPassedInspections: 0,
            numberOfFailedInspections: 0,
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
        getPassedInspections() {
            reportsService
                .getNumberOfPassedInspections()
                .then((response) => {
                    this.numberOfPassedInspections = response.data;
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
        getFailedInspections() {
            reportsService
                .getNumberOfFailedInspections()
                .then((response) => {
                    this.numberOfFailedInspections = response.data;
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
        this.getPassedInspections();
        this.getFailedInspections();
    }
}
</script>
<style></style>