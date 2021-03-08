<template>
    <div id="wrapper">
        <app-sidebar></app-sidebar>
        <div id="content-wrapper" class="d-flex flex-column">
            <div id="content">
                <app-navbar></app-navbar>
                <div class="container-fluid">
                    <h1 class="h3 mb-4 text-gray-800">Usuários</h1>
                        <b-button
                            size="sm"
                            @click="openCreateModal($event.target)"
                            class="m-3 float-right" 
                            variant="outline-primary"
                        ><i class="fas fa-plus fa-sm fa-fw mr-1"></i>Adicionar</b-button>
                    <b-table striped bordered hover :items="items" :fields="fields">
                        <template v-slot:cell(opcao)="row">
                            <b-button
                                size="sm"
                                @click="openEditModal(row.item, row.index, $event.target)"
                                class="mr-1"
                                variant="primary"
                            ><i class="fas fa-edit fa-sm fa-fw mr-1"></i></b-button>
                            <b-button
                                size="sm"
                                @click="openDeleteModal(row.item, row.index, $event.target)"
                                class="mr-1"
                                variant="danger"
                            ><i class="fas fa-trash fa-sm fa-fw mr-1"></i></b-button>
                        </template>
                    </b-table>

                    <b-modal :id="infoModal.id" @ok="submitForm($event)" title="Editar usuário">
                        <b-form-group label="Email:">
                            <b-form-input v-model="infoModal.email" type="email" required></b-form-input>
                        </b-form-group>
                        <b-form-group label="Username:">
                            <b-form-input v-model="infoModal.username" required></b-form-input>
                        </b-form-group>
                        <b-form-group label="Senha:">
                            <b-form-input v-model="infoModal.password" type="password" required></b-form-input>
                        </b-form-group>
                    </b-modal>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>
import axios from "axios";

export default {
    name: "Users",
    data() {
        return {
            fields: [
                { key: "username",label:"Usuário",sortable: true },
                "email",
                { key: "opcao", label: "Opções", class: "text-center" }
            ],
            items: [],
            infoModal: {
                id: "modal-usuarios",
                uuid: "",
                email: "",
                username: "",
                password: ""
            },
            modalOpcao: ""
        };
    },
    mounted: function () {
        this.listUsers();
    },
    methods: {
        listUsers(){
            axios.get(this.$apiHost + "user/list", {}, {headers: this.$apiHeader}).then(response => {
                if (response.data.success) {
                    this.items = response.data.users;
                } else {
                    setTimeout(() => {  this.listUsers(); }, 2000);
                }
            }).catch(error => {
                console.log(error);
                setTimeout(() => {  this.listUsers(); }, 2000);
            });
        },
        openEditModal(item, index, button) {
            this.modalOpcao = "edit";
            var rowContent = JSON.parse(JSON.stringify(item, null, 2));
            this.infoModal.uuid = rowContent.id;
            this.infoModal.email = rowContent.email;
            this.infoModal.username = rowContent.username;
            this.infoModal.password = rowContent.password;
            console.log(this.infoModal);
            this.$root.$emit("bv::show::modal", this.infoModal.id, button);
        },

        openDeleteModal(item, index, button) {
            var rowContent = JSON.parse(JSON.stringify(item, null, 2));
            var dataToSend = { userId: rowContent.id };
            axios.post(this.$apiHost + "user/delete", dataToSend, {headers: this.$apiHeader}).then(response => {
               alert(response.data.message);
               this.listUsers();
            }).catch(error => {
                console.log(error);
                alert("Erro inesperado. Verifique a conexão.");
            });
        },

        resetInfoModal() {
            this.infoModal.uuid = "";
            this.infoModal.email = "";
            this.infoModal.username = "";
            this.infoModal.password = "";
        },

        openCreateModal(button) {
            this.modalOpcao = "create";
            this.resetInfoModal();
            this.$root.$emit("bv::show::modal", this.infoModal.id, button);
        },

        submitForm(e) {
            e.preventDefault();
            console.log(this.infoModal);

            if (this.modalOpcao == "edit") {
                var dataToSend = {
                    id: this.infoModal.uuid,
                    username: this.infoModal.username,
                    email: this.infoModal.email,
                    password: this.infoModal.password
                };
                axios.post(this.$apiHost + "user/update", dataToSend, {headers: this.$apiHeader}).then(response => {
                    if (response.data.success) {
                        alert(response.data.message);
                        this.$bvModal.hide(this.infoModal.id);
                        this.listUsers();
                    } else {
                        alert("Erro: "+response.data.message);
                    }
                }).catch(error => {
                    console.log(error);
                    alert("Erro inesperado. Verifique a conexão.");
                });
            }else{
                var dataToSend = {
                    username: this.infoModal.username,
                    email: this.infoModal.email,
                    password: this.infoModal.password
                };
                axios.post(this.$apiHost + "user/create", dataToSend, {headers: this.$apiHeader}).then(response => {
                    if (response.data.success) {
                        alert(response.data.message);
                        this.$bvModal.hide(this.infoModal.id);
                        this.listUsers();
                    } else {
                        alert("Erro: "+response.data.message);
                    }
                }).catch(error => {
                    console.log(error);
                    alert("Erro inesperado. Verifique a conexão.");
                });
            }
        }
    }
};
</script>
