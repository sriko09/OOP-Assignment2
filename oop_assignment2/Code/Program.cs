using TextFile;

namespace oopassign2FINAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");

            reader.ReadLine(out string line); int n = int.Parse(line);
            List<Area> areas = new();

            for (int i = 0; i < n; i++)
            {
                char[] separators = new char[] { ' ', '\t' };
                Area area = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0] + " " + tokens[1];
                    char a = char.Parse(tokens[2]);
                    int w = int.Parse(tokens[3]);

                    switch (a)
                    {
                        case 'P': area = new plain(name, w); break;
                        case 'G': area = new grassLand(name, w); break;
                        case 'L': area = new lakes(name, w); break;
                    }
                }

                areas.Add(area);
            }

            reader.ReadInt(out int humidity);

            //Before
            Console.WriteLine("Before: ");
            for (int i = 0; i < areas.Count; i++)
            {
                areas[i].setHumidity(humidity);
                Console.WriteLine(areas[i].ToString());
            }

            Console.WriteLine("\n\n");
            bool sametype = false;
            Iweather weather = Sunny.Instance();
            int x = 0;

            do
            {
                x++;
                Console.WriteLine("Round " + x);
                sametype = true;

                for (int i = 0; i < areas.Count; i++)
                {
                    //First modify humidity
                    areas[i].modifyHumidity();

                    //Weather is affected by humidity
                    weather = areas[i].updateWeather();

                    //Area's water is affected by weather
                    areas[i].weather_affect_area(weather);

                    //Store value of humidity
                    int hum = areas[i].humidity;

                    //Change areas
                    areas[i] = areas[i].modifyArea();

                    //Set humidity back to the area
                    areas[i].humidity = hum;

                    Console.WriteLine(areas[i].ToString());


                    sametype = sametype && (areas[i].getType()== areas[0].getType());
                }
                Console.WriteLine("\n\n");
            } while (!sametype);
        }
    }
}