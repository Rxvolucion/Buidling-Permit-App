<template>
<div class = archive>
  <h1>Permit and Inspection History</h1>
  <ArchivePermitsAndInspections v-for="permitAndInspectionArchive in permitAndInspectionsArchive" v-bind:key="permitAndInspectionArchive.permitId" v-bind:item="permitAndInspectionArchive" />
</div>
  </template>
  
  <script>
  import ArchivePermitsAndInspections from '../components/ArchivePermitsAndInspections.vue';
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
                    console.log("reach getinactivepermits method")
                      this.permitAndInspectionsArchive = response.data;
                      console.log(response.data)
                      console.log(this.permitAndInspectionsArchive)
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
          console.log("reched created")
      },
      components: {ArchivePermitsAndInspections}
  }
  </script>
  
  
  <style>
  
  </style> 
  