<template>
    <div>
        <!--{{ item }}-->
        <p> Permit ID: {{ item.permitId }} </p>
        <p>Permit Address: {{ item.permitAddress }}</p>
        <p>Permit Type: {{ item.permitType }}</p>
        <p>Classification: {{ commercialOrResidential }}</p>
        <p>Permit Status: {{ item.permitStatus }}</p>
        <p>Customer Details: {{ item.customerDetails }}</p>
<<<<<<< HEAD
        <!-- <p>Type of Inspection: {{ item.inspectionType }}</p> -->
=======
        <!-- <p>Inspection Status: {{ item.inspectionType }}</p> -->
>>>>>>> 91634cf2054b8a4fccd2bb89502496f1468f631c
    </div>

</template>

<script>
import { RouterLink } from 'vue-router';

export default {
//name: "permitAndInspectionArchive",
props: ["item"],
components: { RouterLink },
data() {
    return {
    
    }
},
methods: {
    
},
computed: {
    commercialOrResidential() {
        if (this.item.commercial == true) {
            return "Commercial"
        }
        else {
            return "Residential"
        }
    },
   
}
}
</script>


<style scoped>

</style> 
