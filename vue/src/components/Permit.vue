<template>
    <section :class="{ 'closed': !isActive, 'pending': isPending, 'approved': isApproved, 'rejected': isRejected}" class="permit">

        

        <div class="permit-info">
            <!-- {{ isActive }}
            {{ isPending }} -->
            <h2>Permit Id: {{ item.permitId }}</h2>

            <p>
                <a data-bs-toggle="collapse" href="#collapsePermitInfo" role="button" aria-expanded="false" aria-controls="collapsePermitInfo">More info
                </a>
            </p>
            <div class="collapse" id="collapsePermitInfo">
                <div class="card card-body">
                    <p>{{ openClosePermitLabel }}</p>
                    <p>Permit Status: {{ item.permitStatus }}</p>
                    <!-- <p>Active: {{ item.active }}</p> -->
                    <p>Customer Id: {{ item.customerId }}</p>
                    <!-- <p>Commercial: {{ item.commercial }}</p> -->
                    <p>Classification: {{ commercialOrResidential }}</p>
                    <p>Permit Address: {{ item.permitAddress }}</p>
                    <p>Permit Type: {{ item.permitType }}</p>
                    <p>Permit Details: {{ item.customerDetails }}</p>
                </div>
            </div>

            
        </div>
        

        <!-- {{ userRole }} -->

        <!-- Show if customer -->
        <div v-if="userRole == 'user' && item.active == true ? true : false">
            <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'permitCreateInspection', params: { permitId: this.item.permitId } })">Request Inspection</button>
        </div>
        <div v-if="userRole == 'user' ? true : false">
                <button type="button" class="btn btn-primary" v-on:click="this.$router.push({ name: 'permitInspectionResults', params: { permitId: this.item.permitId } })">View Inspection Results</button>
        </div>


        <!-- Show if employee -->
        <div v-if="userRole == 'admin' && item.active == true ? true : false" >
            <button type="button" class="btn btn-primary" v-on:click="this.$router.push({name: 'permitApproveReject', params: {permitId: this.item.permitId }})">Approve/Reject</button>
        </div>

        <div v-if="userRole == 'admin' ? true : false">
            <button type="button" class="btn btn-primary" v-on:click="closeOpenPermit">Close/Open</button>
        </div>
        
    </section>

    


<!-- Show if customer -->
<!-- <RouterLink>Edit</RouterLink> -->
<!-- <RouterLink>Request Inspection</RouterLink> -->

<!--Show if employee
<RouterLink>Edit</RouterLink>
<RouterLink>Update Status</RouterLink>
<RouterLink>Complete Inspection</RouterLink> -->


</template>

<script>
import { RouterLink } from 'vue-router';
import PermitService from '../services/PermitService.js'

export default {
    name: "permit",
    props: ["item"],
    components: { RouterLink },
    data() {
        return {
            userRole: this.$store.state.user.role,
            isActive: this.item.active,
        }
    },
    methods: {
        closeOpenPermit() {
            console.log("Reached close/open permit method.")
            console.log(parseInt(this.item.permitId))
            PermitService
                .openClosePermit(parseInt(this.item.permitId))
                .then((response => {
                    console.log("Reached success on open or closing permit.")
                    // this.$forceUpdate();
                    this.$router.push({name: 'employee'})
                }))
                .catch((error) => {
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error updating permit status: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error updating permit status: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error updating permit status: error making request");
                    }
                });

        }
    },
    computed: {
        // getPermitActiveValue() {
        //     return this.item.active;
        // }
        isPending() {
            return this.item.permitStatus === "Pending" && this.isActive
        },

        isApproved() {
            return this.item.permitStatus === "Approved" && this.isActive
        },

        isRejected() {
            return this.item.permitStatus === "Rejected" && this.isActive
        },

        commercialOrResidential() {
            if (this.item.commercial == true) {
                return "Commercial"
            }
            else {
                return "Residential"
            }
        },

        openClosePermitLabel() {
            if (this.item.active == false) {
                return "Permit Closed";
            }
            else {
                return "Permit Open";
            }
        }
    }
}
</script>


<style scoped>
section.permit {
  flex-wrap: wrap;
  /* align-content: start; */
    vertical-align: top;
  display: inline-block;
  height: auto;
  /* min-width: 300px; */
  max-width: 300px;
  border: 2px solid black;
  border-radius: 10px;
  margin: 20px;
  padding: 8px;
  /* -webkit-text-stroke: 0.5px;
  -webkit-text-stroke-color: white; */
}

a {
    color: black;
}

.permit-info {
    margin: 5px;
}

.permit-info h2 {
    /* background-color: rgba(255, 255, 255, 0.637); */
    text-align: center;
    padding: 5px;
}

button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

.closed {
    background-color: rgba(138, 133, 133, 0.534);
}

.pending {
    background-color: rgba(255, 255, 0, 0.521);
}

.rejected {
    background-color: rgba(255, 0, 0, 0.555);
}

.approved {
    background-color: rgba(0, 128, 0, 0.589);
}

</style>