﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaMining.PositionImporter.Gpx
{
  public class GpxPoint
  {
    private const double EARTH_RADIUS = 6371; // [km]
    private const double RADIAN = Math.PI / 180;

    protected GpxProperties Properties_ = new GpxProperties();

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Elevation { get; set; }
    public DateTime? Time { get; set; }

    public double? MagneticVar
    {
      get { return Properties_.GetValueProperty<double>("MagneticVar"); }
      set { Properties_.SetValueProperty<double>("MagneticVar", value); }
    }

    public double? GeoidHeight
    {
      get { return Properties_.GetValueProperty<double>("GeoidHeight"); }
      set { Properties_.SetValueProperty<double>("GeoidHeight", value); }
    }

    public string Name
    {
      get { return Properties_.GetObjectProperty<string>("Name"); }
      set { Properties_.SetObjectProperty<string>("Name", value); }
    }

    public string Comment
    {
      get { return Properties_.GetObjectProperty<string>("Comment"); }
      set { Properties_.SetObjectProperty<string>("Comment", value); }
    }

    public string Description
    {
      get { return Properties_.GetObjectProperty<string>("Description"); }
      set { Properties_.SetObjectProperty<string>("Description", value); }
    }

    public string Source
    {
      get { return Properties_.GetObjectProperty<string>("Source"); }
      set { Properties_.SetObjectProperty<string>("Source", value); }
    }

    public IList<GpxLink> Links
    {
      get { return Properties_.GetListProperty<GpxLink>("Links"); }
    }

    public string Symbol
    {
      get { return Properties_.GetObjectProperty<string>("Symbol"); }
      set { Properties_.SetObjectProperty<string>("Symbol", value); }
    }

    public string Type
    {
      get { return Properties_.GetObjectProperty<string>("Type"); }
      set { Properties_.SetObjectProperty<string>("Type", value); }
    }

    public string FixType
    {
      get { return Properties_.GetObjectProperty<string>("FixType"); }
      set { Properties_.SetObjectProperty<string>("FixType", value); }
    }

    public int? Satelites
    {
      get { return Properties_.GetValueProperty<int>("Satelites"); }
      set { Properties_.SetValueProperty<int>("Satelites", value); }
    }

    public double? Hdop
    {
      get { return Properties_.GetValueProperty<double>("Hdop"); }
      set { Properties_.SetValueProperty<double>("Hdop", value); }
    }

    public double? Vdop
    {
      get { return Properties_.GetValueProperty<double>("Vdop"); }
      set { Properties_.SetValueProperty<double>("Vdop", value); }
    }

    public double? Pdop
    {
      get { return Properties_.GetValueProperty<double>("Pdop"); }
      set { Properties_.SetValueProperty<double>("Pdop", value); }
    }

    public double? AgeOfData
    {
      get { return Properties_.GetValueProperty<double>("AgeOfData"); }
      set { Properties_.SetValueProperty<double>("AgeOfData", value); }
    }

    public int? DgpsId
    {
      get { return Properties_.GetValueProperty<int>("DgpsId"); }
      set { Properties_.SetValueProperty<int>("DgpsId", value); }
    }

    public GpxLink HttpLink
    {
      get
      {
        return Links.Where(l => l != null && l.Uri != null && l.Uri.Scheme == Uri.UriSchemeHttp).FirstOrDefault();
      }
    }

    public GpxLink EmailLink
    {
      get
      {
        return Links.Where(l => l != null && l.Uri != null && l.Uri.Scheme == Uri.UriSchemeMailto).FirstOrDefault();
      }
    }

    public double GetDistanceFrom(GpxPoint other)
    {
      double thisLatitude = Latitude * RADIAN;
      double otherLatitude = other.Latitude * RADIAN;
      double deltaLongitude = Math.Abs(Longitude - other.Longitude) * RADIAN;

      double cos = Math.Cos(deltaLongitude) * Math.Cos(thisLatitude) * Math.Cos(otherLatitude) +
                   Math.Sin(thisLatitude) * Math.Sin(otherLatitude);

      return EARTH_RADIUS * Math.Acos(Math.Max(Math.Min(cos, 1), -1));
    }
  }
}