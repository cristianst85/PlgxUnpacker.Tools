namespace PlgxUnpacker.Extensions
{
    public static class FileReplacePromptResultExtensions
    {
        public static bool IsNullOrUnknown(this FileReplacePromptResult? result)
        {
            return result == null || result == FileReplacePromptResult.Unknown;
        }

        public static bool IsYesOrNo(this FileReplacePromptResult? result)
        {
            return result == FileReplacePromptResult.Yes || result == FileReplacePromptResult.No;
        }

        public static bool IsYesOrYesAll(this FileReplacePromptResult? result)
        {
            return result == FileReplacePromptResult.Yes || result == FileReplacePromptResult.YesAll;
        }
    }
}
