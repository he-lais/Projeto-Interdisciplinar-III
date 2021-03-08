<template>
  <div id="wrapper">
    <app-sidebar></app-sidebar>
    <div id="content-wrapper" class="d-flex flex-column">
      <div id="content">
        <app-navbar></app-navbar>
        <div class="container-fluid">
          <h1 class="h3 mb-4 text-gray-800">Listagem de documentos</h1>
          <b-button size="sm" @click="deletarTudo()" class="m-3 float-right" variant="danger">Limpar Histórico</b-button>
          <b-table striped bordered hover :items="items" :fields="fields">
            <template v-slot:cell(opcao)="row">
              <b-button size="sm" @click="openShowContentModal(row.item, $event.target)" class="mr-1" variant="primary">Ver conteúdo</b-button>
              <b-button size="sm" @click="deletar(row.item)" class="mr-1" variant="danger">Excluir</b-button>
            </template>
          </b-table>
        </div>

        <b-modal :id="infoModal.id" size="xl" @ok="clear($event)" title="Visualização do documento">
          <b-form-textarea id="textarea" v-model="infoModal.content" rows="20"></b-form-textarea>
        </b-modal>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Documentos",
  data() {
    return {
      fields: [
        { key: "documentTypeName", label: "Tipo do Documento", sortable: true },
        { key: "userName", label: "Criado por", sortable: true },
        { key: "opcao", label: "Opções", class: "text-center" }
      ],
      items: [],
      infoModal: {
        id: "modal-document",
        content: ""
      }
    };
  },
  methods: {
    listDocumentos() {
      axios
        .get(this.$apiHost + "document/list", {}, { headers: this.$apiHeader })
        .then(response => {
          if (response.data.success) {
            var json_formatado = [];
            this.items = response.data.documents;
          } else {
            setTimeout(() => {
              this.listDocumentos();
            }, 2000);
          }
        })
        .catch(error => {
          console.log(error);
          setTimeout(() => {
            this.listDocumentos();
          }, 2000);
        });
    },
    openShowContentModal(item,button) {
      var rowContent = JSON.parse(JSON.stringify(item, null, 2));
      var dataToSend = {"DocumentId" : rowContent.id};
      axios
        .post(this.$apiHost + "document/details", dataToSend, { headers: this.$apiHeader })
        .then(response => {
          if (response.data.success) {
            this.infoModal.content = response.data.document.content;
            this.$root.$emit("bv::show::modal", this.infoModal.id, button);
          } else {
            alert(response.data.message);
          }
        })
        .catch(error => {
            console.log(error);
            alert("Erro inesperado ao buscar documento. Tente novamente.");
        });
      
    },
    deletar(item) {
      var rowContent = JSON.parse(JSON.stringify(item, null, 2));
      var dataToSend = {"DocumentId" : rowContent.id};
      axios
        .post(this.$apiHost + "document/delete", dataToSend, { headers: this.$apiHeader })
        .then(response => {
          alert(response.data.message);
          this.listDocumentos();
        })
        .catch(error => {
            alert("Erro inesperado ao excluir. Tente novamente.");
        });
      
    },
    deletarTudo() {
      axios
        .post(this.$apiHost + "document/deleteAll", {}, { headers: this.$apiHeader })
        .then(response => {
          alert(response.data.message);
          this.listDocumentos();
        })
        .catch(error => {
            alert("Erro inesperado ao excluir. Tente novamente.");
        });
      
    },
    clear(e) {
      this.infoModal.content = "";
      this.$bvModal.hide(this.infoModal.id);
    }
  },

  mounted: function() {
    this.listDocumentos();
  }
};
</script>
