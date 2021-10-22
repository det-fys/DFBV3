using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DFBV3 {
    public static class Temp {
        public static string Cesta() {
            var a = Path.GetTempPath() + "\\DFBV3";

            try {
                Directory.CreateDirectory(a);
            } catch {
                return Path.GetTempPath();
            }

            return a;
        }

        public static void Vycistit() {
            File.Delete(Cesta() + "\\*setup.exe");
        }
    
    }
}
