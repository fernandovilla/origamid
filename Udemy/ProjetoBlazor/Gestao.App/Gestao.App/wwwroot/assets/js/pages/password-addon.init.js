Array.from(document.querySelectorAll("form .auth-pass-inputgroup")).forEach(function (e) {
    Array.from(e.querySelectorAll(".password-addon")).forEach(function (r) {
        r.addEventListener("click", function (r) {
            console.log("password...");
            var o = e.querySelector(".password-input");

            console.log("password...o: ", o);
            "password" === o.type ? o.type = "text" : o.type = "password"
        })
    })
});