using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForGlobalLogic
{
    class JSOInfoFolder
    {
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public List<JSONInfoFile> Files { get; set; }
        public List<JSOInfoFolder> Children { get; set; }

        public JSOInfoFolder(FileSystemInfo fsi)
        {
            Name = fsi.Name;
            DateCreated = fsi.CreationTime.ToShortDateString();
            Children = new List<JSOInfoFolder>();
            Files = new List<JSONInfoFile>();
            ChildrenInfo(fsi);
        }

        private List<JSOInfoFolder> ChildrenInfo(FileSystemInfo fsi)
        {
            foreach (FileSystemInfo f in (fsi as DirectoryInfo).GetFileSystemInfos())
            {
                FileAttributes attr = File.GetAttributes(f.FullName);
                Console.WriteLine(attr);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Children.Add(new JSOInfoFolder(f));
                }
                else
                {
                    Files.Add(new JSONInfoFile(f));
                }
            }
            return Children;
        }

        public string JsonToTree()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
