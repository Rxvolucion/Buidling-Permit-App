<template>
    <h1>Upload Files</h1>
    <div class="image-upload d-flex flex-column align-items-center justify-content-center min-vh-100">
        <div class="card mw-65">
            <div class="upload-button container-fluid d-flex justify-content-center">
            <CloudinaryUpload />
        </div>
        <div class="container-fluid d-flex justify-content-center">
            <button class="btn btn-primary done-button mw-50" type="button" v-on:click="this.$router.push({ name: 'inspectionRequests' })">Done</button>
        </div>
        <div class="uploaded-image container-fluid d-flex justify-content-center">
            <img width="400" id="uploadedimage" src="" />
        </div>
        </div>
    </div>

    <!-- <CloudinaryUpload />
    <img width="400" id="uploadedimage" src="" /> -->
</template>

<script>
import CloudinaryUpload from "../components/CloudinaryUpload.vue";

export default {
    name: "InspectionUploadFile",
    components: {
        CloudinaryUpload,
    },
};
</script>

<style>
.image-upload {
    background-color: red;
    background-image: url("../../img/blueprint-sven-mieke-fteR0e2BzKo-unsplash.jpg");
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
}

.done-button {
    font-size: 2vw;
}

.card {
    padding: 15px;
    background-color: rgba(255, 255, 255, 0.722);
}

@media screen and (min-width: 900px) {
    .done-button {
        font-size: 20px;
    }
}


</style>



<!-- <template>
    
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';


</script> -->
