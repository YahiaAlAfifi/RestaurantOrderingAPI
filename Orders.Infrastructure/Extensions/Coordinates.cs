using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Extensions
{
    public class Coordinates
    {
        private const double EarthRadiusKm = 6371;

        public double Latitude { get; }
        public double Longitude { get; }

        public Coordinates(
            double latitude,
            double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double DistanceTo(Coordinates coordinates)
        {
            var latitudeDifference =
                ToRadians(coordinates.Latitude - Latitude);

            var longitudeDifference =
                ToRadians(coordinates.Longitude - Longitude);

            var latitude1 = ToRadians(Latitude);
            var latitude2 = ToRadians(coordinates.Latitude);

            var value =
                Math.Sin(latitudeDifference / 2) *
                Math.Sin(latitudeDifference / 2) +
                Math.Cos(latitude1) *
                Math.Cos(latitude2) *
                Math.Sin(longitudeDifference / 2) *
                Math.Sin(longitudeDifference / 2);

            var distance =
                2 * Math.Atan2(
                    Math.Sqrt(value),
                    Math.Sqrt(1 - value));

            return EarthRadiusKm * distance;
        }

        private static double ToRadians(double value)
        {
            return value * Math.PI / 180;
        }
    }
}
