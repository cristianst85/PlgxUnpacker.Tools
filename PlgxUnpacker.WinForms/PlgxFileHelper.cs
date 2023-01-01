using PlgxFile = PlgxUnpackerNet.PlgxFile;

namespace PlgxUnpacker
{
    public static class PlgxFileHelper
    {
        public static bool IsPlgxFileExtension(string fileExtension)
        {
            return PlgxFile.Extension.Equals(fileExtension, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
