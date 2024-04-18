<template>
    <h1>Upload Files</h1>
        <div class="image-upload d-flex flex-column align-items-center justify-content-center min-vh-100">
            <div class="card mw-65">
                <div class="upload-button container-fluid d-flex justify-content-center">
                <CloudinaryUpload />
            </div>
            <div class="container-fluid d-flex justify-content-center">
                <button class="btn btn-primary done-button mw-50" type="button" v-on:click="this.$router.push({ name: 'customerPermits', params: { userId: this.$store.state.user.userId } })">Done</button>
            </div>
            <div class="uploaded-image container-fluid d-flex justify-content-center">
                <img width="400" id="uploadedimage" src="" />
            </div>
            </div>
        </div>
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
.image-upload {
    /* display: flex; */
    /* display: flex;
    justify-content: center; */
}

.done-button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    font-size: 1.5rem;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

</style>



<!-- <template>
    
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';


</script> -->
