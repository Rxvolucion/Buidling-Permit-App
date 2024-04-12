<template>
    <input type="file" @change="handleFileUpload">
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            cloudinaryApiKey: process.env.VUE_APP_CLOUDINARY_API_KEY,
            cloudinaryApiSecret: process.env.VUE_APP_CLOUDINARY_API_SECRET
        };
    },
        
    methods: {
        async handleFileUpload(event) {
            const file = event.target.files[0];

            // Create a FormData object to send the file
            const formData = new FormData();
            formData.append('file', file);
            formData.append('upload_preset', 'YOUR_UPLOAD_PRESET'); // Replace with your upload preset

            try {
                const response = await axios.post('https://api.cloudinary.com/v1_1/dsychtzk7/image/upload', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    },
                    auth: {
                        username: process.env.CLOUDINARY_API_KEY,
                        password: process.env.CLOUDINARY_API_SECRET
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
</script>
