<template>
    <div>
        <!--{{ item }}-->
        <div>
            <p class="field"> Permit ID: </p><p>{{ item.permitId }}</p>
        </div>
        <div>
            <p class="field"> Permit Address:  </p><p>{{ item.permitAddress }}</p>
        </div>
        <div>
            <p class="field"> Permit Type: </p><p>{{ item.permitType }}</p>
        </div>
        <div>
            <p class="field"> Classification: </p><p>{{ commercialOrResidential }}</p>
        </div>
        <div>
            <p class="field"> Permit Status: </p><p>{{ item.permitStatus }}</p>
        </div>
        <div>
            <p class="field"> Customer Details: </p><p>{{ item.customerDetails }}</p>
        </div>

        <!-- <p>Permit Address: {{ item.permitAddress }}</p>
        <p>Permit Type: {{ item.permitType }}</p>
        <p>Classification: {{ commercialOrResidential }}</p>
        <p>Permit Status: {{ item.permitStatus }}</p>
        <p>Customer Details: {{ item.customerDetails }}</p> -->
        <!-- <p>Inspection Status: {{ item.inspectionType }}</p> -->
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

p {
    display: inline;
}

.field {
    font-weight: bold;
    /* font-size: 36px; */
}

</style> 
