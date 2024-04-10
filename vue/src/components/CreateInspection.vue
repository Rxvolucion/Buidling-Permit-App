<template>
    <div>
        <p>Permit ID: {{ newInspection.permitId }}</p>
        <form v-on:submit.prevent="createInspection">
            <div>
                <label for="inspection-date">Inspection Request Date </label>
                <input id="inspection-date" name="inspection-date" type="datetime-local" v-model="newInspection.dateTime">
            </div>
            <div>
                <label for="inspection-type-select">Inspection Type</label>
                <select name="inspection-type-select" id="inspection-type-select" v-model="newInspection.type" required>
                    <!--use service call to get all inspection types-->
                    <option value="">Please select an inspection type</option>
                    <option v-for="inspectionType in inspectionTypes" v-bind:value="inspectionType"
                        v-bind:item="inspectionType">{{ inspectionType }}</option>
                </select>
            </div>


            <button type="submit">Submit</button>
        </form>
    </div>
</template>

<script>

import InspectionService from "../services/InspectionService.js";
import PermitService from "../services/PermitService.js";

export default {
    components: {},
    name: "CreatePermit",
    data() {
        return {
            // userRole2: "",
            // showCustomerId: false,
            // inspections: [],
            inspectionTypes: [],
            newInspection: {
                permitId: this.$route.params.permitId,
                status: "Pending",
                dateTime: "",
                type: "",
            },
            userToken: this.$store.state.token,
            userRole: this.$store.state.user.role,
        }
    },
    computed: {
        // getInspectionTypes() {
        //     return this.inspections.map(() => {
        //         this.inspections.type;
        //         console.log(this.inspections.type);

        //     })
        // }
    },
    methods: {        
        createInspection() {

            console.log("Reached create inspection method.");
            console.log(this.$route.params.permitId);
            console.log(this.newInspection.permitId);
            console.log(this.newInspection.status);
            console.log(this.newInspection.dateTime);
            console.log(this.newInspection.type);

            PermitService.createPermitInspection(this.newInspection)
                .then((response) => {
                    console.log(newInspection)
                    this.$router.push({ name: 'customer' });
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error creating inspection: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error creating inspection: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error creating inspection: error making request");
                    }
                });
        }
    },

    created() {

        console.log("Reached created.")
        InspectionService
            .listInspectionTypes()
            .then((response => {
                console.log("Success getting inspection types.");
                console.log(response.data);
                this.inspectionTypes = response.data;


            }))
            .catch((error) => {
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting inspection types: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting inspection types: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting inspection types: error making request");
                }
            });

    }
}
</script>
<style></style>