$("document").ready(function () {

    datePicker();
    loginValidate();
    regValidate();
});
function datePicker() {
    $("#DOBTextBox").datepicker({ dateFormat: 'mm-dd-yy' });
}

function loginValidate() {
 
    $("#loginForm").submit(function () {
        $(".usernameValidate").val("Username can't be blank");
        $(".usernameValidate").css("display", "none");
        $(".passwordValidate").css("display", "none");

        var sumbitForm = 1;
        var username = $("#usernameTextBox").val();
        var password = $("#passwordTextBox").val();
        if (!username) {
            $(".usernameValidate").css("display", "block");    
            sumbitForm = 2;
        }
        if (!password) {
            $(".passwordValidate").css("display", "block");
            sumbitForm = 2;
        }
        if (sumbitForm === 2) {
            return false;
        }
    });

}

function regValidate() {
    
    $("#regForm").submit(function () {
        
        $(".usernameValidateReg").val("Username can't be blank");
        $(".emailValidate").val("Email can't be blank");
        $(".nameValidate").css("display", "none");
        $(".emailValidate").css("display", "none");
        $(".usernameValidateReg").css("display", "none");
        $(".passwordValidateReg").css("display", "none");
        $(".confirmPasswordValidate").css("display", "none");
        $(".DOBValidate").css("display", "none");
        $(".genderValidate").css("display", "none");
        
        var sumbitForm = 1;

        var name= $("#nameTextBox").val();
        var email = $("#emailTextBox").val();
        var usernameReg = $("#usernameTextBox").val();
        var passwordReg = $("#passwordTextBox").val();
        var conPassord = $("#confirmPasswordTextbox").val();
        var DOB = $("#DOBTextBox").val();
        
        if (!name) {
            $(".nameValidate").css("display", "block");
            sumbitForm = 2;
        }
        if (!email) {
            $(".emailValidate").css("display", "block");
            sumbitForm = 2;
        }
        if (!usernameReg) {
            $(".usernameValidateReg").css("display", "block");
            sumbitForm = 2;
        }
        if (!passwordReg) {
            $(".passwordValidateReg").css("display", "block");
            sumbitForm = 2;
        }
        if (conPassord !== passwordReg) {
            $(".confirmPasswordValidate").css("display", "block");
            sumbitForm = 2;
        }
        if (!DOB) {
            $(".DOBValidate").css("display", "block");
            sumbitForm = 2;
        }
        if ($("#genderDropdownList option:selected").val() == 0) {
            $(".genderValidate").css("display", "block");
            sumbitForm = 2;
        }
        
        if (sumbitForm === 2) {
            return false;
        }

    });

}