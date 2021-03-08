<template>
    <div id="wrapper">
        <app-sidebar></app-sidebar>
        <div id="content-wrapper" class="d-flex flex-column">
            <div id="content">
                <app-navbar></app-navbar>
                <div class="container-fluid">
                    <h1 class="h3 mb-4 text-gray-800">Listagem de modelos de documentos</h1>
                    <b-table striped bordered hover :items="items" :fields="fields">
                    </b-table>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

import axios from "axios";

export default {
    name: "ModelosDocumento",
    data() {
        return {
          fields: [
                { key: "name", sortable: true }
            ],
          items: [],
        }
    },
    methods: {
        listModeloDoc(){
            axios.get(this.$apiHost + "documentType/list", {}, {headers: this.$apiHeader}).then(response => {
                if (response.data.success) {
                    this.items = response.data.documentTypes;
                } else {
                    setTimeout(() => {  this.listModeloDoc(); }, 2000);
                }
            }).catch(error => {
                console.log(error);
                setTimeout(() => {  this.listModeloDoc(); }, 2000);
            });
        },
        modeloIsEnabled(modeloIsEnabled){
          if (modeloIsEnabled) {
            return true;
          }else
            return false;
        }
    },

    mounted: function () {
        this.listModeloDoc();
    }
};
</script>
