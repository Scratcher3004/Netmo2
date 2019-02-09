﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace Netmo2.Util
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using JsonDeserialize;

    public partial class NetAtmoResponse : SerializeableJsonObject
    {
        //[JsonProperty("body")]
        public Body Body { get; set; } = new Body();

        //[JsonProperty("status")]
        public string Status { get; set; } = "";

        //[JsonProperty("time_exec")]
        public double TimeExec { get; set; }

        //[JsonProperty("time_server")]
        public double TimeServer { get; set; }

        public override SerializeableJsonObject CreateInstance()
        {
            return new NetAtmoResponse();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return Body;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "status":
                    return Status;

                case "time_exec":
                    return TimeExec;

                case "time_server":
                    return TimeServer;

                default:
                    return null;
            }
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            Body = (Body)obj;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "status":
                    Status = (string)obj;
                    return;

                case "time_exec":
                    TimeExec = (double)obj;
                    return;

                case "time_server":
                    TimeServer = (double)obj;
                    return;

                default:
                    return;
            }
        }
    }

    public partial class Body : SerializeableJsonObject
    {
        //[JsonProperty("devices")]
        public Device[] Devices { get; set; } = { new Device() };

        //[JsonProperty("user")]
        public User User { get; set; } = new User();

        public override SerializeableJsonObject CreateInstance()
        {
            return new Body();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return User;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            return Devices;
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            User = (User)obj;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            Devices = new Device[((object[])obj).Length];
            int x = 0;
            foreach (var item in (SerializeableJsonObject[])obj)
            {
                Devices[x] = (Device)item;
                x++;
            }
            return;
        }
    }

    public partial class Device : SerializeableJsonObject
    {
        //[JsonProperty("_id")]
        public string Id { get; set; } = "";

        //[JsonProperty("cipher_id")]
        public string CipherId { get; set; } = "";

        //[JsonProperty("date_setup")]
        public long DateSetup { get; set; }

        //[JsonProperty("last_setup")]
        public long LastSetup { get; set; }

        //[JsonProperty("type")]
        public string Type { get; set; } = "";

        //[JsonProperty("last_status_store")]
        public long LastStatusStore { get; set; }

        //[JsonProperty("module_name")]
        public string ModuleName { get; set; } = "";

        //[JsonProperty("firmware")]
        public long Firmware { get; set; }

        //[JsonProperty("last_upgrade")]
        public long LastUpgrade { get; set; }

        //[JsonProperty("wifi_status")]
        public long WifiStatus { get; set; }

        //[JsonProperty("reachable")]
        public bool Reachable { get; set; }

        //[JsonProperty("co2_calibrating")]
        public bool Co2Calibrating { get; set; }

        //[JsonProperty("station_name")]
        public string StationName { get; set; } = "";

        //[JsonProperty("data_type")]
        public string[] DataType { get; set; } = new string[] { "" };

        //[JsonProperty("place")]
        public Place Place { get; set; } = new Place();

        //[JsonProperty("dashboard_data")]
        public DeviceDashboardData DashboardData { get; set; } = new DeviceDashboardData();

        //[JsonProperty("modules")]
        public Module[] Modules { get; set; } = new Module[] { new Module() };

        public override SerializeableJsonObject CreateInstance()
        {
            return new Device();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "place":
                    return Place;

                case "dashboard_data":
                    return DashboardData;

                default:
                    break;
            }
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "_id":
                    return Id;

                case "cipher_id":
                    return CipherId;

                case "date_setup":
                    return DateSetup;

                case "last_setup":
                    return LastSetup;

                case "type":
                    return Type;

                case "last_status_store":
                    return LastStatusStore;

                case "module_name":
                    return ModuleName;

                case "firmware":
                    return Firmware;

                case "last_upgrade":
                    return LastUpgrade;

                case "wifi_status":
                    return WifiStatus;

                case "reachable":
                    return Reachable;

                case "co2_calibrating":
                    return Co2Calibrating;

                case "station_name":
                    return StationName;

                case "data_type":
                    return DataType;

                case "modules":
                    return Modules;

                default:
                    break;
            }
            return null;
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            switch (jsonKey)
            {
                case "place":
                    Place = (Place)obj;
                    return;

                case "dashboard_data":
                    DashboardData = (DeviceDashboardData)obj;
                    return;

                default:
                    return;
            }
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "_id":
                    Id = (string)obj;
                    return;

                case "cipher_id":
                    CipherId = (string)obj;
                    return;

                case "date_setup":
                    DateSetup = (long)obj;
                    return;

                case "last_setup":
                    LastSetup = (long)obj;
                    return;

                case "type":
                    Type = (string)obj;
                    return;

                case "last_status_store":
                    LastStatusStore = (long)obj;
                    return;

                case "module_name":
                    ModuleName = (string)obj;
                    return;

                case "firmware":
                    Firmware = (long)obj;
                    return;

                case "last_upgrade":
                    LastUpgrade = (long)obj;
                    return;

                case "wifi_status":
                    WifiStatus = (long)obj;
                    return;

                case "reachable":
                    Reachable = (bool)obj;
                    return;

                case "co2_calibrating":
                    Co2Calibrating = (bool)obj;
                    return;

                case "station_name":
                    StationName = (string)obj;
                    return;

                case "data_type":
                    DataType = (string[])obj;
                    return;

                case "modules":
                    Modules = new Module[((object[])obj).Length];
                    int x = 0;
                    foreach (var item in (SerializeableJsonObject[])obj)
                    {
                        Modules[x] = (Module)item;
                        x++;
                    }
                    return;

                default:
                    return;
            }
        }
    }

    public partial class DeviceDashboardData : SerializeableJsonObject
    {
        //[JsonProperty("time_utc")]
        public long TimeUtc { get; set; }

        //[JsonProperty("Temperature")]
        public double Temperature { get; set; }

        //[JsonProperty("CO2")]
        public long Co2 { get; set; }

        //[JsonProperty("Humidity")]
        public long Humidity { get; set; }

        //[JsonProperty("Noise")]
        public long Noise { get; set; }

        //[JsonProperty("Pressure")]
        public double Pressure { get; set; }

        //[JsonProperty("AbsolutePressure")]
        public double AbsolutePressure { get; set; }

        //[JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        //[JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        //[JsonProperty("date_min_temp")]
        public long DateMinTemp { get; set; }

        //[JsonProperty("date_max_temp")]
        public long DateMaxTemp { get; set; }

        //[JsonProperty("temp_trend")]
        public string TempTrend { get; set; } = "";

        //[JsonProperty("pressure_trend")]
        public string PressureTrend { get; set; } = "";

        public override SerializeableJsonObject CreateInstance()
        {
            return new DeviceDashboardData();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "time_utc":
                    return TimeUtc;

                case "Temperature":
                    return Temperature;

                case "CO2":
                    return Co2;

                case "Humidity":
                    return Humidity;

                case "Noise":
                    return Noise;

                case "Pressure":
                    return Pressure;

                case "AbsolutePressure":
                    return AbsolutePressure;

                case "min_temp":
                    return MinTemp;

                case "max_temp":
                    return MaxTemp;

                case "date_min_temp":
                    return DateMinTemp;

                case "date_max_temp":
                    return DateMaxTemp;

                case "temp_trend":
                    return TempTrend;

                case "pressure_trend":
                    return PressureTrend;

                default:
                    return null;
            }
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            return;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "time_utc":
                    TimeUtc = (long)obj;
                    return;

                case "Temperature":
                    Temperature = (double)obj;
                    return;

                case "CO2":
                    Co2 = (long)obj;
                    return;

                case "Humidity":
                    Humidity = (long)obj;
                    return;

                case "Noise":
                    Noise = (long)obj;
                    return;

                case "Pressure":
                    Pressure = (double)obj;
                    return;

                case "AbsolutePressure":
                    AbsolutePressure = (double)obj;
                    return;

                case "min_temp":
                    MinTemp = (double)obj;
                    return;

                case "max_temp":
                    MaxTemp = (double)obj;
                    return;

                case "date_min_temp":
                    DateMinTemp = (long)obj;
                    return;

                case "date_max_temp":
                    DateMaxTemp = (long)obj;
                    return;

                case "temp_trend":
                    TempTrend = (string)obj;
                    return;

                case "pressure_trend":
                    PressureTrend = (string)obj;
                    return;

                default:
                    return;
            }
        }
    }

    public partial class Module : SerializeableJsonObject
    {
        //[JsonProperty("_id")]
        public string Id { get; set; } = "";

        //[JsonProperty("type")]
        public string Type { get; set; } = "";

        //[JsonProperty("module_name")]
        public string ModuleName { get; set; } = "";

        //[JsonProperty("data_type")]
        public string[] DataType { get; set; } = new string[] { "" };

        //[JsonProperty("last_setup")]
        public long LastSetup { get; set; }

        //[JsonProperty("reachable")]
        public bool Reachable { get; set; }

        //[JsonProperty("dashboard_data")]
        public ModuleDashboardData DashboardData { get; set; } = new ModuleDashboardData();

        //[JsonProperty("firmware")]
        public long Firmware { get; set; }

        //[JsonProperty("last_message")]
        public long LastMessage { get; set; }

        //[JsonProperty("last_seen")]
        public long LastSeen { get; set; }

        //[JsonProperty("rf_status")]
        public long RfStatus { get; set; }

        //[JsonProperty("battery_vp")]
        public long BatteryVp { get; set; }

        //[JsonProperty("battery_percent")]
        public long BatteryPercent { get; set; }

        public override SerializeableJsonObject CreateInstance()
        {
            return new Module();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return DashboardData;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "_id":
                    return Id;

                case "last_setup":
                    return LastSetup;

                case "type":
                    return Type;

                case "module_name":
                    return ModuleName;

                case "firmware":
                    return Firmware;

                case "reachable":
                    return Reachable;

                case "data_type":
                    return DataType;

                case "last_message":
                    return LastMessage;

                case "last_seen":
                    return LastSeen;

                case "rf_status":
                    return RfStatus;

                case "battery_vp":
                    return BatteryVp;

                case "battery_percent":
                    return BatteryPercent;

                default:
                    break;
            }
            return null;
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            DashboardData = (ModuleDashboardData)obj;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "_id":
                    Id = (string)obj;
                    return;

                case "last_setup":
                    LastSetup = (long)obj;
                    return;

                case "type":
                    Type = (string)obj;
                    return;

                case "module_name":
                    ModuleName = (string)obj;
                    return;

                case "firmware":
                    Firmware = (long)obj;
                    return;

                case "reachable":
                    Reachable = (bool)obj;
                    return;

                case "data_type":
                    DataType = (string[])obj;
                    return;

                case "last_message":
                    LastMessage = (long)obj;
                    return;

                case "last_seen":
                    LastSeen = (long)obj;
                    return;

                case "rf_status":
                    RfStatus = (long)obj;
                    return;

                case "battery_vp":
                    BatteryVp = (long)obj;
                    return;

                case "battery_percent":
                    BatteryPercent = (long)obj;
                    return;

                default:
                    return;
            }
        }
    }

    public partial class ModuleDashboardData : SerializeableJsonObject
    {
        //[JsonProperty("time_utc")]
        public long TimeUtc { get; set; }

        //[JsonProperty("Temperature")]
        public double Temperature { get; set; }

        //[JsonProperty("Humidity")]
        public long Humidity { get; set; }

        //[JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        //[JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        //[JsonProperty("date_min_temp")]
        public long DateMinTemp { get; set; }

        //[JsonProperty("date_max_temp")]
        public long DateMaxTemp { get; set; }

        //[JsonProperty("temp_trend")]
        public string TempTrend { get; set; } = "";

        //[JsonProperty("CO2", NullValueHandling = NullValueHandling.Ignore)]
        public long? Co2 { get; set; } = 0;

        public override SerializeableJsonObject CreateInstance()
        {
            return new ModuleDashboardData();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "time_utc":
                    return TimeUtc;

                case "Temperature":
                    return Temperature;

                case "CO2":
                    return Co2;

                case "Humidity":
                    return Humidity;

                case "min_temp":
                    return MinTemp;

                case "max_temp":
                    return MaxTemp;

                case "date_min_temp":
                    return DateMinTemp;

                case "date_max_temp":
                    return DateMaxTemp;

                case "temp_trend":
                    return TempTrend;

                default:
                    return null;
            }
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            return;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "time_utc":
                    TimeUtc = (long)obj;
                    return;

                case "Temperature":
                    Temperature = (double)obj;
                    return;

                case "CO2":
                    Co2 = (long)obj;
                    return;

                case "Humidity":
                    Humidity = (long)obj;
                    return;

                case "min_temp":
                    MinTemp = (double)obj;
                    return;

                case "max_temp":
                    MaxTemp = (double)obj;
                    return;

                case "date_min_temp":
                    DateMinTemp = (long)obj;
                    return;

                case "date_max_temp":
                    DateMaxTemp = (long)obj;
                    return;

                case "temp_trend":
                    TempTrend = (string)obj;
                    return;

                default:
                    return;
            }
        }
    }

    public partial class Place : SerializeableJsonObject
    {
        //[JsonProperty("altitude")]
        public long Altitude { get; set; }

        //[JsonProperty("city")]
        public string City { get; set; } = "";

        //[JsonProperty("country")]
        public string Country { get; set; } = "";

        //[JsonProperty("timezone")]
        public string Timezone { get; set; } = "";

        //[JsonProperty("location")]
        public double[] Location { get; set; } = new double[] { 0, 0 };

        public override SerializeableJsonObject CreateInstance()
        {
            return new Place();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "altitude":
                    return Altitude;

                case "city":
                    return City;

                case "country":
                    return Country;

                case "timezone":
                    return Timezone;

                case "location":
                    return Location;

                default:
                    return null;
            }
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            return;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "altitude":
                    Altitude = (long)obj;
                    return;

                case "city":
                    City = (string)obj;
                    return;

                case "country":
                    Country = (string)obj;
                    return;

                case "timezone":
                    Timezone = (string)obj;
                    return;

                case "location":
                    Location = (double[])obj;
                    return;

                default:
                    return;
            }
        }
    }

    public partial class User : SerializeableJsonObject
    {

        //[JsonProperty("mail")]
        public string Mail { get; set; } = "";

        //[JsonProperty("administrative")]
        public Administrative Administrative { get; set; } = new Administrative();

        public override SerializeableJsonObject CreateInstance() { return new User(); }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return Administrative;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            return Mail;
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            Administrative = (Administrative)obj;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            Mail = (string)obj;
        }
    }

    public partial class Administrative : SerializeableJsonObject
    {
        //[JsonProperty("lang")]
        public string Lang { get; set; } = "";

        //[JsonProperty("reg_locale")]
        public string RegLocale { get; set; } = "";

        //[JsonProperty("unit")]
        public long Unit { get; set; }

        //[JsonProperty("windunit")]
        public long Windunit { get; set; }

        //[JsonProperty("pressureunit")]
        public long Pressureunit { get; set; }

        //[JsonProperty("feel_like_algo")]
        public long FeelLikeAlgo { get; set; }

        public override SerializeableJsonObject CreateInstance()
        {
            return new Administrative();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "lang":
                    return Lang;

                case "reg_locale":
                    return RegLocale;

                case "unit":
                    return Unit;

                case "windunit":
                    return Windunit;

                case "pressureunit":
                    return Pressureunit;

                case "feel_like_algo":
                    return FeelLikeAlgo;

                default:
                    return null;
            }
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            return;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "lang":
                    Lang = (string)obj;
                    return;

                case "reg_locale":
                    RegLocale = (string)obj;
                    return;

                case "unit":
                    Unit = (long)obj;
                    return;

                case "windunit":
                    Windunit = (long)obj;
                    return;

                case "pressureunit":
                    Pressureunit = (long)obj;
                    return;

                case "feel_like_algo":
                    FeelLikeAlgo = (long)obj;
                    return;

                default:
                    return;
            }
        }
    }
}