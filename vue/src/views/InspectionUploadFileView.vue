<template>
    <CloudinaryUpload />
    <img width="400" id="uploadedimage" src="" />
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

</style>



<!-- <template>
    
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            // cloudinaryApiKey: 248615755938876,
            // cloudinaryApiSecret: "nYCcG4zUSvOMSerr7kBbLRMQyk4"
        };
    },
        
    methods: {
        async handleFileUpload(event) {
            const file = event.target.files[0];

            // Create a FormData object to send the file
            const formData = new FormData();
            formData.append('file', file);
            formData.append('upload_preset', 'ml_default'); // Replace with your upload preset

            try {
                const response = await axios.post('https://api.cloudinary.com/v1_1/dsychtzk7/image/upload', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    },
                    auth: {
                        username: 248615755938876,
                        password: "nYCcG4zUSvOMSerr7kBbLRMQyk4",
                    }
                });

                console.log('Upload successful:', response.data);
                // Handle successful upload response
            } catch (error) {
                console.error('Error uploading file:', error);
                // Handle upload error
            }
        }
    }
};
</script> -->
