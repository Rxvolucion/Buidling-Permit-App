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

            <!--Show if user creating the permit is admin/employee, otherwise don't show-->

            <div v-if="userRole == 'user' ? false : true">
                <label for="customer-id">Customer ID:</label>
                <input id="customer-id" name="customer-id" type="number" v-model="newPermit.customerId">
            </div>
            <button type="submit">Submit</button>
        </form>
    </div>
</template>

<script>
import PermitService from "../services/PermitService.js";
import AuthService from "../services/AuthService.js";

export default {
    components: {},
    name: "CreatePermit",
    data() {
        return {
            // userRole2: "",
            // showCustomerId: false,
            newPermit: {
                customerId: 1001,
                permitType: "",
                permitAddress: "",
                isCommercial: false,
                isActive: true,
            },
            userToken: this.$store.state.token,
            userRole: this.$store.state.user.role,            
        }
    },
    computed: {
        // currentUserRole() {
        //     console.log("Reached current user role computed")
        //     let userRole = this.getCurrentUserRole();
        //     console.log(userRole)
        //     return userRole;
        // },
        // currentUserRole: {
        //     return this.getCurrentUserRole()
        // }
        // userRole() {
        //     //console.log(this.currentUserRole)
        //     this.currentUserRole = this.getCurrentUserRole;
        //     return this.currentUserRole;

        // }
        // shortText() {
        //     let testUserRole = this.getCurrentUserRole;

        //     return testUserRole;
        // }


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
        },
        // getCurrentUserRole() {
        //     console.log("Reached get current user role method.")
        //     AuthService.getRole()
        //         // console.log("reached method")
        //         .then((response) => {
        //             let tempUserRole = response.data
        //             console.log(response.data)
        //             console.log(tempUserRole)
        //             return tempUserRole;
        //         })
        //         .catch((error) => {
        //             if (error.response) {
        //                 // error.response exists
        //                 // Request was made, but response has error status (4xx or 5xx)
        //                 console.log("Error adding owner: ", error.response.status);
        //             } else if (error.request) {
        //                 // There is no error.response, but error.request exists
        //                 // Request was made, but no response was received
        //                 console.log(
        //                     "Error adding owner: unable to communicate to server"
        //                 );
        //             } else {
        //                 // Neither error.response and error.request exist
        //                 // Request was *not* made
        //                 console.log("Error adding owner: make request");
        //             }
        //         });
        // },
    },

    created() {
        // console.log("Reached created")
        // this.userRole = this.getCurrentUserRole();
        // console.log(this.userRole)
        // AuthService.getRole()
        //     .then(response => {
        //         this.userRole2 = response.data;
        //     })
        //     .catch(error => {
        //         console.error("Failed to fetch user role: ", error);
        //     });
    }
}
</script>
<style></style>