import axios from 'axios';

export default {

  login(user) {
    return axios.post('/admin/login', user)
  },

  register(user) {
    return axios.post('/admin/register', user)
  },

  getRole() {
    return axios.get('/admin/role')
  },

  getCustomerByUserId(userId) {
    return axios.get(`/customer/${userId}`);
  },

  getCustomerIds() {
    return axios.get('/customer/customerIds');
  },

  createCustomer(customerDTO) {
    return axios.post('/customer', customerDTO)
  },

  getCloudinaryLibrary() {
    return axios.get('https://263769177248375:qRYH1Qi9h4TboLzOGCAIdPTpj3Y@api.cloudinary.com/v1_1/dxfude0d4/resources/image/')
  }

}
