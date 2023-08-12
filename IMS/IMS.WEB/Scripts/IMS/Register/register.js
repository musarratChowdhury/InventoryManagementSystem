$(document).ready(function () {
  let validator = $("#registrationForm").validate({
    invalidHandler: function (event, validator) {
      var errors = validator.numberOfInvalids();
      if (errors) {
        console.log(validator);
        console.log("number of errors : ", errors);
      }
    },
    rules: {
      Email: {
        required: true,
        email: true,
      },
      Password: {
        required: true,
        minlength: 6,
      },
      ConfirmPassword: {
        required: true,
        equalTo: "#password", // Ensure it matches the password field
      },
    },
    messages: {
      Email: {
        required: "Please enter your email address",
        email: "Please enter a valid email address",
      },
      Password: {
        required: "Please enter a password",
        minlength: "Password must be at least 6 characters long",
      },
      ConfirmPassword: {
        required: "Please confirm your password",
        equalTo: "Passwords do not match",
      },
    },
  });
  // Add validation rule for the password confirmation field
  $.validator.addMethod(
    "equalTo",
    function (value, element, param) {
      return value === $(param).val();
    },
    "Passwords do not match"
  );

  // Apply the password confirmation validation to the ConfirmPassword field

  //#region  ADDING RULES TO THE FIELDS
  $("#confirmPassword").rules("add", {
    equalTo: "#password",
    messages: {
      equalTo: "Passwords do not match",
    },
  });
  $("#password").rules("add", {
    required: true,
    minlength: 6,
    messages: {
      required: "Please enter a password",
    },
  });
  //#endregion
  $("#registrationForm").on("submit", function (e) {
    e.preventDefault();
    if (validator.form()) {
      let emailInput = $("#email").val();
      let passwordInput = $("#password").val();
      let confirmPasswordInput = $("#confirmPassword").val();

      let data = {
        Email: emailInput,
        Password: passwordInput,
        ConfirmPassword: confirmPasswordInput,
      };

      $.ajax({
        url: "/account/register", // Replace with your actual endpoint
        type: "POST",
        data: data,
        success: function (response) {
          if (response.success == true) {
            console.log("Registration successful", response);
            window.location.href = "/Home/Index";
          } else {
            console.log("Registration failed", response.errors);
          }
        },
        error: function (error) {
          console.error("Registration failed", error);
        },
      });
    } else {
      console.log("form not valid");
    }
  });
});
