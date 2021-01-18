﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using Molder.Helpers;
using Molder.Models.Profider.Interfaces;
using Microsoft.Extensions.Logging;

namespace Molder.Models
{
    [ExcludeFromCodeCoverage]
    public class WebProvider: IWebProvider
    {
        public bool Download(string url, string pathToSave, string filename)
        {
            try
            {
                using (var webclient = new WebClient())
                {
                    string endPath = new TextFile().PathProvider.Combine(pathToSave, filename);
                    webclient.DownloadFile(new Uri(url), endPath);
                    bool isExist = new TextFile().IsExist(filename, pathToSave);
                    if (isExist)
                    {
                        Log.Logger().LogWarning($"The file \"{filename}\" has been downloaded to the \"{endPath}\"");
                        return true;
                    }
                    else
                    {
                        Log.Logger().LogWarning($"File \"{filename}\" not downloaded");
                        throw new FileNotFoundException($"File \"{filename}\" not downloaded");
                    }
                }
            }

            catch (WebException e)
            {
                Log.Logger().LogError($"File \"{filename}\" not downloaded due to error \"{e.Message}\"");
                return false;
            }
        }
    }
}