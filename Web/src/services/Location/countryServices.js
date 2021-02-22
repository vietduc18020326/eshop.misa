import axios from "axios";
import { apiUrl } from "../../config.json";

const ApiUrl = apiUrl + "countries/";

const getCountry = async () => {
  const country = axios.get(ApiUrl).then((res) => {
    return res;
  });
  let res = await country;
  return res.data;
};

export default {
  getCountry,
};
