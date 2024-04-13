<template>
    <div class="uw">
        <h3>Upload Files to Inspection</h3>
        <button v-on:click="open" id="upload_widget" class="cloudinary-button">
            Upload files
        </button>
        <!-- <p>
            <a href="https://cloudinary.com/documentation/upload_widget" target="_blank">Upload Widget User Guide</a>
        </p>
        <p>
            <a href="https://cloudinary.com/documentation/upload_widget_reference" target="_blank">Upload Widget
                Reference</a>
        </p> -->
    </div>
</template>

<<<<<<< HEAD
<!-- <script>
const cloudName = "dsychtzk7"; // replace with your own cloud name
=======
<script>
const cloudName = "dxfude0d4"; // replace with your own cloud name
>>>>>>> 8bba97abb2f6843e15c8d4095e8021a1532be5d2
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
        // showAdvancedOptions: true,  //add advanced options (public_id and tag)
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
    },
};
</script> -->
<script>

import axios from 'axios';

const cloudName = "dsychtzk7"; // replace with your own cloud name
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
            axios.post('https://localhost:44315/upload', { url: imageUrl })
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
    }),
    props: {
        msg: String,
    },
};

</script>