import axios from "axios";

const ecomApiProxy = axios.create({
  baseURL: process.env.ECOM_API_PROXY_URL,
  validateStatus: () => true,
});

export default ecomApiProxy;
