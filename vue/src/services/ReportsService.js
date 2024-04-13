import axios from 'axios';

export default {
    
    getNumberOfActivePermits() {
        return axios.get('/report/active_permits')
    },

}