<template>
    <div class="image-upload">
        <div class="upload-button container-fluid">
            <CloudinaryUpload />
        </div>
        <div class="uploaded-image container-fluid">
            <img width="400" id="uploadedimage" src="" />
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

.upload-button {

}

</style>



<!-- <template>
    
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';


</script> -->
