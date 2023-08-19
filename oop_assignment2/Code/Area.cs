using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopassign2FINAL
{
    public abstract class Area
    {
        protected string name;
        protected int water;
        public int humidity;

        protected Area(string name, int water)
        {
            this.name = name;
            this.water = water;
        }

        public int getWater() { return water; }

        public string getName() { return name; }
        public void changeWater(int w) { water += w; }

        public void modifyHumidity()
        {
            if (this.isLake())
            {
                this.humidity += (15*this.humidity)/100;
            }

            if (this.isPlain())
            {
                this.humidity += (5*this.humidity)/100;
            }
            if (this.isGrassLand())
            {
                this.humidity += (10*this.humidity)/100;
            }
        }

        public void setHumidity(int h) { humidity = h; }

        public virtual bool isPlain() { return false; }
        public virtual bool isGrassLand() { return false; }
        public virtual bool isLake() { return false; }

        public Area modifyArea()
        {
            if (this.isPlain())
            {
                if (this.getWater() > 15)
                {
                    return new grassLand(this.getName(), this.getWater());
                }
                else { return this; }
            }
            if (this.isGrassLand())
            {
                if (this.getWater() > 50)
                {
                    return new lakes(this.getName(), this.getWater());
                }
                else if (this.getWater() < 16)
                {
                    return new plain(this.getName(), this.getWater());
                }
                else { return this; }
            }
            if (this.isLake())
            {
                if (this.getWater() < 51)
                {
                    return new grassLand(this.getName(), this.getWater());
                }
                else { return this; }
            }
            return this;
        }

        public Iweather updateWeather()
        {
            if (this.humidity >= 70)
            {
                this.setHumidity(30);
                return Rainy.Instance();
            }
            else if (this.humidity > 40 && this.humidity < 70)
            {

                double ChanceOfRain = (this.humidity - 30) * 3.3;
                Random random = new Random();

                if (ChanceOfRain > random.Next(1, 101))
                {
                    return Rainy.Instance();
                }
                else { return Cloudy.Instance(); }
            }
            else { return Sunny.Instance(); }
        }

        public abstract Iweather weather_affect_area(Iweather weather);

        public override string ToString()
        {
            return $"{getType()}: {getName()}, water: {getWater()}, humidity: {this.humidity}";
        }

        public string getType()
        {
            if (this.isLake()) { return "Lake"; }
            else if (this.isPlain()) { return "Plain"; }
            else { return "GrassLand"; }
        }
    }

    public class plain : Area
    {

        public plain(string name, int water) : base(name, water) { }

        public override bool isPlain() { return true; }

        public override Iweather weather_affect_area(Iweather weather)
        {
            return weather.changePlain(this);
        }
    }

    public class grassLand : Area
    {
        public grassLand(string name, int water) : base(name, water) { }

        public override bool isGrassLand() { return true; }

        public override Iweather weather_affect_area(Iweather weather)
        {
            return weather.changeGL(this);
        }
    }

    public class lakes : Area
    {
        public lakes(string name, int water) : base(name, water) { }

        public override bool isLake() { return true; }

        public override Iweather weather_affect_area(Iweather weather)
        {
            return weather.changeLR(this);
        }
    }
}
