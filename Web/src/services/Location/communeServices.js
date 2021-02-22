import axios from "axios";
import { apiUrl } from "../../config.json";

const ApiUrl = apiUrl + "communes/";

const getCommunes = async () => {
  const communes = axios.get(ApiUrl).then((res) => {
    return res;
  });
  let res = await communes;
  return res.data;
};

const getCommunesById = async (id) => {
  const communes = axios.get(ApiUrl + id).then((res) => {
    return res;
  });
  let res = await communes;
  return res.data;
};

export default {
  getCommunes,
  getCommunesById,
};
