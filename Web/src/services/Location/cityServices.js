import axios from "axios";
import { apiUrl } from "../../config.json";

const ApiUrl = apiUrl + "cities/";

const getCity = async () => {
  const city = axios.get(ApiUrl).then((res) => {
    return res;
  });
  let res = await city;
  return res.data;
};

const getCityById = async (id) => {
  const city = axios.get(ApiUrl + id).then((res) => {
    return res;
  });
  let res = await city;
  return res.data;
};

export default {
  getCity,
  getCityById,
};
