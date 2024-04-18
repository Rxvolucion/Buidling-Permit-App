<template>
  <h1 class="mb-4">Permit and Inspection History</h1>
    <div class="archive">
      <div class="row">
        <div class="col-md-6 col-lg-4 mb-4" v-for="permitAndInspectionArchive in permitAndInspectionsArchive" :key="permitAndInspectionArchive.permitId">
          <div class="card">
            <div class="card-body">
              <ArchivePermitsAndInspections :item="permitAndInspectionArchive" />
            </div>
          </div>
        </div>
      </div>
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
            // Handle error
          });
      },
    },
    created() {
      this.getInactivePermitsWithInspections();
      console.log("reched created")
    },
    components: { ArchivePermitsAndInspections }
  }
  </script>
  
  <style scoped>
  .archive {
    background-color: #c2bdbd75;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  padding: 2rem;
  }
  .card{
    background-color: rgba(172, 168, 168, 0.534);
  }
  /* .card-body {
    font:
  color: rgb(240, 234, 234);
} */
  </style>
  