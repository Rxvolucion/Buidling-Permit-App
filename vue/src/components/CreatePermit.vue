<template>
    <div>
        <h1>Create a Permit</h1>
        <form v-on:submit.prevent="createPermit">
            <div>
                <label for="permit-type">Permit Type</label>
                <input id="permit-type" name="permit-type" type="text" v-model="newPermit.permitType">
            </div>
            <div>
                <label for="permit-address">Permit Address</label>
                <input id="permit-address" name="permit-address" type="text" v-model="newPermit.permitAddress">
            </div>
            <div>
                <label for="is-commercial">Is it commercial?</label>
                <select v-model="newPermit.isCommercial" id="is-commercial" name="is-commercial">
                    <option value="true">Yes</option>
                    <option value="false">No</option>
                </select>
            </div>
            <div>
                <label for="customer-id">Customer ID:</label>
                <input id="customer-id" name="customer-id" type="number" v-model="newPermit.customerId">
            </div>
            <button type="submit">Create Permit</button>
        </form>
    </div>
</template>
<script>
import PermitService from "../services/PermitService.js";
export default {
    data() {
        return {
            newPermit: {
                customerId: 1001,
                permitType: "",
                permitAddress: "",
                isCommercial: false,
                isActive: true,
            }
        }
    },
    methods: {
        createPermit() {
            console.log("Reached create permit method.");
            PermitService.createPermit(this.newPermit)
                .then(response => {
                    this.$router.push({ name: 'home' });
                })
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error adding owner: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log(
                            "Error adding owner: unable to communicate to server"
                        );
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error adding owner: make request");
                    }
                });
        }
    }
}
</script>
<style></style>