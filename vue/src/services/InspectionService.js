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
    }
}