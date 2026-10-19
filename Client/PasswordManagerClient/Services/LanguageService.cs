namespace PasswordManagerClient.Services;

public class LanguageService
{
    public string CurrentLanguage { get; private set; } = "EN";


    private Dictionary<string, Dictionary<string, string>> translations =
        new Dictionary<string, Dictionary<string, string>>
    {
        {
            "EN",
            new Dictionary<string, string>
            {
                { "mainTitle", "Your digital security starts here." },
                { "mainDescription", "Keep your passwords protected and manage your accounts from one secure place." },

                { "welcome", "Welcome back" },
                { "loginDescription", "Log in to access your secure vault." },

                { "username", "Username" },
                { "usernamePlaceholder", "Enter your username" },

                { "masterPassword", "Master Password" },
                { "passwordPlaceholder", "Enter your master password" },

                { "show", "Show" },
                { "hide", "Hide" },

                { "rememberMe", "Remember me" },
                { "forgotPassword", "Forgot password?" },

                { "loginButton", "Log In" },

                { "emptyFields", "Please fill in all fields" },
                { "loginSuccess", "Login successful" },

                { "noAccount", "Don't have an account?" },
                { "signUp", "Sign Up" },

                { "settings", "Settings" },
                { "language", "Language" },
                { "appearance", "Appearance" },
                { "darkMode", "Dark mode" },
                { "about", "About" },
                { "version", "Version" },
                { "aboutText", "Secure password management in one place." },

                { "registerTitle", "Create your account" },
                { "registerDescription", "Create an account to start protecting your passwords." },

                { "email", "Email" },
                { "emailPlaceholder", "Enter your email" },

                { "confirmPassword", "Confirm Master Password" },
                { "confirmPasswordPlaceholder", "Enter your master password again" },

                { "createAccount", "Create Account" },

                { "alreadyHaveAccount", "Already have an account?" },
                { "logIn", "Log In" },
                { "invalidLogin", "Incorrect username or password" },
                { "userAlreadyExists", "Username or email already exists" },

                { "passwordsNotMatch", "Passwords do not match" },
                { "accountCreated", "Account created successfully" },

                { "forgotTitle", "Recover your account" },
                { "forgotDescription", "Enter your email address to receive a password recovery link." },
                { "recoveryButton", "Send Recovery Email" },
                { "backToLogin", "Back to Login" },
                { "recoverySent", "Recovery email sent successfully" }
            }
        },

        {
            "HE",
            new Dictionary<string, string>
            {
                { "mainTitle", "האבטחה הדיגיטלית שלך מתחילה כאן." },
                { "mainDescription", "שמור על הסיסמאות שלך מוגנות ונהל את החשבונות שלך במקום מאובטח אחד." },

                { "welcome", "ברוך שובך" },
                { "loginDescription", "התחבר כדי לגשת לכספת המאובטחת שלך." },

                { "username", "שם משתמש" },
                { "usernamePlaceholder", "הכנס שם משתמש" },

                { "masterPassword", "סיסמה ראשית" },
                { "passwordPlaceholder", "הכנס סיסמה ראשית" },

                { "show", "הצג" },
                { "hide", "הסתר" },

                { "rememberMe", "זכור אותי" },
                { "forgotPassword", "שכחת סיסמה?" },

                { "loginButton", "התחבר" },

                { "emptyFields", "נא למלא את כל השדות" },
                { "loginSuccess", "ההתחברות בוצעה בהצלחה" },

                { "noAccount", "אין לך חשבון?" },
                { "signUp", "הרשמה" },

                { "settings", "הגדרות" },
                { "language", "שפה" },
                { "appearance", "תצוגה" },
                { "darkMode", "מצב כהה" },
                { "about", "אודות" },
                { "version", "גרסה" },
                { "aboutText", "ניהול מאובטח של הסיסמאות שלך במקום אחד." },

                { "registerTitle", "צור את החשבון שלך" },
                { "registerDescription", "צור חשבון כדי להתחיל להגן על הסיסמאות שלך." },

                { "email", "אימייל" },
                { "emailPlaceholder", "הכנס כתובת אימייל" },

                { "confirmPassword", "אימות סיסמה ראשית" },
                { "confirmPasswordPlaceholder", "הכנס שוב את הסיסמה הראשית" },

                { "createAccount", "צור חשבון" },

                { "alreadyHaveAccount", "כבר יש לך חשבון?" },
                { "logIn", "התחבר" },
                { "invalidLogin", "שם המשתמש או הסיסמה שגויים" },
                { "userAlreadyExists", "שם המשתמש או כתובת האימייל כבר קיימים" },

                { "passwordsNotMatch", "הסיסמאות אינן תואמות" },
                { "accountCreated", "החשבון נוצר בהצלחה" },

                { "forgotTitle", "שחזור החשבון שלך" },
                { "forgotDescription", "הכנס את כתובת האימייל שלך כדי לקבל קישור לשחזור הסיסמה." },
                { "recoveryButton", "שלח אימייל לשחזור" },
                { "backToLogin", "חזרה להתחברות" },
                { "recoverySent", "אימייל השחזור נשלח בהצלחה" }
            }
        }
    };


    public string GetText(string key)
    {
        return translations[CurrentLanguage][key];
    }


    public void ChangeLanguage(string language)
    {
        CurrentLanguage = language;
    }
}