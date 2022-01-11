﻿using System;
using Newtonsoft.Json;

namespace GPSDataProcessor
{
  public  class Location
  {
    public double LatitudeE7;
    public double LongitudeE7;
    public string Timestamp;
    public string Source;

    [JsonIgnore]
    public double Lat => LatitudeE7 / 10000000;

    [JsonIgnore]
    public double Lng => LongitudeE7 / 10000000;

    [JsonIgnore]
    public DateTime Date => DateTime.Parse(Timestamp);
  }
}