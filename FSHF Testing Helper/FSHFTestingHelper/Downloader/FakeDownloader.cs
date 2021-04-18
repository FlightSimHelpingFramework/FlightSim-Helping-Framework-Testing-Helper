// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FSHFStandardLibrary.Core.Downloader.General;
using FSHFStandardLibrary.Core.Downloader.Specific;

#endregion

namespace FSHFTestingHelper.Downloader
{
    public class FakeDownloader : IDownloader<DownloadResultWithIcaoCode<string>, UrlDownloadRequestWithIcaoCode>
    {
        #region Implementation of IDownloader<string>
        public Task<List<DownloadResultWithIcaoCode<string>>> DownloadForManyRequestsAsync(
            IEnumerable<UrlDownloadRequestWithIcaoCode> downloadRequests)
        {
            return Task.Run(() =>
            {
                List<DownloadResultWithIcaoCode<string>> toReturn = new List<DownloadResultWithIcaoCode<string>>();
                foreach (var request in downloadRequests)
                {
                    toReturn.Add(
                        new DownloadResultWithIcaoCode<string>(GetString(request, out HttpStatusCode responseCode),
                            new TimeSpan(), responseCode, request.AirportIcaoCode));
                }

                return toReturn;
            });
        }

        private string GetString(UrlDownloadRequestWithIcaoCode request, out HttpStatusCode responseCode)
        {
            responseCode = HttpStatusCode.OK;
            try
            {
                string a = request.Url.AbsolutePath;
                string b = a.Substring(1, a.Length - 1);
                string s = File.ReadAllText(b);
                return s;
            }
            catch (Exception e)
            {
                responseCode = HttpStatusCode.NotFound;
                return null;
            }
        }

        #endregion
    }
}