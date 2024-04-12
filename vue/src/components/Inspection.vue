<template>
    <!-- <h2>test</h2> -->
    <section class="inspection">
        
        <p>Inspection Id: {{ item.inspectionId }}</p>

        <!-- Get permit ID by inspection ID -->

        <p v-if="userRole == 'admin' ? true : false">Permit Id: {{ inspectionPermitId }} </p>
        <p>Inspection Type: {{ item.inspectionType }}</p>
        <p>Date/Time: {{ dateTimeFormat }}</p>
        <p>Inspection Status: {{ item.inspectionStatus }}</p>

        <!-- <button v-on:click="this.$router.push({ name: 'inspectionEdit', params: { inspectionId: item.inspectionId } })">Edit</button> -->

        <div v-if="userRole == 'admin' ? true : false">
            <button v-on:click="this.$router.push({ name: 'inspectionEdit', params: { inspectionId: item.inspectionId, dateVariable: item.dateVariable } })">Edit</button>
        </div>
        
    </section>



</template>

<script>
import { RouterLink } from 'vue-router';
import PermitService from '../services/PermitService.js';


export default {
    name: "inspection",
    props: ["item"],
    components: { RouterLink },
    data() {
        return {
            userRole: this.$store.state.user.role,
            permitAndInspectionIds: [],
        }
    },
    computed: {
        inspectionPermitId() {
            // return the permit ID from the permitANDInspectionIds property that matches that current inspection Id

            let currentInspectionId = this.item.inspectionId;
            console.log(currentInspectionId)

            let filteredObject = this.permitAndInspectionIds.find((result) => {
                console.log(result)
                return result.inspectionId == currentInspectionId
            })
            
            console.log(filteredObject.permitId)

            return filteredObject.permitId;
        },

        dateTimeFormat() {
            const date = new Date(this.item.dateVariable);

            // Options for date and time formatting
            const options = {
                weekday: 'long', // Full day of the week (e.g., "Monday")
                year: 'numeric', // Full numeric year (e.g., "2024")
                month: 'long', // Full month name (e.g., "April")
                day: 'numeric', // Day of the month (e.g., "12")
                hour: 'numeric', // Hour (e.g., "15" for 3 PM)
                minute: 'numeric', // Minute (e.g., "30")
                second: 'numeric', // Second (e.g., "45")
                timeZoneName: 'short' // Short timezone name (e.g., "PST")
            };

            // Format the date and time using the options
            const formattedDateTime = date.toLocaleString("en-US", options);

            return formattedDateTime;

        }
    },

    methods: {
        getPermitIds() {
            PermitService
                .getPermitAndInspectionIds()
                .then((response) => {
                    console.log("reached success in getting permit and inspection ids")
                    this.permitAndInspectionIds = response.data;
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error getting permit and inspection ids: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error getting permit and inspection ids: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("getting permit and inspection ids: error making request");
                    }
                });
        }
    },

    created() {
        this.getPermitIds();
    }
}
</script>


<style scoped>
section.inspection {
  flex-wrap: wrap;
  display: inline-block;
  height: 15rem;
  min-width: 300px;
  border: 2px solid black;
  border-radius: 10px;
  margin: 20px;
}

</style>