<template>
    <div>
        <h2>Inspection ID: {{ $route.params.inspectionId }}</h2>
        <h3>Customer Preferred Date and Time: {{ $route.params.dateVariable }}</h3> 
        <!-- <p>{{ existingInspection }}</p> -->
        <form @submit.prevent="editInspection">
            <div>
                <label for="inspection-date">New Inspection Date/Time: </label>
                <input id="inspection-date" name="inspection-date" type="datetime-local" v-model="updatedInspection.DateVariable">
            </div>
            <div>
                <label for="inspection-status-select">New Status: </label>
                <select name="inspection-status-select" id="inspection-status-select" v-model="updatedInspection.InspectionStatus" required>
                    <option value="">Please select the status</option>
                    <option v-for="inspectionStatusType in inspectionStatusTypes" :value="inspectionStatusType.statusType">{{ inspectionStatusType.statusType }}</option>
                </select>
            </div>
            <div>
                <label for="inspection-notes">Notes: </label>
                <textarea id="inspection-notes" name="inspection-notes" v-model="updatedInspection.Notes"></textarea>
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
    name: "EditInspection",
    data() {
        return {
            // userRole2: "",
            // showCustomerId: false,
            // inspections: [],
            inspectionStatus: "",
            inspectionStatusID: 0,

            inspectionTypes: [],
            inspectionStatusTypes: [],
            existingInspection: {

            },
            updatedInspection: {

                InspectionID: parseInt(this.$route.params.inspectionId),
                DateVariable: "",
                // InspectionType: this.getInspectionById,
                // InspectionStatusId: 0,
                InspectionStatus: "",
                Notes: "",
            },
            
        }
    },
    computed: {
        getInspectionTypeId() {
            return this.existingInspection.inspectionTypeId
            
        },

        // filter inspection status types to get inspection status type by the inspection status selected by the customer

        // getSelectedInspectionStatusID() {
        //     return this.inspectionStatusTypes(() =>)
        // }

        // getInspectionTypes() {
        //     return this.inspections.map(() => {
        //         this.inspections.type;
        //         console.log(this.inspections.type);

        //     })
        // }
    },
    methods: {        
        editInspection() {

            console.log("Reached edit inspection method.");
            console.log(this.updatedInspection);

            InspectionService.editInspection(this.updatedInspection)
                .then((response) => {
                    console.log(this.updatedInspection)
                    this.$router.push({ name: 'inspectionRequests' });
                })
                .catch((error) => {
                    // console.log("in new inspection of edit inspection: ", error)
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error editing inspection: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error editing inspection: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error editing inspection: error making request");
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
        InspectionService
            .listInspectionStatusTypes()
            .then((response) => {
                console.log("Success getting inspection status types.")
                console.log(this.$route.params)
                this.inspectionStatusTypes = response.data;
            })
            .catch((error) => {
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting inspection status types: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting inspection status types: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting inspection status types: error making request");
                }
            });
        InspectionService
            .getInspectionById(parseInt(this.$route.params.inspectionId))
            .then((response) => {
                console.log("Success getting the inspection by id.")
                this.existingInspection = response.data;
                console.log(response.data);
            })
            .catch((error) => {
                console.log(error);
                if (error.response) {
                    // error.response exists
                    // Request was made, but response has error status (4xx or 5xx)
                    console.log("Error getting inspection by id: ", error.response.status);
                } else if (error.request) {
                    // There is no error.response, but error.request exists
                    // Request was made, but no response was received
                    console.log("Error getting inspection by id: unable to communicate to server");
                } else {
                    // Neither error.response and error.request exist
                    // Request was *not* made
                    console.log("Error getting inspection by id: error making request");
                }
            });

    }
}
</script>
<style></style> 