<template>
    <div>
        <h2>Permit ID: {{ $route.params.permitId }}</h2>
        <form @submit.prevent="editPermit">
            <!-- <div>
                <label for="permit-type">Revised Permit Type: </label>
                <input id="permit-type" name="permit-type" v-model="updatedPermit.PermitType">
            </div> -->
            <label for="permit-type-select">Revised Permit Type</label>
            <select name="permit-type-select" id="permit-type-select" v-model="updatedPermit.PermitType" required>
              <option value="">Please select a permit type</option>
              <option value="New Home">New Home</option>
              <option value="New Garage">New Garage</option>
              <option value="Building Addition">Building Addition</option>
              <option value="Electrical Work">Electrical Work</option>
              <option value="HVAC Work">HVAC Work</option>
              <option value="Interior Alterations">Interior Alterations</option>
            </select>
            <div>
                <label for="customer-details">Revised Customer Details: </label>
                <textarea id="customer-details" name="inspection-notes" v-model="updatedPermit.CustomerDetails"></textarea>
            </div>

            <div>
                <label for="permit-address">Revised Permit Address: </label>
                <input id="permit-address" name="permit-address" v-model="updatedPermit.PermitAddress">
            </div>

            <div>
                <label for="is-commercial">Is it commercial?</label>
                <select id="is-commercial" name="is-commercial" v-model="updatedPermit.Commercial">
                    <option :value=true>Yes</option>
                    <option :value=false>No</option>
                </select>
            </div>
            <button type="submit">Submit</button>
        </form>
    </div>
</template>

<script>
import PermitService from "../services/PermitService.js";
//import Permit from "../components/Permit.vue";

export default {
    components: {},
    name: "EditPermit",
    data() {
        return {
            updatedPermit: {
                permitId: parseInt(this.$route.params.permitId),
                PermitType: "",
                PermitAddress: "",
                Commercial: false,
                CustomerDetails: ""
            },
        };
    },
    methods: {
        editPermit() {
            console.log("Reached edit permit method.");
           

            PermitService.updatePermit(this.updatedPermit)
                .then(() => {
                    //console.log("Updated Permit", this.updatedPermit);
                    console.log(this.$store.state.user.userId)
                    this.$router.push({ name: 'customerPermits', params: {userId: this.$store.state.user.userId} })
                    // this.$router.push({ name: 'customerPermits', params: this.$store.state.user.userId });
                })
                .catch((error) => {
                    console.log("Error:", error);
                    if (error.response) {
                        console.log("Error editing permit: ", error.response.status);
                    } else if (error.request) {
                        console.log("Error editing permit: unable to communicate to server");
                    } else {
                        console.log("Error editing permit: error making request");
                    }
                });
        }
    },
};
</script>

<style></style>  
