<template>
<p>PermitId: {{ item.permitId}}</p>
<p>Active: {{ item.active}}</p>
<p>CustomerId: {{ item.customerId}}</p>
<p>Commercial: {{ item.commercial}}</p>
<p>PermitAddress: {{ item.permitAddress}}</p>
<p>PermitType: {{ item.permitType}}</p>
<p>PermitStatus: {{ item.permitStatus}}</p> 
<p>-----------------------------------</p>
</template>

<script>

export default{
    name:"permit",
    props:["item"]
}
</script>


<style>

</style>