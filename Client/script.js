let currentLanguage =
    localStorage.getItem("language") || "en";


function setLanguage(language) {

    currentLanguage = language;

    localStorage.setItem(
        "language",
        language
    );


    if (language === "he") {

        document.documentElement.lang = "he";
        document.body.dir = "rtl";

    }

    else {

        document.documentElement.lang = "en";
        document.body.dir = "ltr";

    }


    translatePage();
}



function translatePage() {

    const isHebrew =
        currentLanguage === "he";


    /* Login page */

    const mainTitle =
        document.getElementById("mainTitle");

    if (mainTitle) {

        mainTitle.textContent =
            isHebrew
                ? "מנהל סיסמאות"
                : "Password Manager";


        document.getElementById("mainSubtitle").textContent =
            isHebrew
                ? "המידע שלך. תמיד מוגן."
                : "Your data. Always safe.";


        document.getElementById("usernameLabel").textContent =
            isHebrew
                ? "שם משתמש"
                : "Username";


        document.getElementById("username").placeholder =
            isHebrew
                ? "הכנס שם משתמש"
                : "Enter your username";


        document.getElementById("passwordLabel").textContent =
            isHebrew
                ? "סיסמה ראשית"
                : "Master Password";


        document.getElementById("password").placeholder =
            isHebrew
                ? "הכנס סיסמה ראשית"
                : "Enter your master password";


        document.getElementById("rememberText").textContent =
            isHebrew
                ? "זכור אותי"
                : "Remember me";


        document.getElementById("forgotPasswordLink").textContent =
            isHebrew
                ? "שכחת סיסמה?"
                : "Forgot password?";


        document.getElementById("loginButton").textContent =
            isHebrew
                ? "כניסה"
                : "Log In →";


        document.getElementById("orText").textContent =
            isHebrew
                ? "או"
                : "OR";


        document.getElementById("noAccountText").textContent =
            isHebrew
                ? "אין לך חשבון?"
                : "Don't have an account?";


        document.getElementById("signUpLink").textContent =
            isHebrew
                ? "הרשמה"
                : "Sign Up";


        document.getElementById("bottomInfo").textContent =
            isHebrew
                ? "מאובטח • פרטי • תמיד איתך"
                : "Secure • Private • Always with you";


        document.getElementById("pageText").textContent =
            isHebrew
                ? "האינטרנט הבטוח מתחיל בך"
                : "\"A safer internet starts with you\"";

    }



    /* Register page */

    const registerTitle =
        document.getElementById("registerTitle");

    if (registerTitle) {

        registerTitle.textContent =
            isHebrew
                ? "הרשמה"
                : "Sign Up";


        document.getElementById("registerSubtitle").textContent =
            isHebrew
                ? "צור את החשבון המאובטח שלך."
                : "Create your secure account.";


        document.getElementById("backToLoginLink").textContent =
            isHebrew
                ? "חזרה לכניסה"
                : "← Back to Log In";


        document.getElementById("registerUsernameLabel").textContent =
            isHebrew
                ? "שם משתמש"
                : "Username";


        document.getElementById("registerUsername").placeholder =
            isHebrew
                ? "בחר שם משתמש"
                : "Choose a username";


        document.getElementById("registerEmailLabel").textContent =
            isHebrew
                ? "אימייל"
                : "Email";


        document.getElementById("registerEmail").placeholder =
            isHebrew
                ? "הכנס כתובת אימייל"
                : "Enter your email";


        document.getElementById("registerPasswordLabel").textContent =
            isHebrew
                ? "סיסמה ראשית"
                : "Master Password";


        document.getElementById("registerPassword").placeholder =
            isHebrew
                ? "צור סיסמה ראשית"
                : "Create a master password";


        document.getElementById("confirmPasswordLabel").textContent =
            isHebrew
                ? "אימות סיסמה"
                : "Confirm Password";


        document.getElementById("confirmPassword").placeholder =
            isHebrew
                ? "הכנס שוב את הסיסמה"
                : "Repeat your master password";


        document.getElementById("registerButton").textContent =
            isHebrew
                ? "הרשמה"
                : "Sign Up";


        document.getElementById("orText").textContent =
            isHebrew
                ? "או"
                : "OR";


        document.getElementById("alreadyAccountText").textContent =
            isHebrew
                ? "כבר יש לך חשבון?"
                : "Already have an account?";


        document.getElementById("loginLink").textContent =
            isHebrew
                ? "כניסה"
                : "Log In";


        document.getElementById("bottomInfo").textContent =
            isHebrew
                ? "הצפנה חזקה • גישה מאובטחת"
                : "Strong encryption • Secure access";

    }



    /* Forgot password page */

    const resetTitle =
        document.getElementById("resetTitle");

    if (resetTitle) {

        resetTitle.textContent =
            isHebrew
                ? "איפוס סיסמה"
                : "Reset Your Password";


        document.getElementById("resetSubtitle").textContent =
            isHebrew
                ? "הכנס את כתובת האימייל שלך ונשלח אליך קוד שחזור."
                : "Enter your email and we'll send you a recovery code.";


        document.getElementById("backToLoginLink").textContent =
            isHebrew
                ? "חזרה לכניסה"
                : "← Back to Log In";


        document.getElementById("resetEmailLabel").textContent =
            isHebrew
                ? "אימייל"
                : "Email";


        document.getElementById("resetEmail").placeholder =
            isHebrew
                ? "הכנס כתובת אימייל"
                : "Enter your email";


        document.getElementById("resetButton").textContent =
            isHebrew
                ? "שלח קוד"
                : "Send Code";


        document.getElementById("recoveryInfo1").textContent =
            isHebrew
                ? "קוד שחזור יישלח לכתובת האימייל שמחוברת לחשבון שלך."
                : "Recovery code will be sent to the email connected to your account.";


        document.getElementById("recoveryInfo2").textContent =
            isHebrew
                ? "ייתכן שייקח עד 2 דקות עד שהקוד יגיע."
                : "The code may take up to 2 minutes to arrive.";


        document.getElementById("recoveryInfo3").textContent =
            isHebrew
                ? "אם ההודעה לא הגיעה, בדוק את תיקיית הספאם."
                : "If you don't see the email, check your spam folder.";


        document.getElementById("recoveryNote").textContent =
            isHebrew
                ? "מטעמי אבטחה, קודי שחזור תקפים לזמן מוגבל."
                : "For security reasons, recovery codes expire after a short time.";


        document.getElementById("bottomInfo").textContent =
            isHebrew
                ? "האבטחה שלך היא העדיפות שלנו."
                : "Your security is our priority.";

    }



    updatePasswordButtons();
}



const englishButton =
    document.getElementById("englishButton");


if (englishButton) {

    englishButton.addEventListener(
        "click",
        function () {

            setLanguage("en");

        }
    );

}



const hebrewButton =
    document.getElementById("hebrewButton");


if (hebrewButton) {

    hebrewButton.addEventListener(
        "click",
        function () {

            setLanguage("he");

        }
    );

}



function updatePasswordButtons() {

    const buttons =
        document.querySelectorAll(
            ".show-password"
        );


    buttons.forEach(function (button) {

        const passwordBox =
            button.parentElement;

        const input =
            passwordBox.querySelector("input");


        if (input.type === "password") {

            button.textContent =
                currentLanguage === "he"
                    ? "הצג"
                    : "Show";

        }

        else {

            button.textContent =
                currentLanguage === "he"
                    ? "הסתר"
                    : "Hide";

        }

    });

}



function connectPasswordButton(
    buttonId,
    inputId
) {

    const button =
        document.getElementById(buttonId);

    const input =
        document.getElementById(inputId);


    if (!button || !input) {
        return;
    }


    button.addEventListener(
        "click",
        function () {

            if (input.type === "password") {

                input.type = "text";

            }

            else {

                input.type = "password";

            }


            updatePasswordButtons();

        }
    );

}



connectPasswordButton(
    "showPasswordButton",
    "password"
);


connectPasswordButton(
    "showRegisterPasswordButton",
    "registerPassword"
);


connectPasswordButton(
    "showConfirmPasswordButton",
    "confirmPassword"
);



const loginButton =
    document.getElementById("loginButton");


if (loginButton) {

    loginButton.addEventListener(
        "click",
        function () {

            const username =
                document.getElementById("username").value;

            const password =
                document.getElementById("password").value;

            const message =
                document.getElementById("loginMessage");


            if (
                username === "" ||
                password === ""
            ) {

                message.textContent =
                    currentLanguage === "he"
                        ? "יש למלא את כל השדות"
                        : "Please fill in all fields";

                message.className =
                    "error-message";

            }

            else if (
                username === "admin" &&
                password === "1234"
            ) {

                message.textContent =
                    currentLanguage === "he"
                        ? "הכניסה הצליחה"
                        : "Login successful";

                message.className =
                    "success-message";

            }

            else {

                message.textContent =
                    currentLanguage === "he"
                        ? "שם המשתמש או הסיסמה שגויים"
                        : "Incorrect username or password";

                message.className =
                    "error-message";

            }

        }
    );

}



const registerButton =
    document.getElementById(
        "registerButton"
    );


if (registerButton) {

    registerButton.addEventListener(
        "click",
        function () {

            const username =
                document.getElementById(
                    "registerUsername"
                ).value;

            const email =
                document.getElementById(
                    "registerEmail"
                ).value;

            const password =
                document.getElementById(
                    "registerPassword"
                ).value;

            const confirmPassword =
                document.getElementById(
                    "confirmPassword"
                ).value;

            const message =
                document.getElementById(
                    "registerMessage"
                );


            if (
                username === "" ||
                email === "" ||
                password === "" ||
                confirmPassword === ""
            ) {

                message.textContent =
                    currentLanguage === "he"
                        ? "יש למלא את כל השדות"
                        : "Please fill in all fields";

                message.className =
                    "error-message";

            }

            else if (
                password !== confirmPassword
            ) {

                message.textContent =
                    currentLanguage === "he"
                        ? "הסיסמאות אינן תואמות"
                        : "Passwords do not match";

                message.className =
                    "error-message";

            }

            else {

                message.textContent =
                    currentLanguage === "he"
                        ? "החשבון נוצר בהצלחה"
                        : "Account created successfully";

                message.className =
                    "success-message";

            }

        }
    );

}



const resetButton =
    document.getElementById(
        "resetButton"
    );


if (resetButton) {

    resetButton.addEventListener(
        "click",
        function () {

            const email =
                document.getElementById(
                    "resetEmail"
                ).value;

            const message =
                document.getElementById(
                    "resetMessage"
                );


            if (email === "") {

                message.textContent =
                    currentLanguage === "he"
                        ? "יש להזין כתובת אימייל"
                        : "Please enter your email";

                message.className =
                    "error-message";

            }

            else {

                message.textContent =
                    currentLanguage === "he"
                        ? "קוד השחזור נשלח"
                        : "Recovery code sent";

                message.className =
                    "success-message";

            }

        }
    );

}



setLanguage(
    currentLanguage
);