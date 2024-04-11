<template>
    <!-- <h2>test</h2> -->
    <section class="inspection">
        
        <p>Inspection Id: {{ item.inspectionId }}</p>
        <p>Type: {{ item.inspectionType }}</p>
        <p>Date/Time: {{ item.dateVariable }}</p>
        <p>Status: {{ item.inspectionStatus }}</p>

        <!-- Only show for employee-->
        <div v-if="userRole == 'admin' ? true : false">
            <button v-on:click="this.$router.push({ name: 'inspectionEdit', params: { inspectionId: item.inspectionId } })">Edit</button>
        </div>
        
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
            userRole: this.$store.state.user.role,
        }
    }
}
</script>


<style scoped>
section.inspection {
  flex-wrap: wrap;
  display: inline-block;
  height: 15rem;
  min-width: 300px;
  border: 2px solid black;
  border-radius: 10px;
  margin: 20px;
}

</style>