<template>
    <CloudinaryUpload />
    <img width="400" id="uploadedimage" src="" />
</template>

<script>
import CloudinaryUpload from "../components/CloudinaryUpload.vue";

export default {
    name: "PermitUploadFile",
    components: {
        CloudinaryUpload,
    },
};
</script>

<style>

</style>



<!-- <template>
    
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';


</script> -->
