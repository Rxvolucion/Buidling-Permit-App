import axios from 'axios';

export default {

    createPermit(permit) {
        return axios.post('/permit', permit)
    },
    
    listPermits(){
        return axios.get('/permit')
    },

    listPermitsByUser(userId) {
        return axios.get(`/user/${userId}`);
    }
}