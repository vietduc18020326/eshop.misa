<template>
  <div>
    <form class="store-dialog" @submit.prevent="hanldeSubmit">
      <div class="form-header">
        <strong class="title item-center">{{
          isDialogAdd ? "Thêm mới cửa hàng" : "Sửa thông tin cửa hàng"
        }}</strong>
        <div class="btn-x item-center" @click="closeDialog">
          <i class="icon-x"></i>
        </div>
        <div class="clear"></div>
      </div>
      <div class="form-body">
        <div class="content-center">
          <div class="input-requied">
            <label class="input-title">Mã cửa hàng *</label>
            <input
              ref="storeCode"
              type="text"
              v-model="Store.StoreCode"
              @blur="$v.Store.StoreCode.$touch()"
            />
            <template v-if="$v.Store.StoreCode.$error">
              <i class="icon_err" v-if="!$v.Store.StoreCode.required" />
              <span class="error-msg" v-if="!$v.Store.StoreCode.required"
                >Không được để trống</span
              >
            </template>
          </div>
          <div class="input-requied">
            <label class="input-title">Tên cửa hàng *</label>
            <input
              ref="storeName"
              type="text"
              v-model="Store.StoreName"
              @blur="$v.Store.StoreName.$touch()"
            />
            <template v-if="$v.Store.StoreName.$error">
              <i class="icon_err" v-if="!$v.Store.StoreName.required" />
              <span class="error-msg" v-if="!$v.Store.StoreName.required"
                >Không được để trống</span
              >
            </template>
          </div>
          <div class="input-requied">
            <label class="input-title">Địa chỉ *</label>
            <textarea
              id="store-address"
              ref="address"
              type="text"
              v-model="Store.Address"
              @blur="$v.Store.Address.$touch()"
            />
            <template v-if="$v.Store.Address.$error">
              <i class="icon_err" v-if="!$v.Store.Address.required" />
              <span class="error-msg" v-if="!$v.Store.Address.required"
                >Không được để trống</span
              >
            </template>
          </div>
          <div class="store-left">
            <label class="input-title">Số điện thoại</label>
            <input
              class="input-notrequied"
              type="text"
              v-model="Store.PhoneNumber"
            />
          </div>
          <div class="store-right">
            <label class="input-title">Mã số thuế</label>
            <input
              class="input-notrequied"
              type="text"
              v-model="Store.StoreTaxCode"
            />
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Quốc gia</label>
            <select
              class="input-notrequied"
              v-model="Store.CountryId"
              @click="chooseCountry"
            >
              <option
                v-for="(country, index) in Country"
                :key="index"
                :value="country.CountryId"
                >{{ country.CountryName }}</option
              >
            </select>
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Tỉnh/Thành phố</label>
            <select
              class="input-notrequied"
              v-model="Store.CityId"
              @click="chooseCity"
            >
              <option
                v-for="(city, index) in City"
                :key="index"
                :value="city.CityId"
                >{{ city.CityName }}</option
              >
            </select>
          </div>
          <div class="store-right">
            <label class="input-title">Quận/Huyện</label>
            <select
              class="input-notrequied"
              v-model="Store.DistrictId"
              @click="chooseDistrict"
            >
              <option
                v-for="(district, index) in District"
                :key="index"
                :value="district.DistrictId"
                >{{ district.DistrictName }}</option
              >
            </select>
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Phường/Xã</label>
            <select class="input-notrequied" v-model="Store.CommunesId">
              <option
                v-for="(communes, index) in Communes"
                :key="index"
                :value="communes.CommunesId"
                >{{ communes.CommunesName }}</option
              >
            </select>
          </div>
          <div class="store-right">
            <label class="input-title">Đường phố</label>
            <input
              type="text"
              class="input-notrequied"
              v-model="Store.Streets"
            />
          </div>
          <div class="clear"></div>
        </div>
      </div>
      <div class="form-footer">
        <div class="store-left">
          <i class="icon-help"></i>
          <strong>Trợ giúp</strong>
        </div>
        <div class="store-right" :class="{ footer_update: isDialogUpdate }">
          <button class="btn-save item-center">
            <i class="icon-save"></i>
            <p style="color: white">Lưu</p>
          </button>
          <button class="btn-add item-center">
            <i class="icon-add"></i>
            <p style="color: #00577b" class="text-insert">Lưu và thêm mới</p>
          </button>
          <div class="btn-cancel item-center" @click="closeDialog">
            <i class="icon-x"></i>
            <p style="color: #00577b">Hủy bỏ</p>
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </form>
  </div>
</template>

<script>
import countryServices from "../../../services/Location/countryServices";
import cityServices from "../../../services/Location/cityServices";
import districtServices from "../../../services/Location/districtServices";
import communeServices from "../../../services/Location/communeServices";
import storeServices from "../../../services/storeServices";
import { required } from "vuelidate/lib/validators";

export default {
  name: "StoreProfileDetail",
  props: ["isDialog", "isUpdate", "store"],
  data() {
    return {
      isDialogAdd: false,
      isDialogUpdate: false,
      Store: {},
      Country: [],
      City: [],
      District: [],
      Communes: [],
      Alert: {
        Text: "",
        Success: false,
      },
    };
  },
  validations: {
    Store: {
      StoreCode: {
        required,
      },
      StoreName: {
        required,
      },
      Address: {
        required,
      },
    },
  },
  async mounted() {
    this.isDialogAdd = this.isDialog;
    this.isDialogUpdate = this.isUpdate;
    if (this.isDialogAdd) this.Store = this.store;
    if (this.isDialogUpdate) {
      this.Store = await storeServices.getStoreById(this.store.StoreId);
      this.City = await cityServices.getCity();
      this.District = await districtServices.getDistrict();
      this.Communes = await communeServices.getCommunes();
    }
    this.Country = await countryServices.getCountry();
    this.focusInput();
  },
  methods: {
    //đóng dialog
    closeDialog: function() {
      this.isDialogAdd = false;
      this.isDialogUpdate = false;
      this.$emit("CloseDialog", this.Alert);
    },
    //Xử lí cập nhật khi submit
    handleUpdate: async function() {
      this.$v.Store.$touch();
      if (this.$v.Store.$invalid) {
        if (!this.$v.Store.Address.required) this.$refs.address.focus();
        if (!this.$v.Store.StoreName.required) this.$refs.storeName.focus();
        if (!this.$v.Store.StoreCode.required) this.$refs.storeCode.focus();

        return;
      }
      var resultUpdate = await storeServices.updateStore(this.Store);
      if (!resultUpdate.Success) {
        this.alertForm("Mã cửa hàng bị trùng. Vui lòng nhập lại", false);
        this.$refs.storeCode.focus();
        return;
      } else {
        this.alertForm("Cập nhật thành công", true);
        this.closeDialog();
      }
    },
    //Xử lí form thông báo khi submit cập nhật, thêm mới
    alertForm: function(text, success) {
      this.Alert.Text = text;
      this.Alert.Success = success;
      this.$emit("handleAlert", this.Alert);
    },
    //Xử lí thêm mới khi submit
    hanldeInsert: async function() {
      this.$v.Store.$touch();
      if (this.$v.Store.$invalid) {
        if (!this.$v.Store.Address.required) this.$refs.address.focus();
        if (!this.$v.Store.StoreName.required) this.$refs.storeName.focus();
        if (!this.$v.Store.StoreCode.required) this.$refs.storeCode.focus();
        return;
      }
      var resultInsert = await storeServices.insertStore(this.Store);
      if (!resultInsert.Success) {
        this.alertForm("Mã cửa hàng bị trùng. Vui lòng nhập lại", false);
        this.$refs.storeCode.focus();
        return;
      } else {
        this.alertForm("Thêm mới thành công", true);
        this.closeDialog();
      }
    },
    hanldeSubmit: function() {
      if (this.isDialogUpdate) this.handleUpdate();
      if (this.isDialogAdd) this.hanldeInsert();
    },
    //Lấy dữ liệu city khi đã chọn country
    chooseCountry: async function() {
      this.City = await cityServices.getCityById(this.Store.CountryId);
    },
    //Lẩy dữ liệu district khi chọn city
    chooseCity: async function() {
      this.District = await districtServices.getDistrictById(this.Store.CityId);
    },
    //Lấy dữ liệu communes khi chọn district
    chooseDistrict: async function() {
      this.Communes = await communeServices.getCommunesById(
        this.Store.DistrictId
      );
    },
    focusInput: function() {
      this.$refs.storeCode.focus();
    },
  },
};
</script>

<style scoped>
.error-msg {
  color: red;
  position: absolute;
  top: 107%;
  left: 18%;
  font-size: 13px;
}
.text-insert {
  font-weight: 600;
}
/* .footer_update {
  width: 40% !important;
  /* margin-rght: -105px !important; */

select:required:invalid {
  color: gray;
}
option[value="-1"][disabled] {
  display: none;
}
option {
  color: black;
}


</style>
