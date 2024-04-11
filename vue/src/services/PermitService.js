import axios from 'axios';

export default {

    createPermit(permit) {
        return axios.post('/permit', permit)
    },
    
    listPermits(){
        return axios.get('/permit')
    },

    listPermitsByCustomer(customerId) {
        return axios.get(`/permit/customer/${customerId}`);
    },

    createPermitInspection(inspection) {
        return axios.post('/inspection', inspection)
    },

    updatePermitStatus(permit) {
        return axios.put(`/permit/${permit.permitId}`, permit)
    }

    

    
}