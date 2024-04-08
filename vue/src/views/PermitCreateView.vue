<template>
    <div class="permit">
        <h1>Welcome to the Permit View</h1>
        <!--load create permit or edit permit component based on user selection-->
        <CreatePermit />
    </div>
</template>

<script>
import CreatePermit from '../components/CreatePermit.vue';

export default {
    computed: {

    },
    components: {
        CreatePermit
    }

}

</script>

<style>

</style>