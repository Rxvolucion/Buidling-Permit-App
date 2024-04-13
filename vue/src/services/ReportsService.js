import axios from 'axios';

export default {
    
    getNumberOfActivePermits() {
        return axios.get('/report/active_permits')
    },
    getNumberOfInactivePermits() {
        return axios.get('/report/closed_permits')
    },
    getNumberOfPendingInspections() {
        return axios.get('/report/pending_inspections')
    }

}