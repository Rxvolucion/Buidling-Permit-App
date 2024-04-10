<template>
    <section class="inspection">
        
        <p>Id: {{ item.inspectionId }}</p>
        <p>Type: {{ item.type }}</p>
        <p>Date/Time: {{ item.customerId }}</p>
        <p>Status: {{ item.commercial }}</p>

    </section>



</template>

<script>
import { RouterLink } from 'vue-router';


export default {
    name: "inspection",
    props: ["item"],
    components: { RouterLink },
    data() {
        return {

        }
    }
}
</script>


<style scoped>
section.inspection {
  flex-wrap: wrap;
  display: inline-block;
  height: 20rem;
  min-width: 300px;
  border: 2px solid black;
  border-radius: 10px;
  margin: 20px;
}

</style>