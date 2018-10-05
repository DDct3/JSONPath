using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForGlobalLogic
{
    class JSONInfoFile
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string FullPath { get; set; }

        public JSONInfoFile(FileSystemInfo fsi)
        {
            Name = fsi.Name;
            Size = ((fsi as FileInfo).Length).ToString() + " B";
            FullPath = (fsi as FileInfo).FullName;
        }

        public string JsonToTree()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
