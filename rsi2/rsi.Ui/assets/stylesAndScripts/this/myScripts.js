$('#small_navBar').on('show.bs.collapse', function () {
    $('#slogan').css('margin-top', '390px');
})

/*
    1) funções genéricas
    1.1) funções p/formulários
    1.1.1) funções anônimas - específicas de cada formulário
    1.1.2) funções nomeAdas - compartilhadas entre os formulários
*/


/*
     1.1) funções p/formulários
*/


/*
    ************************************************************************
*/

//  1.1.2) funções nomeAdas

/*  
    function: typeStatus()
    objective: de acordo com o valor no dropDownList com os tipos de mídias, esconde e exibe certos trechos do formulário     

    + theBegin: typeStatus() */
    function typeStatus() {
        var _dropdownlist_selected = $('#type_inModal option:selected').text();
        
        // se imagem...
        if (_dropdownlist_selected == "logo" || _dropdownlist_selected == "image" || _dropdownlist_selected == "mainImage" || _dropdownlist_selected == "thumbnail" || _dropdownlist_selected == "slider" || _dropdownlist_selected == "gallery" || _dropdownlist_selected == "icon") {
            $('#urlDiv').hide();
            $('#inputFile_inModal').show();
            $('.mediaFrame').hide();
            $('.mediaImage').show(); 
            $('.media_').hide();
        }
        
        // se vídeo...
        else if (_dropdownlist_selected == "youtube" || _dropdownlist_selected == "vimeo" || _dropdownlist_selected == "pdf" || _dropdownlist_selected == "html" || _dropdownlist_selected == "googleMaps" || _dropdownlist_selected == "url") {
            urlDisplay();
            $('#urlDiv').show();
            $('.mediaFrame').show();
            $('#inputFile_img').hide(); 
            $('.mediaImage').hide();
            $('#inputFile_inModal').hide();
            $('.media_').show();
        }
    }
//  - theEnd: typeStatus()

/*  
    function: readURL()
    objective: exibe a imagem que será importada durante o fileUpload

    + theBegin: readURL() */
    
//  - theEnd: readURL()

/*  
    function..: resetImagFileUpload()
    objective.: caso o botão de reset (de imagem) seja acionado, retorna a imagem original do registro
    parameters: __iconFileName - imagem com o path da imagem atualmente relacionada ao registro

    + theBegin: resetImagFileUpload() */
    function resetImagFileUpload(__iconFileName, idImage) {
        if (!idImage) {
            idImage = "imgActual";
        }
        
        var _img = __iconFileName.replace(/~/g, "../../..");
        console.log("imagem para reset:" + _img);
        $('#' + idImage).attr('src', _img);
        $('#logo').attr('src', _img);
        //document.getElementById("saveButton_inModal").disabled = true;
    }
//  - theEnd: resetImagFileUpload()

/*  
    function..: Mudarestado23823426a1()
    objective.: esconde e exibe uma div ou elemento de formulário
    parameters: el - (id, classe ou elemento) que será exibido ou escondido 

    + theBegin: Mudarestado23823426a1() */
    //function Mudarestado23823426a1(el) {
    //    var display = document.getElementById(el).style.display;
    //    if (display == "none")
    //        document.getElementById(el).style.display = 'block';
    //    else
    //        document.getElementById(el).style.display = 'none';
    //}
//  - theEnd: Mudarestado()

/*  
    function..: Mudarestado()
    objective.: esconde e exibe uma div ou elemento de formulário
    parameters: el - (id, classe ou elemento) que será exibido ou escondido 
    
    + theBegin: Mudarestado() */
    function Mudarestado(el) {
        var display = document.getElementById(el).style.display;
        if (display == "none")
        {
            //document.getElementById(el).style.display = 'block';
            $("#" + el).slideDown(2000);
        }
            
        else
           // document.getElementById(el).style.display = 'none';
            $("#" + el).slideUp(2000);
    }
//  - theEnd: Mudarestado23823426a1()



    function urlDisplay() {
        var _url = $("#url_inModal").val();
        $("#media_").attr("src", _url);
        $('.mediaFrame').show();
    }

    //abrir o modal de visulização do registro
    function advertiserView(_advertiserId){
        $("#modalAdvertiser").load("/backEnd/Advertisers/_modalAdvertiserView?id=" + _advertiserId, function () { /*Lê o modal e o insere na div do modal, perceba que o id da div do modal é invocada aqui, em load temos o controle/view responsáveis para pesquisar o id e invocar o modal */
            $("#modalAdvertiser").modal();
        })
    }

    //abrir o modal de exclusão do registro
    function deleteAdvertiserConfirmation(_advertiserId){
        $("#modalAdvertiser").load("/backEnd/Advertisers/_modalRegisterDeleteConfirmation?id=" + _advertiserId, function () { /*Lê o modal e o insere na div do modal, perceba que o id da div do modal é invocada aqui, em load temos o controle/view responsáveis para pesquisar o id e invocar o modal */
            $("#modalAdvertiser").modal();
        })
    }

    function enableTheEditFormButtons(_op) {

        $('#statusFormRadioButtons').show(); // exibir os radios bottons de mudança do status do registro

        document.getElementById("saveFormButton").disabled = false;
        document.getElementById("resetFormButton").disabled = false;
        document.getElementById("enabletheEditFormButton").disabled = true;
        if (_op == "e") {
            document.getElementById("deleteFormButton").disabled = false;
            document.getElementById("addFormButton").disabled = false;
        }
        else {
            document.getElementById("deleteFormButton").disabled = true;
            document.getElementById("addFormButton").disabled = true;
        }                        
    }

    function disableTheEditFormButtons(_op) {

        $('#statusFormRadioButtons').hide(); // esconder os radios bottons de mudança do status do registro

        document.getElementById("saveFormButton").disabled = true;
        document.getElementById("resetFormButton").disabled = true;
        document.getElementById("addFormButton").disabled = true;
        document.getElementById("enabletheEditFormButton").disabled = true;
        if (_op == "d") {            
            document.getElementById("deleteFormButton").disabled = false;
        }
        else   {
            document.getElementById("deleteFormButton").disabled = true;
        }
    }

    