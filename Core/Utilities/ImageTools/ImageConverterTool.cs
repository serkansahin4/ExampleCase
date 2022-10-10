﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ImageTools
{
    public static class ImageConverterTool
    {
        public async static Task<byte[]> GetByteArray(this IFormFile formFile)
        {
            if (formFile==null)
            {
                return null;
            }
            if (formFile.Length <= 0)
                return null;

            using (MemoryStream stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream);
                var fileBytes = stream.ToArray();
                return fileBytes;
            }
        }

        public async static Task<string> ConvertToBase64(this IFormFile formFile)
        {
            var base64String = Convert.ToBase64String(await GetByteArray(formFile));
            return $"data:image/png;base64," + base64String;
        }
    }
}
