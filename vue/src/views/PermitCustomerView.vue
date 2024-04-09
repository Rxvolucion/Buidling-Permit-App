<template>
    <div class="permit">
        <h1>Welcome to My Permits</h1>
        <!--load create permit or edit permit component based on user selection-->
        <permit v-for="permit in permits" v-bind:key = "permit.permitId" v-bind:item = "permit" />
    </div>
</template>

<script>
import Permit from '../components/Permit.vue';
import permitService from '../services/PermitService.js';

export default {
    name: "MyPermits",
    data() {
        return {
            userId: 0,
            permits: [],
        }
    },
    computed: {

    },
    components: {
        Permit,
    },

    methods: {
    getMyPermits(){
        permitService
        .listPermitsByUser(this.userId)
        .then((response)=>{
            this.permits = response.data;
            console.log(this.permits)
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error loading pets: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error loading pets: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error loading pets: error making request");
          }
        });
    }
},
created(){ 
    console.log("reached created")
    this.userId = this.$route.params.userId;
    console.log(this.userId)
    this.getMyPermits();
}

}

</script>

<style>

</style>