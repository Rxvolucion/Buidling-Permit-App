import axios from 'axios';

export default {

    listInspectionTypes() {
        return axios.get('/inspection/types')
    },
    
    listInspections() {
        return axios.get('/inspection')
    },

    editInspection(inspection) {
        console.log(inspection);
        return axios.put(`/inspection/${inspection.InspectionID}`, inspection)
    },

    listInspectionStatusTypes() {
        return axios.get('/inspection/status_type')
    },

    getInspectionById(inspectionId) {
        return axios.get(`/inspection/${inspectionId}`)
    },

    getInspectionsByPermitId(permitId) {
        console.log(permitId)
        return axios.get(`/inspection/permit/${permitId}`)
    },

    // uploadInspectionFile(formData) {
    //     const cloudinaryApiKey = process.env.CLOUDINARY_API_KEY;
    //     const cloudinaryApiSecret = process.env.CLOUDINARY_API_SECRET;
 
    //     return axios.post('https://api.cloudinary.com/v1_1/dsychtzk7/image/upload', formData, {
    //                 headers: {
    //                     'Content-Type': 'multipart/form-data'
    //                 },
    //                 auth: {
    //                     username: cloudinaryApiKey,
    //                     password: cloudinaryApiSecret
    //                 }
    //     });
    // }
}