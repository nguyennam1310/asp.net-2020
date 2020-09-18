$(document).ready(function () {
    
});
$("#message1").hide();
$("#message2").hide();
$("#msg").hide();
function Register() {

        var empObj = {
            FullName: $('#FullName').val(),
            Gender: $('#Gender').val(),
            DateOfBirth: $('#DateOfBirth').val(),
            UserName: $('#UserName1').val(),
            Email: $('#Email').val(),
            Phone: $('#Phone').val(),
            Password: $('#Password1').val(),
            PasswordNew: $('#RePassword').val(),
            
        };
    $.ajax({
            async: true,
            contentType: 'application/json',
            url: "/Home/Register",
            data: JSON.stringify(empObj),
            type: "POST",
            dataType: "json",
            success: function (result) {

               
                    $("#message1").show();
                $("#message2").hide();
                $('#UserName').val(result.UserName);
                $('#Password').val(result.Password);
               
            },
            error: function () {
                
            }
        });
   
}

function Login() {

    var empObj = {
        
        UserName: $('#UserName').val(),
    
        Password: $('#Password').val()

    };
    $.ajax({
        async: true,
        contentType: 'application/json',
        url: "/Home/Verify",
        data: JSON.stringify(empObj),
        type: "POST",
        dataType: "json",
        success: function (result) {
            if (result.status === true) {
                window.location.href = "/Home/Index";
                $("#msg").hide();
            }
            if (result.status === false) {
                
                $("#msg").show();
            }
  
        

    },
        error: function () {

        }
        });
   
}