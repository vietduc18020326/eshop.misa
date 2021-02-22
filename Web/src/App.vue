<template>
  <div id="app">
    <Navbar />
    <div class="panel-right">
      <Header :Name="storeName" />
      <StoreList @ClickStore="inputStoreName" />
    </div>
  </div>
</template>

<script>
import "./assets/css/main.css";
import Navbar from "./components/layout/Navbar";
import Header from "./components/layout/Header";
import StoreList from "./views/dictionary/storeManagement/StoreList";

export default {
  name: "App",
  components: {
    Navbar,
    Header,
    StoreList,
  },
  data() {
    return {
      storeName: "",
    };
  },
  methods: {
    inputStoreName: function(name) {
      this.storeName = name;
    },
  },
};
</script>

<style></style>
