using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionApp.FileTransfer
{
    public class FileMetadata
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string Hash { get; set; }
        public string EncryptionAlgorithm { get; set; }
        public string Key1 { get; set; }
        public string PKey1 { get; set; }
        public string IV1 { get; set; }
        public string Key2 { get; set; }
        public string PKey2 { get; set; }
        public string IV2 { get; set; }
    }
}
