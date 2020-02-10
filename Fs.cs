using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Testing
{
    public static class Fs
    {
        public static string Open(string fname)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var file = "";
            using (Stream stream = assembly.GetManifestResourceStream(fname))
            using (StreamReader reader = new StreamReader(stream)) {
                file = reader.ReadToEnd();
            }
            return file;
        }
    }
}
