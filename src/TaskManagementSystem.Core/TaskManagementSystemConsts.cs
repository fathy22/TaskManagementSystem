using TaskManagementSystem.Debugging;

namespace TaskManagementSystem
{
    public class TaskManagementSystemConsts
    {
        public const string LocalizationSourceName = "TaskManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "cbf81d756a5c4f728df282764aa2c521";
    }
}
