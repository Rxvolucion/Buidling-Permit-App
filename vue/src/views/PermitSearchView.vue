<template>
    
      <h1 class="mb-4">Search Permits</h1>
      <div class="permit-search">
      <div class="container">
        <div class="row justify-content-center">
        <div class="col-md-10">
        <form @submit.prevent="getPermitsBySearch" class="form row">
          <div class="form-group col-md-3">
            <label for="search-permit-id">Permit Id:</label>
            <input type="number" id="search-permit-id" name="search-permit-id" v-model="permitSearchFields.PermitId" class="form-control" />
          </div>
          <div class="form-group col-md-3">
            <label for="search-permit-address">Address:</label>
            <input type="text" id="search-permit-address" name="search-permit-address" v-model="permitSearchFields.PermitAddress" class="form-control" />
          </div>
          <div class="form-group col-md-3">
            <label for="search-customer-id">Customer Id:</label>
            <input type="number" id="search-customer-id" name="search-customer-id" v-model="permitSearchFields.CustomerId" class="form-control" />
          </div>
          <div class="form-group col-md-3">
            <label for="search-permit-type">Permit Type:</label>
            <input type="text" id="search-permit-type" name="search-permit-type" v-model="permitSearchFields.PermitType" class="form-control" />
          </div>
          <div class="col-12 d-flex justify-content-center">
            <button type="submit" class="btn btn-primary w-75 mt-4">Search</button>
          </div>
        </form>
      </div>
    </div>
</div>
      <div class="container mt-4">
        <div class="row">
          <div class="col-md-6 col-lg-4 mb-4" v-for="permit in permits" :key="permit.permitId">
            <div class="card">
              <div class="card-body">
                <Permit :item="permit" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>

<script>
import Permit from '../components/Permit.vue';
import permitService from '../services/PermitService.js';

export default {
    name: "SearchPermits",

    data() {
        return {
            permits: [],
            permitSearchFields: {
                PermitId: 0,
                PermitAddress: null,
                CustomerId: 0,
                PermitType: null,
            }
        }
    },

    computed: {

    },

    components: {
        Permit,
    },

    methods: {

        getPermitsBySearch() {
            permitService
                .getPermitBySearchFields(this.permitSearchFields)
                .then((response) => {
                    this.permits = response.data;
                    console.log("response data: ", response.data)
                    console.log("permits: ", this.permits)
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error getting permits by search: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error getting permits by search: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error getting permits by search: error making request");
                    }
                });

        },

        // getPermits(){
        //     permitService
        //     .listPermits()
        //     .then((response)=>{
        //         this.permits = response.data;
        //         console.log(this.permits)
        //     })
        //     .catch((error) => {
        //     if (error.response) {
        //         // error.response exists
        //         // Request was made, but response has error status (4xx or 5xx)
        //         console.log("Error loading pets: ", error.response.status);
        //     } else if (error.request) {
        //         // There is no error.response, but error.request exists
        //         // Request was made, but no response was received
        //         console.log("Error loading pets: unable to communicate to server");
        //     } else {
        //         // Neither error.response and error.request exist
        //         // Request was *not* made
        //         console.log("Error loading pets: error making request");
        //     }
        //     });
        // }
    },

    created() {
        console.log("reached created")
        // this.getPermits();
        this.getPermitsBySearch();
    }

}

</script>

<style scoped>
.permit-search {
  background-color: #c2bdbd75;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  padding: 2rem;
  
}

.form {
  background-color: #f5f5f5e8;
  padding: 2rem;
  border-radius: 0.5rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}
.card-body{
    background-color: #e4dddd39;

}
</style>