using System;
using System.Collections;

namespace CarConditionCheck
{
    public class CheckCar
    {
        private readonly double oilLevel, tirePressure, waterLevel;
        private readonly int mileage;
        readonly DateClass date;

        public CheckCar(int year, int month, int day, int mileage, double oilLevel=0, double tirePressure=0, double waterLevel=0)
        {
            this.oilLevel = oilLevel;
            this.tirePressure = tirePressure;
            this.waterLevel = waterLevel;
            this.mileage = mileage;
            date = new DateClass(year, month, day);
        }   

        public static int GetMilliageByPeriod(int firstYear, int lastYear, CheckCar[] checks)
        {
            int minYear = lastYear, maxYear = firstYear, firstMilliage=0, lastMilliage=0;
            foreach(CheckCar c in checks)
            {
                if(c == null)
                { break; }
                if(c.date.GetYear() >= firstYear && c.date.GetYear() <= lastYear)
                { 
                    if(minYear > c.date.GetYear())
                    {
                        minYear = c.date.GetYear();
                        firstMilliage = c.mileage;
                    }
                    else if (maxYear < c.date.GetYear())
                    {
                        maxYear = c.date.GetYear();
                        lastMilliage = c.mileage;
                    }
                }
            }
            return lastMilliage - firstMilliage;
        }

        public double GetOilLevel()
            { return this.oilLevel; }

        public double GetWaterLevel()
            { return this.waterLevel; }

        public int GetDateParamString(string param)
        {
            switch(param)
            {
                case "day":
                    return this.date.GetDay();
                case "month":
                    return this.date.GetMonth();
                case "year":
                    return this.date.GetYear();
                default:
                    return -1;
            }
        }

        public double GetTirePressure()
            { return this.tirePressure; }

        public int GetMilliage()
            { return this.mileage; }
        public string GetDateString()
        { return this.date.GetStringDate(); }

        public string GetDataInString()
        {
            return $"Water level - {this.waterLevel}\n" +
                $"Oil level - {this.oilLevel}\n" +
                $"Tire pressure - {this.tirePressure}\n" +
                $"Milliage - {this.mileage}\n" +
                $"Date - {this.date.GetStringDate()}";
        }

        public static bool operator <(CheckCar c1, CheckCar c2)
        {
            if (c1.date.GetYear() < c2.date.GetYear())
            {
                return true;
            }
            else if (c1.date.GetYear() == c2.date.GetYear() && c1.date.GetMonth() < c2.date.GetMonth())
            {
                return true;
            }
            else if (c1.date.GetYear() == c2.date.GetYear() && c1.date.GetMonth() == c2.date.GetMonth() && c1.date.GetDay() < c2.date.GetDay())
            {
                return true;
            }
            else return false;
        }


        public static bool operator >(CheckCar c1, CheckCar c2)
        {
            if (c1.date.GetYear() > c2.date.GetYear())
            {
                return true;
            }
            else if (c1.date.GetYear() == c2.date.GetYear() && c1.date.GetMonth() > c2.date.GetMonth())
            {
                return true;
            }
            else if (c1.date.GetYear() == c2.date.GetYear() && c1.date.GetMonth() == c2.date.GetMonth() && c1.date.GetDay() > c2.date.GetDay())
            {
                return true;
            }
            else return false;
        }

        public static CheckCar[] SortChecksArray(CheckCar[] arr)
        {
            int i = 1;
            int j = 2;
            while (i < arr.Length && arr[i] != null)
            {
                if (arr[i - 1] < arr[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    (arr[i-1], arr[i]) = (arr[i], arr[i-1]);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
            return arr;
        }

        public static double GetAveregeMilliage(CheckCar[] checks)
        {
            double result = 0;
            int j = 1, num=1;
            checks = SortChecksArray(checks);
            for (int i = 0; i<checks.Length; i++)
            {
                if (checks[i + 1] == null)
                {
                    return result / num;
                }
                double tmp = checks[i].tirePressure;
                while(checks[j].tirePressure < tmp && j<checks.Length)
                {
                    if(checks[j + 1] == null)
                    {
                        return result / num;
                    }

                    if (j + 1 < checks.Length)
                    {
                        j++;
                    }
                    else return result / num;
                }
                result += checks[j].mileage - checks[i].mileage;
                num++;
                i=j;
            }

            return result/num;
        }

        public static string GetAvgChecks(CheckCar[] checks, int firstYear, int lastYear)
        {
            int oilLvlCh = 0, waterLvlCh = 0, tirePressureCh = 0;
            foreach (CheckCar check in checks)
            {
                if(check == null)
                { break; }
                if (check.date.GetYear() >= firstYear && check.date.GetYear() <= lastYear)
                {
                    if (check.oilLevel != 0)
                    {
                        oilLvlCh++;
                    }
                    if (check.waterLevel != 0)
                    { waterLvlCh++; }
                    if (check.tirePressure != 0)
                    {
                        tirePressureCh++;
                    }
                }
            }
            return $"Checks by water level - {waterLvlCh}\n" +
                $"Checks by oil level - {oilLvlCh}\n" +
                $"Checks by tire pressure - {tirePressureCh}";
        }
    }
}