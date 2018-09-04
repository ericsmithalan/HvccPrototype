namespace HVCC
{
    internal class Settings
    {
        public static bool IsSignedIn = true;
        public static bool IsAccountAvailable = true;
        public static bool IsUploadCompleteError = false;
        public static bool IsStaticPresentation = true;
        public static bool IsTriggerErrorOnUpload = false;
        public static bool IsPermision = true;
        public static bool IsAutoDetectOn = false;
        public static bool IsGhostApp = false;

        public static void ResetSettings()
        {
            IsSignedIn = true;
            IsAccountAvailable = true;
            IsStaticPresentation = true;
            IsTriggerErrorOnUpload = false;
            IsPermision = true;
            IsAutoDetectOn = false;
            IsUploadCompleteError = false;
        }
    }
}