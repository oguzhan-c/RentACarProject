using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        static string sourcePath = Environment.CurrentDirectory + @"\wwwroot\Uploads";
        public static String Add(IFormFile formFile)
        {
            var result = newFilePath(formFile);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (formFile.Length > 0)
                {
                    using (FileStream stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    File.Move(sourcePath, result);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static IResult Delete(String sourcePath)
        {
            try
            {
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(IFormFile formFile, String oldSourcePath)
        {
            try
            {
                var result = newFilePath(formFile);
                if (oldSourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result,FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                File.Delete(oldSourcePath);
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private static String newFilePath(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(sourcePath + formFile.FileName);
            var newGuidPath = Guid.NewGuid().ToString() + "_" +
                              DateTime.Now.Day + "_" +
                              DateTime.Now.Month + "_" +
                              DateTime.Now.Year + "_" +
                              fileExtension;
            var result = $@"{sourcePath}\{newGuidPath}";
            return result;
        }
    }
}