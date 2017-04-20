

/*=============================================================================================
        *** function: MostrarForm() ***

        parametros..: __divToDisplay (id da div para esconder)
                      __divToHide (id da div para esconder)
                    
        finalidade..: exibir uma div e em seguida fechar outra div (por exemplo, abrir a div de formulário para alterar um registro e esconder a div de view / consulta
        obs.........: essa função precisa da função EsconderForm()
=============================================================================================*/
function MostrarForm(__divToDisplay, __divToHide) {
    event.preventDefault();

    if (__divToHide != null) {
        $("#" + __divToHide).slideUp(2000);
    }

    $("#" + __divToDisplay).slideDown(2000);
    // document.getElementById("adressesMaintenanceForm").style.display = 'block';
    //$("#DisplayOrder_address").focus();
}


/*=============================================================================================
        *** function: EsconderForm() ***

        parametros..: __divToHide (id da div para esconder)
                                          
        finalidade..: esconder uma div
        obs.........: essa função complementa a função MostrarForm()
=============================================================================================*/
function EsconderForm(__divToHide) {
    event.preventDefault();
    $("#" + __divToHide).slideUp(2000);
}


/*=============================================================================================
        *** function: Show_Hide() ***

        parametros..: __divToHide (id da div para exibir ou esconder)
                                          
        finalidade..: exibir ou esconder uma div, se a div já está aberta, fecha. se a div está fechada, abre
        obs.........: essa função complementa a função MostrarForm()
=============================================================================================*/
function Show_Hide(el) {
    var display = document.getElementById(el).style.display;
    if (display == "none") {
        //document.getElementById(el).style.display = 'block';
        $("#" + el).slideDown(1000);
    }

    else
        // document.getElementById(el).style.display = 'none';
        $("#" + el).slideUp(1000);
}

function resetFormxxx(__formId, __saveButtonToDisable) {

    console.log("******** resetForm ddddddd********");
    console.log("__formId: " + __formId);
    console.log("__saveButtonToDisable: " + __saveButtonToDisable);
   

    console.log("desabilitar o botão save: " + __saveButtonToDisable);
    document.getElementById("__saveButtonToDisable").disabled = true;

    document.getElementById(__formId).reset();
}

/*=============================================================================================
        *** forms ***
=============================================================================================*/