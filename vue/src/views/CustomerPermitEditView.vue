<template>
  <div class="edit-permit">
      <h1>Edit Permit</h1>
      <EditPermit v-bind:item="currentPermit"/>
  </div>
</template>

<script>
import EditPermit from '../components/EditPermit.vue';
import PermitService from '../services/PermitService.js';

export default {
  data() {
    return {
      permitId: this.$route.params.permitId,
      currentPermit: {}
    }
  },

  computed: {

  },

  components: {
  EditPermit
  },

  methods: {
    getCurrentPermit() {
      PermitService
        .getPermitById(this.permitId)
        .then((response) => {
          console.log("Reached success with getting permit by id")
          this.currentPermit = response.data;
        })
        .catch((error) => {
          // console.log("in new inspection of edit inspection: ", error)
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error getting permit by permit Id: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error getting permit by permit Id: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error getting permit by permit Id: error making request");
          }
        });
    }
  },

  created() {
    this.getCurrentPermit();
  }

}

</script>

<style>

</style>
  