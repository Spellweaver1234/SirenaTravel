using System;

namespace SirenaTravel.Models
{
    public static class Calculator
    {
        const int R = 6371;     // радиус Земли

        static public double DistanceBetweenAirports(double longitudeA, double latitudeA, double longitudeB, double latitudeB)
        {
            double λA = DegreesToRadians(longitudeA);   // λА
            double φA = DegreesToRadians(latitudeA);    // φА
            double λB = DegreesToRadians(longitudeB);   // λB
            double φB = DegreesToRadians(latitudeB);    // φB

            var d = 2 * R * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((φA - φB) / 2), 2) + Math.Cos(φA) * Math.Cos(φB) * Math.Pow(Math.Sin((λA - λB) / 2), 2)));

            return d;
        }

        static public double DistanceBetweenAirports_(double longitudeA, double latitudeA, double longitudeB, double latitudeB)
        {
            double λА = DegreesToRadians(longitudeA);   // λА
            double φА = DegreesToRadians(latitudeA);    // φА
            double λB = DegreesToRadians(longitudeB);   // λB
            double φB = DegreesToRadians(latitudeB);    // φB

            double cosD = Math.Sin(φА) * Math.Sin(-φB) + Math.Cos(φА) * Math.Cos(-φB) * Math.Cos(λА - λB);
            double D = Math.Acos(cosD);
            double L = D * R;               // расстояние в километрах

            return L;
        }

        static public double DegreesToRadians(double degree)
        {
            return degree * Math.PI / 180;
        }

        static public double KmToMiles(double km)
        {
            return km * 15625 / 25146;
        }
    }
}