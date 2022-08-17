import axios from "axios";

const ecomApiProxy = axios.create({
  baseURL: process.env.ECOM_API_PROXY_URL,
});

export default ecomApiProxy;
