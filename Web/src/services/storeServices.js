import axios from "axios";
import { apiUrl } from "../config.json";

const ApiUrl = apiUrl + "stores/";

const getStore = async () => {
  const stores = axios.get(ApiUrl).then((res) => {
    return res;
  });
  let res = await stores;
  return res.data;
};

const quantityStore = async () => {
  const quantity = axios.get(ApiUrl + "quantity").then((res) => {
    return res;
  });
  let res = await quantity;
  return res.data;
};

const GetStoreOfPage = async (offset, size) => {
  const stores = axios
    .get(ApiUrl + "page/" + offset + "&" + size)
    .then((res) => {
      return res;
    });
  let res = await stores;
  return res.data;
};

const getStoreById = async (id) => {
  const store = axios.get(ApiUrl + id).then((res) => {
    return res;
  });
  let res = await store;
  return res.data[0];
};

const updateStore = async (store) => {
  const result = {
    Success: true,
    data: "",
  };
  const res = axios
    .put(ApiUrl, store)
    .then((res) => {
      return res;
    })
    .catch((err) => {
      result.Success = false;
      return err.response.data.UserMsg;
    });
  result.data = await res;
  return result;
};

const insertStore = async (store) => {
  const result = {
    Success: true,
    data: "",
  };
  const res = axios
    .post(ApiUrl, store)
    .then((res) => {
      return res;
    })
    .catch((err) => {
      result.Success = false;
      return err.response.data.UserMsg;
    });
  result.data = await res;
  return result;
};

const deleteStore = async (id) => {
  await axios.delete(ApiUrl + id);
};

export default {
  getStore,
  deleteStore,
  updateStore,
  insertStore,
  getStoreById,
  quantityStore,
  GetStoreOfPage,
};
