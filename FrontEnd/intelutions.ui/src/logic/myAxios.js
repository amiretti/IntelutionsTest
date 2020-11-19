import axios from "axios";

const defaultOptions = {
  baseURL: 'https://localhost:44345/',
  headers: {
    'Content-Type': 'application/json',
  },
};

let instance = axios.create(defaultOptions);

export default {
    instance
}
