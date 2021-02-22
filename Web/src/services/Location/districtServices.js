import axios from "axios";
import { apiUrl } from "../../config.json";

const ApiUrl = apiUrl + "districts/";

const getDistrict = async () => {
  const district = axios.get(ApiUrl).then((res) => {
    return res;
  });
  let res = await district;
  return res.data;
};

const getDistrictById = async (id) => {
  const district = axios.get(ApiUrl + id).then((res) => {
    return res;
  });
  let res = await district;
  return res.data;
};

export default {
  getDistrict,
  getDistrictById,
};
