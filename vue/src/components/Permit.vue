<template>
<p>PermitId: {{ item.permitId}}</p>
<p>Active: {{ item.active}}</p>
<p>CustomerId: {{ item.customerId}}</p>
<p>Commercial: {{ item.commercial}}</p>
<p>PermitAddress: {{ item.permitAddress}}</p>
<p>PermitType: {{ item.permitType}}</p>
<p>PermitStatus: {{ item.permitStatus}}</p> 

<!--Show if customer-->
<RouterLink>Edit</RouterLink>
<RouterLink>Request Inspection</RouterLink>

<!--Show if employee-->
<RouterLink>Edit</RouterLink>
<RouterLink>Update Status</RouterLink>
<RouterLink>Complete Inspection</RouterLink>

<p>-----------------------------------</p>
</template>

<script>
import { RouterLink } from 'vue-router';


export default{
    name: "permit",
    props: ["item"],
    components: { RouterLink }
}
</script>


<style>

</style>