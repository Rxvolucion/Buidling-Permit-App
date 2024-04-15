<template>
    <div>
      <h1>Permit And Inspection Reports</h1>
      <table class="table table-striped table-hover">
        <tbody>
            <h3>Permit Reports</h3>
    
          <tr>
            <td>Number of Active Permits</td>
            <td>{{ numberOfActivePermits }}</td>
            <td>{{ ((numberOfActivePermits / (numberOfInactivePermits + numberOfActivePermits)) * 100).toFixed() }}%</td>
          </tr>
          <tr>
            <td>Number of Inactive Permits</td>
            <td>{{ numberOfInactivePermits }}</td>
            <td>{{ ((numberOfInactivePermits / (numberOfInactivePermits + numberOfActivePermits)) * 100).toFixed()}}%</td>
          </tr>
          <tr>
            <td>Total Number Permits</td>
            <td>{{ numberOfInactivePermits + numberOfActivePermits }}</td>
            <td>100%</td>
          </tr>
          <h1></h1>
          <h3>Inspection Reports</h3>
          <tr>
            <td>Number of Pending Inspections</td>
            <td>{{ numberOfPendingInspections }}</td>
            <td>{{ ((numberOfPendingInspections / (numberOfFailedInspections + numberOfPendingInspections + numberOfPassedInspections)) * 100).toFixed()}}%</td>
          </tr>
          <tr>
            <td>Number of Passed Inspections</td>
            <td>{{ numberOfPassedInspections }}</td>
            <td>{{ ((numberOfPassedInspections / (numberOfFailedInspections + numberOfPendingInspections + numberOfPassedInspections)) * 100).toFixed()}}%</td>
          </tr>
          <tr>
            <td>Number of Failed Inspections</td>
            <td>{{ numberOfFailedInspections }}</td>
            <td>{{ ((numberOfFailedInspections / (numberOfFailedInspections + numberOfPendingInspections + numberOfPassedInspections)) * 100).toFixed()}}%</td>
          </tr>
          <tr>
            <td>Total Number of Inspections</td>
            <td>{{ numberOfFailedInspections + numberOfPendingInspections + numberOfPassedInspections }}</td>
            <td>100%</td>
          </tr>
        </tbody>
      </table>
    </div>
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
<style scoped>
.table {
  width: 100%;
  max-width: 800px;
  margin: 0 auto;
}
</style>