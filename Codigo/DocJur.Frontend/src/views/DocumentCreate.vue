<template>
    <div id="wrapper">
        <app-sidebar></app-sidebar>
        <div id="content-wrapper" class="d-flex flex-column">
            <div id="content">
                <app-navbar></app-navbar>
                <div class="container-fluid">
                    <h1 class="h3 mb-4 text-gray-800">Gerar Documento</h1>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Selecione o tipo de documento</span>
                        </div>
                        <select class="form-control" v-model="documentTypeSelected">
                            <option value=""></option>
                            <option v-for="documentType in documentTypes" :key="documentType.id" :value= documentType.id >{{documentType.name}}</option>
                        </select>
                        <div class="input-group-append">
                            <button class="btn btn-outline-secondary" type="button" v-on:click="listFields()">Buscar</button>
                        </div>
                    </div>
                    <hr>
                    <form id="formDocumentCreate">
                        <div v-for="field in fields" :key="field.id">
                            <yesno-field v-if="field.fieldType == 1" :fieldLabel="field.label" :fieldName="field.name"></yesno-field>
                            <money-field v-if="field.fieldType == 2" :fieldLabel="field.label" :fieldName="field.name"></money-field>
                            <text-field v-if="field.fieldType == 3" :fieldLabel="field.label" :fieldName="field.name"></text-field>
                            <date-field v-if="field.fieldType == 4" :fieldLabel="field.label" :fieldName="field.name"></date-field>
                            <cpf-field v-if="field.fieldType == 5" :fieldLabel="field.label" :fieldName="field.name"></cpf-field>
                        </div>
                        <button type="button" class="btn btn-primary" v-on:click="gerarDocumento()">Gerar Documento</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    name: "DocumentCreate",
    data() {
        return {
            documentTypes: [],
            documentTypeSelected: "",
            fields: []
        }
    },
    methods: {
        listDocumentType: function(){
            axios.get(this.$apiHost + "documentType/list", {}, {headers: this.$apiHeader}).then(response => {
                if (response.data.success) {
                    this.documentTypes = response.data.documentTypes;
                } else {
                    setTimeout(() => {  this.listDocumentType(); }, 2000);
                }
            }).catch(error => {
                console.log(error);
                setTimeout(() => {  this.listDocumentType(); }, 2000);
            });
        },
        listFields: function(){
            axios.post(this.$apiHost + "documentTypeField/list", {id: this.documentTypeSelected }, {headers: this.$apiHeader}).then(response => {
                if (response.data.success) {
                    this.fields = response.data.fields;
                } else {
                    setTimeout(() => {  this.listFields(); }, 2000);
                }
            }).catch(error => {
                console.log(error);
                setTimeout(() => {  this.listFields(); }, 2000);
            });
        },
        gerarDocumento: function(){
            var dataToSend = {
                DocumentTypeId: this.documentTypeSelected,
                UserId: this.$session.get('userid'),
                Fields: $('#formDocumentCreate').serializeArray()
            };
            console.log(dataToSend);

            axios.post(this.$apiHost + "document/create", dataToSend, {headers: this.$apiHeader}).then(response => {
                if (response.data.success) {
                    alert("Documento criado com sucesso.");
                    this.$router.push("/documentos");
                } else {
                    alert(response.data.message);
                }
            }).catch(error => {
                console.log(error);
                alert("Erro inesperado, consulte o administrador do sistema.");
            });
        }
    },
    mounted: function(){
        this.listDocumentType();
    }

}
</script>

<style>

</style>