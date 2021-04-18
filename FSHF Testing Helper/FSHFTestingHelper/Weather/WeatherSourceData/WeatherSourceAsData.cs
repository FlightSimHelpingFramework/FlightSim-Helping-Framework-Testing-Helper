﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using FSHFWeatherInformation.Core.Enums;
using FSHFWeatherInformation.Core.Source;

#endregion

namespace FSHFTestingHelper.Weather.WeatherSourceData
{
    public static class WeatherSourceAsData
    {
        public static IEnumerable<object[]> CorrectWeatherSourceObjects
        {
            get
            {
                return new[]
                {
                    new object[] {new WeatherSource("Name 1", WeatherSourcesCategories.Custom, "Description 1")},
                    new object[] {new WeatherSource("2 Name", WeatherSourcesCategories.Authenticated, "1 Description")},
                    new object[] {new WeatherSource("3 Name 3", WeatherSourcesCategories.Public, "12 dEscription 1")}
                };
            }
        }
    }
}