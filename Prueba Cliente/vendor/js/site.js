const url_Api="http://localhost:13896/"

const PintarTabla = () => {
    let numid = parseInt($("#numId").val());
    $.ajax({
        type: "GET",
        url: url_Api+"api/Contrato/"+numid,
        data:{},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {   
              if(data!=null){
                pintartabla(data)
              }
                   
        },
        error: function (jqXHR) {
            if (jqXHR.status == 401) {
               
            }           
        }
    });  
}

const parseToken = (token) => {
    let base64Url = token.split('.')[1];
    let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

const pintartabla = (data) => {
    data.forEach((item, i) => {
        $("#tablaUser").empty();
        $("#tablaUser").append(
            `
            <tr>
            <td>${item.tipodocuemnto}</td>
            <td>${item.numerodocumento}</td>
            <td>${item.primerapellido} ${item.segundoapellido}</td>
            <td>${item.primernombre} ${item.segundonombre}</td>
            <td>${item.cargo}</td>
            <td>${item.riegolaboral}</td>
            <td>${item.fechainicio}</td>
            <td>${item.fechafin}</td>
            <td>${item.salario}</td>
            <td><button type="button" class="btn btn-primary btn-sm" onclick="calcularSeguridad(${item.numerodocumento})">calcular</button> </td>
            <td><button type="button" class="btn btn-primary btn-sm">calcular</button> </td>
            `       
            );
    });            
}
const calcularSeguridad = (id) => {
    $.ajax({
        type: "GET",
        url: url_Api+"api/Contrato/Aportes/"+id,
        data:{},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {   
              if(data!=null){
                  $("#modal-SeguridadSocial").modal("show")
                debugger
              }
                   
        },
        error: function (jqXHR) {
            if (jqXHR.status == 401) {
               
            }           
        }
    });  
};