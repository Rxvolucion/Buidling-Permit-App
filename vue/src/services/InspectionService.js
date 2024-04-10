import axios from 'axios';

export default {

    listInspectionTypes() {
        return axios.get('/inspection/types')
    },
    
    listInspections() {
        return axios.get('/inspection')
    },

    editInspection(inspection) {
        return axios.put(`/inspection/${inspection.inspectionId}`, inspection)
    },

    listInspectionStatusTypes() {
        return axios.get('/inspection/status_type')
    },

    getInspectionById(inspectionId) {
        return axios.get(`/inspection/${inspectionId}`)
    }
}