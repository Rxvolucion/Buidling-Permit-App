<template>
    <section class="permit">
        <p>Permit Id: {{ item.permitId }}</p>
        <p>Active: {{ item.active }}</p>
        <p>Customer Id: {{ item.customerId }}</p>
        <p>Commercial: {{ item.commercial }}</p>
        <p>Permit Address: {{ item.permitAddress }}</p>
        <p>Permit Type: {{ item.permitType }}</p>
        <p>Permit Status: {{ item.permitStatus }}</p>

        <!-- {{ userRole }} -->

        <!-- Show if customer -->
        <div v-if="userRole == 'user' ? true : false">
            <button v-on:click="this.$router.push({ name: 'permitCreateInspection', params: { permitId: this.item.permitId } })">Request Inspection</button>
        </div>


        <!-- Show if employee -->
        <div v-if="userRole == 'admin' ? true : false">
            <button v-on:click="this.$router.push({name: 'permitApproveReject', params: {permitId: this.item.permitId }})">Approve/Reject</button>
        </div>

        <div v-if="userRole == 'admin' ? true : false">
            <button v-on:click="">Close/Opent</button>
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


export default {
    name: "permit",
    props: ["item"],
    components: { RouterLink },
    data() {
        return {
            userRole: this.$store.state.user.role,
        }
    },
    methods: {
        closeOpenPermit() {
            console.log("Reached close/open permit method.")
            
        }
    }
}
</script>


<style scoped>
section.permit {
  flex-wrap: wrap;
  display: inline-block;
  height: 20rem;
  min-width: 300px;
  border: 2px solid black;
  border-radius: 10px;
  margin: 20px;
}

</style>