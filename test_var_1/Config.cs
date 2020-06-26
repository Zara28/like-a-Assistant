using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_var_1
{
    class Config
    {
        public static List<string> cat = new List<string>(){"Pic= jpeg, jpg, png, bmp, tif",
            "Music= mp3, wav",
            "Doc= docx, doc, txt, pdf, xls, xlsx",
            "book/arch= zip, rar",
            "Video= mp4, avi",
            "Web= html, php",
            "Python code= py",
            "Code= cpp",
            "Presentation= pptx"};
        public static List<string> command = new List<string>() { "Sort", "Show directory", "Change directory",
            "Add directory"};
    }
}
