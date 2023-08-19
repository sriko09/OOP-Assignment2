using oopassign2FINAL;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestModifyHumidity()
        {
            plain p = new plain("Ben", 40);
            p.humidity = 40; 
            p.modifyHumidity();
            Assert.AreEqual(p.humidity, 42);

            grassLand gl = new grassLand("Henry", 50);
            gl.humidity = 40;
            gl.modifyHumidity();
            Assert.AreEqual(gl.humidity, 44);

            lakes lr = new lakes("Harry", 60);
            lr.humidity = 20;
            lr.modifyHumidity();
            Assert.AreEqual(lr.humidity, 23);
        }

        [TestMethod]
        public void TestmodifyArea()
        {
            plain p = new plain("An", 20);
            Area a = p.modifyArea();
            Assert.IsTrue(a.isGrassLand());

            plain p2 = new plain("An", 12);
            Area a1 = p2.modifyArea();
            Assert.IsTrue(a1.isPlain());

            grassLand gl = new grassLand("Nell", 60);
            Area b = gl.modifyArea();
            Assert.IsTrue(b.isLake());

            grassLand gl2 = new grassLand("bell", 12);
            Area c = gl2.modifyArea();
            Assert.IsTrue(c.isPlain());

            grassLand gl3 = new grassLand("kell", 30);
            Area e = gl3.modifyArea();
            Assert.IsTrue(e.isGrassLand());

            lakes lr = new lakes("jess", 60);
            Area d = lr.modifyArea();
            Assert.IsTrue(d.isLake());

            lakes lr2 = new lakes("hess", 49);
            Area k = lr2.modifyArea();
            Assert.IsTrue(k.isGrassLand());
        }

        [TestMethod]
        public void TestupdateWeather()
        {
            Iweather weather = Sunny.Instance();
            plain p = new plain("judch", 50);
            p.humidity = 80;
            weather = p.updateWeather();
            Assert.IsTrue(weather.isRainy());
            Assert.AreEqual(p.humidity, 30);

            weather = p.updateWeather();
            Assert.IsTrue(weather.isSunny());
        }

        [TestMethod]
        public void Testweather_affect_area()
        {
            //For sunny weather
            Iweather weather = Sunny.Instance();

            plain p = new plain("jci", 90);
            p.weather_affect_area(weather);
            Assert.AreEqual(87, p.getWater());

            grassLand gl = new grassLand("lk", 60);
            gl.weather_affect_area(weather);
            Assert.AreEqual(54, gl.getWater());

            lakes l = new lakes("lop", 40);
            l.weather_affect_area(weather);
            Assert.AreEqual(30, l.getWater());

            //For rainy weather
            weather = Rainy.Instance();

            p.weather_affect_area(weather);
            Assert.AreEqual(107, p.getWater());

            gl.weather_affect_area(weather);
            Assert.AreEqual(69, gl.getWater());

            l.weather_affect_area(weather);
            Assert.AreEqual(50, l.getWater());

            //For cloudy weather
            weather = Cloudy.Instance();

            p.weather_affect_area(weather);
            Assert.AreEqual(106, p.getWater());

            gl.weather_affect_area(weather);
            Assert.AreEqual(67, gl.getWater());

            l.weather_affect_area(weather);
            Assert.AreEqual(47, l.getWater());

        }
    }
}