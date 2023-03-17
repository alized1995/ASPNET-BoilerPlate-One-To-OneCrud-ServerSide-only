using OneToOneCrud.Debugging;

namespace OneToOneCrud
{
    public class OneToOneCrudConsts
    {
        public const string LocalizationSourceName = "OneToOneCrud";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "88d18259956c4e6593b879588e1a6ecc";
    }
}
