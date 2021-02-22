<template>
  <div class="pagi">
    <div class="pagi-left">
      <div class="icon-group" @click="handleFirstPage">
        <i class="pagi-icon" id="icon-firstpage"></i>
      </div>
      <div class="icon-group" @click="handlePrevPage">
        <i class="pagi-icon" id="icon-prevpage"></i>
      </div>
      <div class="pagi-left-text">
        Trang
        <input type="text" v-model="Page" class="input-page" />
        trên {{ Quantity }}
      </div>
      <div class="icon-group" @click="handleNextPage">
        <i class="pagi-icon" id="icon-nextpage"></i>
      </div>
      <div class="icon-group" @click="handleLastPage">
        <i class="pagi-icon" id="icon-lastpage"></i>
      </div>
      <div class="icon-group">
        <i class="pagi-icon" id="icon-loadpage"></i>
      </div>
    </div>
    <div class="pagi-right">
      <p>Hiển thị {{ Stores.length }} trên {{ quantityStore }} kết quả</p>
    </div>
  </div>
</template>
<script>
export default {
  name: "Pagination",
  data() {
    return {
      Page: 1,
      Quantity: 10,
    };
  },
  props: ["quantityStore", "Stores"],
  methods: {
    handleFirstPage: function() {
      this.Page = 1;
      this.$emit("loadData", this.Page);
    },
    handlePrevPage: function() {
      if (this.Page > 1) {
        this.Page--;
        this.$emit("loadData", this.Page);
      }
    },
    handleNextPage: function() {
      if (this.Page < this.Quantity) {
        this.Page++;
        this.$emit("loadData", this.Page);
      }
    },
    handleLastPage: function() {
      this.Page = this.Quantity;
      this.$emit("loadData", this.Page);
    },
  },
  watch: {
    Page: function() {
      if (this.Page == "") this.$emit("loadData", 1);
      else if (this.Page > 10) this.$emit("loadData", 10);
      else this.$emit("loadData", this.Page);
    },
  },
};
</script>
<style scoped>
.pagi-left-text {
  margin-right: 10px;
  margin-left: 10px;
  width: 30%;
}
.input-page {
  width: 18%;
}
</style>
