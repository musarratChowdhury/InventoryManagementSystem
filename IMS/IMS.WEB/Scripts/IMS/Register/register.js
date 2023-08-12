$(document).ready(function () {
  $("#registrationForm").validate({
    rules: {
      Email: {
        required: true,
        email: true,
      },
      Password: {
        required: true,
        minlength: 6,
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
    },
  });
  $("#registrationForm").on("submit", function (e) {
    e.preventDefault();
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
          window.location.href = "/account/login";
        } else {
          console.log("Registration failed", response.errors);
        }
      },
      error: function (error) {
        console.error("Registration failed", error);
      },
    });
  });
});
