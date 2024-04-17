<template>
  <div class="container1 d-flex justify-content-center align-items-center min-vh-100">
    <div class="card p-5 shadow">
      <h3 class="mb-4">Upload Files</h3>
      <button v-on:click="open" id="upload_widget" class="cloudinary-button btn btn-primary">
        Upload files
      </button>
    </div>
        <!-- <p>
            <a href="https://cloudinary.com/documentation/upload_widget" target="_blank">Upload Widget User Guide</a>
        </p>
        <p>
            <a href="https://cloudinary.com/documentation/upload_widget_reference" target="_blank">Upload Widget
                Reference</a>
        </p> -->
    </div>
    <!-- <div>
        <button v-on:click="getCloudinaryFiles" id="get-cloudinary-files">Get Cloudinary Files</button>
    </div> -->
</template>

<script>

import CloudinaryService from "../services/CloudinaryService.js"


const cloudName = "dsychtzk7"; // replace with your own cloud name
const uploadPreset = "ml_default"; // replace with your own upload preset


// Remove the comments from the code below to add
// additional functionality.
// Note that these are only a few examples, to see
// the full list of possible parameters that you
// can add see:
//   https://cloudinary.com/documentation/upload_widget_reference

const myWidget = cloudinary.createUploadWidget(
    {
        cloudName: cloudName,
        uploadPreset: uploadPreset,
        // cropping: true, //add a cropping step
        showAdvancedOptions: true,  //add advanced options (public_id and tag)
        // sources: [ "local", "url"], // restrict the upload sources to URL and local files
        // multiple: false,  //restrict upload to a single file
        // folder: "user_images", //upload files to the specified folder
        // tags: ["users", "profile"], //add the given tags to the uploaded files
        // context: {alt: "user_uploaded"}, //add the given context data to the uploaded files
        // clientAllowedFormats: ["images"], //restrict uploading to image files only
        // maxImageFileSize: 2000000,  //restrict file size to less than 2MB
        // maxImageWidth: 2000, //Scales the image down to a width of 2000 pixels before uploading
        // theme: "purple", //change to a purple theme
    },
    (error, result) => {
        if (!error && result && result.event === "success") {
            console.log("Done! Here is the image info: ", result.info);
            document
                .getElementById("uploadedimage")
                .setAttribute("src", result.info.secure_url);
        }
    }
);

export default {
    name: "UploadWidget",
    data: () => ({
        open: function () {
            myWidget.open();
        },
    }),
    props: {
        msg: String,
        cloudinaryFiles: [],
    },
    methods: {
        getCloudinaryFiles() {
            CloudinaryService
                .getCloudinaryLibrary()
                .then((response) => {
                    console.log("Success getting cloudinary.")
                    console.log(response.data)
                    this.cloudinaryFiles = response.data;
                })
                .catch((error) => {
                    console.log(error)
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error getting cloudinary: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error getting cloudinary: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error getting cloudinary: error making request");
                    }
                });
        }
    }
};
</script>

<!-- <script>

import axios from 'axios';
import AuthService from "../services/AuthService.js"

const cloudName = "dxfude0d4"; // replace with your own cloud name
const uploadPreset = "ml_default"; // replace with your own upload preset

const myWidget = cloudinary.createUploadWidget(
    {
        cloudName: cloudName,
        uploadPreset: uploadPreset,
    },
    (error, result) => {
        if (!error && result && result.event === "success") {
            const imageUrl = result.info.secure_url;
            console.log("Uploaded image URL:", imageUrl);

            // Send the URL to your ASP.NET backend using Axios
            axios.post('https://localhost:44315/upload-url', { url: imageUrl })
                .then(response => {
                    console.log('URL sent to backend successfully');
                })
                .catch(error => {
                    console.error('Error sending URL to backend:', error);
                });
        }
    }
);

export default {
    name: "UploadWidget",
    data: () => ({
        open: function () {
            myWidget.open();
        },
        cloudinaryFiles: [],
    }),
    props: {
        msg: String,
    },
    methods: {
        getCloudinaryFiles() {
            AuthService
                .getCloudinaryLibrary()
                .then((response) => {
                    console.log("Success getting cloudinary.")
                    console.log(response.data)
                    this.cloudinaryFiles = response.data;
                })
                .catch((error) => {
                    console.log(error)
                    if (error.response) {
                        // error.response exists
                        // Request was made, but response has error status (4xx or 5xx)
                        console.log("Error getting cloudinary: ", error.response.status);
                    } else if (error.request) {
                        // There is no error.response, but error.request exists
                        // Request was made, but no response was received
                        console.log("Error getting cloudinary: unable to communicate to server");
                    } else {
                        // Neither error.response and error.request exist
                        // Request was *not* made
                        console.log("Error getting cloudinary: error making request");
                    }
                });
        }
    }
};

</script> -->

<style scoped>

.container1 {
  background-color: #bbb5b5;
}

.card {
  width: 100%;
  max-width: 500px;
}


button {
    margin: 0.5rem;
    background-color: #2c3e50;
    border-color: #2c3e50;
    
    /* background-color: rgb(95, 94, 94);
    outline-color: black; */
}

</style>