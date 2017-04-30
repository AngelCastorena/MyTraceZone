$(document).ready(function(){

    $(window).scroll(function(){

      if ($(this).scrollTop() > 0){
          $('.main_cabecera').addClass('header2');
      }else{
        $('.main_cabecera').removeClass('header2');

      }


    }); //End scroll



});
