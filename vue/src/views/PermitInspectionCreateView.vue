<template>
    <div class="inspection">
        <h1>Request an Inspection</h1>
        <!--load create permit or edit permit component based on user selection-->
        <CreateInspection />
    </div>
</template>

<script>
import CreateInspection from '../components/CreateInspection.vue';

export default {
    computed: {

    },
    components: {
        CreateInspection
    }

}

</script>

<style>

</style>