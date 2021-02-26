using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {

            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                    file.CopyTo(stream);

            var result = newPath(file);

            File.Move(sourcepath, result);        

            return result;
        }

        public static string UpdateAsync(string sourcePath , IFormFile file)
        {
            var result = newPath(file);

            File.Copy(sourcePath,result);

            File.Delete(sourcePath);

            return result;
        }

        public static string newPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }

    }
}
