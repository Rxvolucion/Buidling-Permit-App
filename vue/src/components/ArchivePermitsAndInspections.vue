<template>
    <div>
        <!--{{ item }}-->
        <p> Permit ID: {{ item.permitId }} </p>
        <p>Permit Address: {{ item.permitAddress }}</p>
        <p>Permit Type: {{ item.permitType }}</p>
        <p>Classification: {{ commercialOrResidential }}</p>
        <p>Permit Address: {{ item.permitStatus }}</p>
        <p>Customer Details: {{ item.customerDetails }}</p>
        <!-- <p>Type of Inspection: {{ item.inspectionType }}</p> -->
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
