//Idealmente deveria utilizar um token de autenticação para validar o usuário
//A ideia aqui é usar um algoritmo super simples para validar o usuário
function ValidarUsuario() {
    var usuario = document.getElementById("txtUsuario").value;
    var senha = document.getElementById("txtSenha").value;

    var resultado = usuario == senha;

    if (resultado == true) {
        document.cookie = usuario;
        window.location.replace("dashboard.html");
    }
    else {
        document.cookie = "";
        alert("Usuário ou senha inválidos");
    }
}

function UsuarioLogado() {
    var usuario = document.cookie;
    if (usuario == "") {
        window.location.replace("index.html");
    }
}

// Para apresentar alguns dados relevantes no dashboard
function ObterAlertas() {
    var alertas = [
        "<p>O produto X está com estoque baixo</p>",
        "<p>O preço do produto Y aumentou no fornecedor</p>",
        "<p>O pedido do cliente Z ainda não foi expedido</p>"
    ];

    document.getElementById("spanAlerta01").innerHTML = alertas[0];
    document.getElementById("spanAlerta02").innerHTML = alertas[1];
    document.getElementById("spanAlerta03").innerHTML = alertas[2];
}


function ObterEstatisticas() {
    var est01 = {
        Quantidade: 10,
        Label: "Pedidos",
        Icone: "pedidos.jpg",
        Link: "pedidos.html",
        Cor: "#007bff"
    };

    var est02 = {
        Quantidade: 8,
        Label: "Clientes Novos",
        Icone: "clientes.jpg",
        Link: "clientes.html",
        Cor: "green"
    };
    var est03 = {
        Quantidade: 100,
        Label: "Estoque",
        Icone: "estoques.jpg",
        Link: "estoques.html",
        Cor: "orange"
    };
    var est04 = {
        Quantidade: 10,
        Label: "Produtos Novos",
        Icone: "produtos.jpg",
        Link: "produtos.html",
        Cor: "yellow"
    };

    var estatisticas = [
        est01, est02, est03, est04
    ];

    FormatarEstatisticas("estatistica01", estatisticas[0]);
    FormatarEstatisticas("estatistica02", estatisticas[1]);
    FormatarEstatisticas("estatistica03", estatisticas[2]);
    FormatarEstatisticas("estatistica04", estatisticas[3]);
}


function FormatarEstatisticas(elemento, dados) {
    var elemento = document.getElementById(elemento);
    if (elemento == null) {
        return;
    };

    elemento.innerHTML = "<table style='background-color:" + dados.Cor + "'><tr><td>" + dados.Label
        + "</td><td>" + dados.Icone
        + "</td></tr><tr><td>Quantidade</td><td>" + dados.Quantidade + "</td></tr>"
        + "<tr><td colspan='2'> <a href='" + dados.Link + "'>Maiores Informações</a> </td></tr></table>";
}


function ObterClientes() {
    var clientes = [];

    for (var i = 0; i < Math.random() * 10000; i++) {
        var cliente = {
            id: i,
            nome: "Cliente 0" + i,
            endereco: "Rua 0" + i,
            dataNascimento: "01/01/2001",
            email: "cliente" + i + "@email.com",
            cidade: "Cidade 0" + i,
            nif: Math.floor(Math.random() * 1000000)
        };

        clientes[i] = cliente;
    }


    return clientes;
    //formatarClientes(clientes);

}

var FormatarClientes = function (clientes) {
    var elemento = document.getElementById("tblClientes");
    var cabecalho = "<tbody><tr><th>Id</th><th>Nome</th><th>Endereço</th><th>Data de Nascimento</th><th>Email</th><th>Cidade</th><th>NIF</th></tr>";
    var corpo = "";

    for (var i = 0; i < clientes.length; i++) {
        corpo += "<tr><td>" + clientes[i].id + "</td>" +
            "<td>" + clientes[i].nome + "</td>" +
            "<td>" + clientes[i].endereco + "</td>" +
            "<td>" + clientes[i].dataNascimento + "</td>" +
            "<td>" + clientes[i].email + "</td>" +
            "<td>" + clientes[i].cidade + "</td>" +
            "<td>" + clientes[i].nif + "</td></tr>";
    }

    var rodape = "</tbody>";

    elemento.innerHTML = cabecalho + corpo + rodape;
}

function ObterEstatisticasBootstrap() {
    $("#estPedidos").html(Math.floor(Math.random() * 100));
    $("#estClientes").html(Math.floor(Math.random() * 100));
    $("#estEstoques").html(Math.floor(Math.random() * 100));
    $("#estProdutos").html(Math.floor(Math.random() * 100));
}

function ObterGraficoVendas() {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    var maximoVendas = 10000;
    var maximoClientes = 5000;

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Dia', 'Vendas', 'Clientes'],
            ['Seg', Math.floor(Math.random() * maximoVendas), Math.floor(Math.random() * maximoClientes)],
            ['Ter', Math.floor(Math.random() * maximoVendas), Math.floor(Math.random() * maximoClientes)],
            ['Qua', Math.floor(Math.random() * maximoVendas), Math.floor(Math.random() * maximoClientes)],
            ['Qui', Math.floor(Math.random() * maximoVendas), Math.floor(Math.random() * maximoClientes)],
            ['Sex', Math.floor(Math.random() * maximoVendas), Math.floor(Math.random() * maximoClientes)],
        ]);

        var options = {
            title: 'Vendas',
            subtitle: 'Vendas da semana',
            hAxis: { title: 'Dia', titleTextStyle: { color: '#333' } },
            vAxis: { minValue: 0 }
        };

        var chart = new google.visualization.AreaChart(document.getElementById('graficoVendas'));
        chart.draw(data, options);
    }
}

function ObterGraficoNovosClientes() {
    var clientesNovos = 10000;
    var clientesRecorrentes = 2000;

    google.charts.load('current', { 'packages': ['bar'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Dia', 'Novos', 'Recorrentes'],
            ['Seg', Math.floor(Math.random() * clientesNovos), Math.floor(Math.random() * clientesRecorrentes)],
            ['Ter', Math.floor(Math.random() * clientesNovos), Math.floor(Math.random() * clientesRecorrentes)],
            ['Qua', Math.floor(Math.random() * clientesNovos), Math.floor(Math.random() * clientesRecorrentes)],
            ['Qui', Math.floor(Math.random() * clientesNovos), Math.floor(Math.random() * clientesRecorrentes)],
            ['Sex', Math.floor(Math.random() * clientesNovos), Math.floor(Math.random() * clientesRecorrentes)],
        ]);

        var options = {
            chart: {
                title: 'Clientes da Semana',
                subtitle: 'Novos X Recorrentes',
            },
            bars: 'vertical'
        };

        var chart = new google.charts.Bar(document.getElementById('graficoNovosClientes'));

        chart.draw(data, google.charts.Bar.convertOptions(options));
    }
}

function ObterListagemClientesDatatable() {
    var data = ObterClientes();

    $('#tblClientes').DataTable({
        data: data,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.5/i18n/pt-BR.json',
        },
        pageLength: 10,
        columns: [
            { data: 'id' },
            { data: 'nome' },
            { data: 'endereco' },
            { data: 'dataNascimento' },
            { data: 'email' },
            { data: 'cidade' },
            { data: 'nif' }
        ]
    });
}
