using System.Diagnostics.CodeAnalysis;

namespace MultiShop.Extensions
{
    public static class ImgExtensions
    {
        public static bool IsValidType(this IFormFile file,string type) 
        { return file.ContentType.Contains(type); }

        public static bool IsValidLenght(this IFormFile file,int lenght)
        {  return file.ContentType.Length<=lenght*1024;}

        public static async Task<string> SaveImg(this IFormFile file,string path)
        {
            string ext =Path.GetExtension(file.FileName);
            string newFileName=Path.GetRandomFileName();
            await using FileStream fs = new FileStream(Path.Combine(path, newFileName + ext), FileMode.Create);
            await file.CopyToAsync(fs);
            return newFileName + ext;
        }


    }
}
