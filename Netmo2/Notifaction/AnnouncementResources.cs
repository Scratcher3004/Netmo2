using JsonDeserialize;
using Netmo2.Util;
using Netmo2.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netmo2.Notifaction
{
    public class AnnouncementCollection : AnnouncementCollections
    {
        public List<Announcement> Announcements { get; private set; } = new List<Announcement>();

        public override Announcement GetAnnouncement(string announcementName)
        {
            int x = 0;
            foreach (var item in Announcements)
            {
                if (item.Name == announcementName)
                {
                    return item;
                }

                x++;
            }

            if (Announcements.Count < 1)
                throw new NoContentException("List of Announcements");
            else
                throw new KeyNotFoundException();
        }

        public override void SetAnnouncement(string announcementName, Announcement @new)
        {
            int x = 0;
            foreach (var item in Announcements)
            {
                if (item.Name == announcementName)
                {
                    Announcements[x] = @new;
                    return;
                }

                x++;
            }

            if (Announcements.Count < 1)
                throw new NoContentException("List of Announcements");
            else
                throw new KeyNotFoundException();
        }
    }

    public class DefaultDeviceAnnouncementResource : AnnouncementCollections, IDefaultResource<AnnouncementCollection>
    {
        public string ID { get; set; } = "";
        public bool UseAnnouncements { get; set; } = true;
        public Announcement LowTemp { get; set; }  = new Announcement("Low Temperature", "dashboard_data/Temperature", 2, Direction.Down);         // Notifictaion for Low  Temperature
        public Announcement HighTemp { get; set; } = new Announcement("High Temperature", "dashboard_data/Temperature", 25, Direction.Up);         // Notifictaion for High Temperature
        public Announcement LowHumi { get; set; }  = new Announcement("Low Humidity", "dashboard_data/Humidity", 20, Direction.Down);              // Notifictaion for Low  Humidity

        public Announcement HighCO2 { get; set; }      = new Announcement("High Co2", "dashboard_data/CO2", 1000, Direction.Up);               // Notifictaion for High CO2      - Only for devices and certain modules
        public Announcement HighPressure { get; set; } = new Announcement("High Pressure", "dashboard_data/Pressure", 1500, Direction.Up);     // Notifictaion for High Pressure - Only for devices


        public AnnouncementCollection ConvertTo()
        {
            AnnouncementCollection retVal = new AnnouncementCollection();

            retVal.Announcements.Add(LowTemp);
            retVal.Announcements.Add(HighTemp);
            retVal.Announcements.Add(LowHumi);

            retVal.Announcements.Add(HighCO2);
            retVal.Announcements.Add(HighPressure);

            return retVal;
        }

        public override Announcement GetAnnouncement(string announcementName)
        {
            List<Announcement> Announcements = ConvertTo().Announcements;

            int x = 0;
            foreach (var item in Announcements)
            {
                if (item.Name == announcementName)
                {
                    return item;
                }

                x++;
            }

            throw new KeyNotFoundException();
        }

        public override void SetAnnouncement(string announcementName, Announcement @new)
        {
            switch (announcementName)
            {
                case "Low Temperature":
                    LowTemp = @new;
                    break;

                case "High Temperature":
                    HighTemp = @new;
                    break;

                case "Low Humidity":
                    LowHumi = @new;
                    break;

                case "High CO2":
                    HighCO2 = @new;
                    break;

                case "High Pressure":
                    HighPressure = @new;
                    break;

                default:
                    throw new KeyNotFoundException();
            }
        }
    }

    public class DefaultModuleAnnouncementResource : AnnouncementCollections, IDefaultResource<AnnouncementCollection>
    {
        public string ID { get; set; } = "";
        public bool UseAnnouncements { get; set; } = true;
        public Announcement LowTemp { get; set; } = new Announcement("dashboard_data/Low Temperature", "Temperature", 2, Direction.Down);         // Notifictaion for Low  Temperature
        public Announcement HighTemp { get; set; } = new Announcement("dashboard_data/High Temperature", "Temperature", 25, Direction.Up);        // Notifictaion for High Temperature
        public Announcement LowHumi { get; set; } = new Announcement("dashboard_data/Low Humidity", "Humidity", 20, Direction.Down);              // Notifictaion for Low  Humidity

        public Announcement HighCO2 { get; set; } = new Announcement("High Co2", "dashboard_data/CO2", 1000, Direction.Up);                     // Notifictaion for High CO2    - Only for certain modules
        public Announcement LowBattery { get; set; } = new Announcement("Low Battery", "battery_percent", 20, Direction.Down);                // Notifictaion for Low Battery - Only for         modules

        public AnnouncementCollection ConvertTo()
        {
            AnnouncementCollection retVal = new AnnouncementCollection();

            retVal.Announcements.Add(LowTemp);
            retVal.Announcements.Add(HighTemp);
            retVal.Announcements.Add(LowHumi);

            retVal.Announcements.Add(HighCO2);
            retVal.Announcements.Add(LowBattery);

            return retVal;
        }

        public override Announcement GetAnnouncement(string announcementName)
        {
            List<Announcement> Announcements = ConvertTo().Announcements;

            int x = 0;
            foreach (var item in Announcements)
            {
                if (item.Name == announcementName)
                {
                    return item;
                }

                x++;
            }

            throw new KeyNotFoundException();
        }

        public override void SetAnnouncement(string announcementName, Announcement @new)
        {
            switch (announcementName)
            {
                case "Low Temperature":
                    LowTemp = @new;
                    break;

                case "High Temperature":
                    HighTemp = @new;
                    break;

                case "Low Humidity":
                    LowHumi = @new;
                    break;

                case "High CO2":
                    HighCO2 = @new;
                    break;

                default:
                    throw new KeyNotFoundException();
            }
        }
    }

    public class Announcement
    {
        public Announcement(string name, string id, float trigger, Direction direction)
        {
            Name = name;
            Id = id;
            Trigger = trigger;
            Dir = direction;
        }

        public string Name   { get; private set; } = "NewAnnouncement"; // Is self explaining (:
        public string Id     { get; private set; } = "Temperature";     // ID in Device/Module. Use dashboard_data/ in front to use Dashboard-Data -- Recommend
        public float Trigger { get; set; } = 2;                         // Trigger for Messages
        public Direction Dir { get; private set; } = Direction.Up;      // Less / Higher than trigger value for triggering as same?

        public bool IsTriggered(Device dashboardData)
        {
            long compare = 2020;

            SerializeableJsonObject newData = Serialization.Serialize(dashboardData, Id, out string id2);

            if (Dir == Direction.Up)
            {
                if (newData.GetValueByJsonKey(id2).GetType() == compare.GetType())
                    return (long)newData.GetValueByJsonKey(id2) >= Trigger;
                else
                    return (double)newData.GetValueByJsonKey(id2) >= Trigger;
            }
            else
            {
                if (newData.GetValueByJsonKey(id2).GetType() == typeof(long))
                    return (long)newData.GetValueByJsonKey(id2) <= Trigger;
                else
                    return (double)newData.GetValueByJsonKey(id2) <= Trigger;
            }
        }

        public bool IsTriggered(Module dashboardData)
        {
            long compare = 2020;

            SerializeableJsonObject newData = Serialization.Serialize(dashboardData, Id, out string id2);

            if (newData.GetValueByJsonKey(id2) == null) return false;

            if (Dir == Direction.Up)
            {
                if (newData.GetValueByJsonKey(id2).GetType() == compare.GetType())
                    return (long)newData.GetValueByJsonKey(id2) >= Trigger;
                else
                    return (double)newData.GetValueByJsonKey(id2) >= Trigger;
            }
            else
            {
                if (newData.GetValueByJsonKey(id2).GetType() == typeof(long))
                    return (long)newData.GetValueByJsonKey(id2) <= Trigger;
                else
                    return (double)newData.GetValueByJsonKey(id2) <= Trigger;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down
    }

    // Interfaces and abstract classes

    public interface IDefaultResource<T>
    {
        T ConvertTo();
    }

    public abstract class AnnouncementCollections
    {
        public abstract void SetAnnouncement(string announcementName, Announcement @new);
        public abstract Announcement GetAnnouncement(string announcementName);
    }

    // Serialization

    public static class Serialization
    {
        public static SerializeableJsonObject Serialize(SerializeableJsonObject start, string path, out string endOfPath)
        {
            List<string> pathSplitted = path.Split('/').ToList();
            endOfPath = pathSplitted[pathSplitted.Count - 1];

            if (pathSplitted.Count == 1)
            {
                return start;
            }

            SerializeableJsonObject jsonObject = start.GetObjectByJsonKey(pathSplitted[0]);
            pathSplitted.Remove(pathSplitted[0]);
            string newPath = string.Join("/", pathSplitted);

            return Serialize(jsonObject, newPath, out string unused);
        }
    }
}
