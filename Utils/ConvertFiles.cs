using Spire.Doc;
using System.IO;

namespace Constancias.Utils {
    internal class ConvertFiles {
        public byte[] WordToPdf (byte[] wordBytes) {
            using (MemoryStream inputStream = new MemoryStream (wordBytes)) {
                Document document = new Document ();
                document.LoadFromStream (inputStream, FileFormat.Docx);

                using (MemoryStream outputStream = new MemoryStream ()) {
                    document.SaveToStream (outputStream, FileFormat.PDF);
                    return outputStream.ToArray ();
                }
            }
        }
    }
}
