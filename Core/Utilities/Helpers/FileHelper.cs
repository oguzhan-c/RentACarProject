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
        static string sourcePath = Environment.CurrentDirectory + @"\wwwroot\Images";
        public static IDataResult<String> Add(IFormFile formFile)
        {
            var result = newFilePath(formFile);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (formFile.Length > 0)
                {
                    using (FileStream stream = new FileStream(sourcePath,FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    File.Move(sourcePath, result);
                    return new SuccessDataResult<string>(result, "File Added");
                }
                else
                {
                    return new ErrorDataResult<string>("File Can Not Added");
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<string>(exception.Message);
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

        public static IDataResult<string>Update(IFormFile formFile , String oldSourcePath)
        {
            try
            {
                if (File.Exists(oldSourcePath))
                {
                    FileHelper.Delete(oldSourcePath);

                    FileHelper.Add(formFile);

                    return new SuccessDataResult<String>(); 
                }
                else
                {
                    return new ErrorDataResult<String>("File Can Not Found");
                }
            }
            catch(Exception exception)
            {
                return new ErrorDataResult<String>(exception.Message);
            }
        }

        private static String newFilePath(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(sourcePath + formFile.FileName);
            var newGuidPath = Guid.NewGuid().ToString() + "_" +
                fileExtension + "_" +
                DateTime.Now.Day + "_" +
                DateTime.Now.Month + "_" +
                DateTime.Now.Year + "_";
            var result = $@"{sourcePath}\{newGuidPath}";
            return result;
        }
    }
}