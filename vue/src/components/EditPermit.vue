<template>
    <div class="permit-edit d-flex flex-column align-items-center justify-content-center min-vh-100">
      <div class="card p-5 shadow col-md-6 col-lg-4">
        <h2 class="mb-4 mt-2">Permit ID: {{ $route.params.permitId }}</h2>
        <form @submit.prevent="editPermit" class="form">
      <div class="form-group">
            <!-- <div>
                <label for="permit-type">Revised Permit Type: </label>
                <input id="permit-type" name="permit-type" v-model="updatedPermit.PermitType">
            </div> -->
            <label for="permit-type-select">Revised Permit Type</label>
        <p class="form-text text-muted previous-value">Previously selected: {{ this.item.permitType }}</p>
        <select name="permit-type-select" id="permit-type-select" v-model="updatedPermit.PermitType" class="form-control" required>
              <!-- <option value="">{{ item.permitType }}</option> -->
              <option value="New Home">New Home</option>
              <option value="New Garage">New Garage</option>
              <option value="Building Addition">Building Addition</option>
              <option value="Electrical Work">Electrical Work</option>
              <option value="HVAC Work">HVAC Work</option>
              <option value="Interior Alterations">Interior Alterations</option>
            </select>
        </div>
      <div class="form-group mt-4">
        <label for="customer-details">Revised Customer Details</label>
        <p class="form-text text-muted previous-value">Previously selected: {{ this.item.customerDetails }}</p>
        <textarea id="customer-details" name="inspection-notes" v-model="updatedPermit.CustomerDetails" class="form-control"></textarea>
      </div>
      <div class="form-group mt-4">
        <label for="permit-address">Revised Permit Address</label>
        <p class="form-text text-muted previous-value">Previously selected: {{ this.item.permitAddress }}</p>
        <input id="permit-address" name="permit-address" v-model="updatedPermit.PermitAddress" class="form-control" />
      </div>
      <div class="form-group mt-2">
        <label for="is-commercial">Is it commercial?</label>
        <select id="is-commercial" name="is-commercial" v-model="updatedPermit.Commercial" class="form-control">
          <option :value="true">Yes</option>
          <option :value="false">No</option>
        </select>
      </div>
      <div class="mt-4">
      <button type="submit" class="btn btn-primary">Submit</button>
    </div>
    </form>
</div>
  </div>
</template>

<script>
import PermitService from "../services/PermitService.js";
//import Permit from "../components/Permit.vue";

export default {
    components: {},
    name: "EditPermit",
    props: ["item"],
    data() {
        return {
            // updatedPermit: {
            //     permitId: parseInt(this.$route.params.permitId),
            //     PermitType: this.item.permitType,
            //     PermitAddress: this.item.permitAddress,
            //     Commercial: this.item.commercial,
            //     CustomerDetails: this.item.customerDetails
            // },
            updatedPermit: {
                permitId: parseInt(this.$route.params.permitId),
                PermitType: "",
                PermitAddress: "",
                Commercial: "",
                CustomerDetails: "",
            },
            // existingPermit: {
            //     permitId: parseInt(this.$route.params.permitId),
            //     PermitType: setDefaultPermitType(),
            //     PermitAddress: "",
            //     Commercial: "",
            //     CustomerDetails: "", 
            // }
        };
    },
    computed: {
        // setDefaultPermitType() {
        //     return this.item.permitType;
        // }
    },
    methods: {
        // setDefaultValue() {
        //     console.log("reached set default value method")
        //     // this.existingPermit.PermitType = this.item.permitType;
        //     this.existingPermit.CustomerDetails = this.item.customerDetails;
        //     this.existingPermit.PermitAddress = this.item.permitAddress;
        //     this.existingPermit.Commercial = this.item.commercial;
        // },
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

    // created call data and assign to prop item

    created() {
        // this.setDefaultValue()
        // console.log(this.updatedPermit)
    },

    

};
</script>

<style scoped>


.permit-edit{
background-image: url('../../img/blueprint.jpg');
background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.previous-value {
    font-style: italic;
}
.form{
    width: 100%;
    max-width: 600px;
    
}

</style>  
