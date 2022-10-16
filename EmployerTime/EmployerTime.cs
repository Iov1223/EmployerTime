using System;
using System.Collections;
using System.Globalization;

namespace Indexers_lab
{
    enum DayOfWeek
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
    class EmployerTime : ICounter, IWhenCreated, IWorkToDisk
    {
        private int[] WorkTime;
        private int summOfHours;
        private DateTime CreatedTime;
        private string Name;

        public DateTime Created
        {
            get
            {
                Console.WriteLine($"Объект {this.ToString()}  был создан {CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                return CreatedTime;
            }
        }
        public int count
        {
            get
            {
                foreach (var item in WorkTime)
                {
                    summOfHours += item;
                }
                return summOfHours;
            }
        }
        public void BriefPrint()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{item} - {WorkTime[(int)item]}");
            }
        }
        public string filename
        {
            get
            {
                return Name;
            }
        }
        public bool SaveToDisk()
        {
            StreamWriter writer = new StreamWriter(filename, true);
            try
            {
                foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
                {
                    writer.WriteLine($"{item} - {WorkTime[(int)item]}");
                }
                writer.WriteLine($"За неделю отработанно - {count} час(ов/а)\nОбъект {filename}" +
                    $" был создан { CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}\n");

                writer.Close(); 
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ReadFromDisk()
        {
            StreamReader reader = new StreamReader(filename);
            string Text;
            try
            {
                Text = reader.ReadToEnd();
                Console.Write(Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public EmployerTime(string _name)
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            Name = _name;
        }
        public int this[int index]
        {
            set { WorkTime[index] = value; }
            get { return WorkTime[index]; }
        }
    }
} 