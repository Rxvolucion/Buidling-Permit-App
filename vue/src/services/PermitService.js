import axios from 'axios';

export default {

    createPermit(permit) {
        return axios.post('/permit', permit)
    }
}