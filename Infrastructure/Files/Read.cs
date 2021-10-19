using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PRFTLatam.Workshop.Infrastructure.Files
{
    public class Read
    {
        public static List<string> ReadFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<string> itemsInFile = new List<string>();
                while (!reader.EndOfStream)
                {
                    var allIDs = reader.ReadLine().Split('<');

                    itemsInFile = allIDs[0].Split(',').Select(id => id.Trim()).ToList();
                }

                return itemsInFile;
            }
        }
    }
}
