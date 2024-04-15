import axios2 from 'axios';

const config = {
    headers: {
        "Referrer-Policy": "no-referrer"
    }
};

export default {
    getCloudinaryLibrary() {
    return axios2.get('https://263769177248375:qRYH1Qi9h4TboLzOGCAIdPTpj3Y@api.cloudinary.com/v1_1/dxfude0d4/resources/image/', config)
  }
}


