<template>
    <div class="permit">
        <h1>Search Permits</h1>
        <!--load create permit or edit permit component based on user selection-->
        <section class="container">
            <div class="search-fields">
                <form @submit.prevent="getPermitsBySearch" class="form">
                    <div class="form-group">
                        <label for="search-permit-id">Permit Id:</label>
                        <input type="number" id="search-permit-id" name="search-permit-id"
                            v-model="permitSearchFields.PermitId"><br><br>
                        <label for="search-permit-address">Permit Address:</label>
                        <input type="text" id="search-permit-address" name="search-permit-address"
                            v-model="permitSearchFields.PermitAddress"><br><br>
                        <label for="search-customer-id">Customer Id:</label>
                        <input type="number" id="search-customer-id" name="search-customer-id"
                            v-model="permitSearchFields.CustomerId"><br><br>
                        <label for="search-permit-type">Permit Type:</label>
                        <input type="text" id="search-permit-type" name="search-permit-type"
                            v-model="permitSearchFields.PermitType"><br><br>
                    </div>
                    <input type="submit" value="Search" class="btn btn-primary w-75" />
                </form>
            </div>
            <div class="permits">
                <permit v-for="permit in permits" v-bind:key="permit.permitId" v-bind:item="permit" />
            </div>
        </section>

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

<style></style>