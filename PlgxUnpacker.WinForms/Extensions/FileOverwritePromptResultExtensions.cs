namespace PlgxUnpacker.Extensions
{
    public static class FileOverwritePromptResultExtensions
    {
        public static bool IsNullOrUnknown(this FileOverwritePromptResult? result)
        {
            return result == null || result == FileOverwritePromptResult.Unknown;
        }

        public static bool IsYesOrNo(this FileOverwritePromptResult? result)
        {
            return result == FileOverwritePromptResult.Yes || result == FileOverwritePromptResult.No;
        }

        public static bool IsYesOrYesAll(this FileOverwritePromptResult? result)
        {
            return result == FileOverwritePromptResult.Yes || result == FileOverwritePromptResult.YesAll;
        }
    }
}
