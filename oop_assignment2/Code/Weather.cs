using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopassign2FINAL
{
    public interface Iweather
    {
        Iweather changePlain(plain p);
        Iweather changeGL(grassLand gl);
        Iweather changeLR(lakes lr);

        public virtual bool isSunny() { return false; }
        public virtual bool isCloudy() { return false; }
        public virtual bool isRainy() { return false; }
    }

    public class Sunny : Iweather
    {
        public Iweather changePlain(plain p)
        {
            p.changeWater(-3);
            return p.updateWeather();
        }

        public Iweather changeGL(grassLand gl)
        {
            gl.changeWater(-6);
            return gl.updateWeather();
        }

        public Iweather changeLR(lakes l)
        {
            l.changeWater(-10);
            return l.updateWeather();
        }

        public bool isSunny() { return true; }
        private Sunny() { }

        private static Sunny instance = null;
        public static Sunny Instance()
        {
            if (instance == null)
            {
                instance = new Sunny();
            }
            return instance;
        }
    }

    public class Cloudy : Iweather
    {

        public Iweather changePlain(plain p)
        {
            p.changeWater(-1);
            return p.updateWeather();
        }

        public Iweather changeGL(grassLand gl)
        {
            gl.changeWater(-2);
            return gl.updateWeather();
        }

        public Iweather changeLR(lakes l)
        {
            l.changeWater(-3);
            return l.updateWeather();
        }


        public bool isCloudy() { return true; }
        private Cloudy() { }

        private static Cloudy instance = null;
        public static Cloudy Instance()
        {
            if (instance == null)
            {
                instance = new Cloudy();
            }
            return instance;
        }
    }

    public class Rainy : Iweather
    {
        public Iweather changePlain(plain p)
        {
            p.changeWater(20);
            return p.updateWeather();
        }

        public Iweather changeGL(grassLand gl)
        {
            gl.changeWater(15);
            return gl.updateWeather();
        }

        public Iweather changeLR(lakes l)
        {
            l.changeWater(20);
            return l.updateWeather();
        }

        public bool isRainy() { return true; }
        private Rainy() { }

        private static Rainy instance = null;
        public static Rainy Instance()
        {
            if (instance == null)
            {
                instance = new Rainy();
            }
            return instance;
        }
    }
}

