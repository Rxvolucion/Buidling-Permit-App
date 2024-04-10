import axios from 'axios';

export default {

    listInspectionTypes() {
        return axios.get('/inspection/types')
    },
    
    listInspections() {
        return axios.get()
    }
}