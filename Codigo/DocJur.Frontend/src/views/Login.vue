<template>
    <div id="wrapper" class="app-padding">
        <div id="content-wrapper" class="d-flex flex-column">
            <div id="content">
                <div class="container-fluid">
                    <div class="d-flex justify-content-center h-100">
                        <div class="card" style="height: auto;">
                            <div class="card-header">
                                <h3>Bem vindo ao DocJur</h3>
                            </div>
                            <div class="card-body">
                                <b-form @submit="login" v-if="show">
                                    <div class="input-group form-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-user"></i>
                                            </span>
                                        </div>
                                        <input type="text" v-model="form.username" class="form-control" placeholder="username" required/>
                                    </div>
                                    <div class="input-group form-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-key"></i>
                                            </span>
                                        </div>
                                        <input type="password" v-model="form.password" class="form-control" placeholder="password" required/>
                                    </div>
                                    <div class="form-group">
                                        <input type="submit" value="Login" class="float-right login_btn" />
                                    </div>
                                </b-form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import axios from 'axios';

export default {
    name: "Login",
    data() {
        return {
            form: {
                username: '',
                password: '',
            },
            show: true,
            returnUrl: '/',
        }
    },
    mounted: function () {
        var app = document.getElementById("app");
        //app.classList.add("app-padding");
        var body =    document.body;
        //body.classList.add("body-login");
    },
    methods: {
        getCryptPassword(){
            //bcrypt.hash(this.form.password, 10, (err, hash) => {
            //    return hash;
            //})
            return this.form.password;
        },
        login(evento) {
            evento.preventDefault();

            var dataToSend = {username: this.form.username, password: this.getCryptPassword() }

            axios.post(this.$apiHost+'user/login', dataToSend, {headers: this.$apiHeader}).then((response) => {
                if(response.data.success){
                    alert("Autenticado com sucesso.");
                    this.$session.start();
                    this.$session.set('jwt', response.data.token);
                    this.$session.set('username', response.data.name);
                    this.$session.set('userid', response.data.id);
                    this.$router.push(this.returnUrl);
                }
                else{
                    alert("Autenticação falhou.");
                }
            }).catch((error) => { 
                console.log(error);
            });
        }
    }
};
</script>

<style>
.body-login {
    background-image: url("../assets/login_image.jpeg");
    background-size: cover;
    background-repeat: no-repeat;
    height: 100%;
    font-family: "Numans", sans-serif;
}

.container {
    height: 100%;
    align-content: center;
}

.app-padding{
    padding-top: 60px;
}

.card {
    height: 370px;
    margin-top: auto;
    margin-bottom: auto;
    width: 400px;
    background-color: rgba(0, 0, 0, 0.5) !important;
}

.social_icon span {
    font-size: 60px;
    margin-left: 10px;
    color: #ffc312;
}

.social_icon span:hover {
    color: white;
    cursor: pointer;
}

.card-header h3 {
    color: white;
}

.social_icon {
    position: absolute;
    right: 20px;
    top: -45px;
}

input:focus {
    outline: 0 0 0 0 !important;
    box-shadow: 0 0 0 0 !important;
}

.remember {
    color: white;
}

.remember input {
    width: 20px;
    height: 20px;
    margin-left: 15px;
    margin-right: 5px;
}

.login_btn {
    color: #ffc312;
    background-color: transparent;
    width: 100px;
}

.login_btn:hover {
    color: #ffc312;
    background-color: white;
}

.links {
    color: white;
}

.links a {
    margin-left: 4px;
}

</style>
