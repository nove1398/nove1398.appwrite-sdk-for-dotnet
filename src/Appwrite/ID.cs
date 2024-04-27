using System;

namespace Appwrite
{
    public static class ID
    {
        // Generate an hex ID based on timestamp
        // Recreated from https://www.php.net/manual/en/function.uniqid.php
        private static string HexTimestamp()
        {
            var now = DateTime.UtcNow;
            var epoch = (now - new DateTime(1970, 1, 1));
            var sec = (long)epoch.TotalSeconds;
            var usec = (long)((epoch.TotalMilliseconds * 1000) % 1000);

            // Convert to hexadecimal
            var hexTimestamp = sec.ToString("x") + usec.ToString("x").PadLeft(5, '0');
            return hexTimestamp;
        }

        // Generate a unique ID with padding to have a longer ID
        public static string Unique(int padding = 7)
        {
            var random = new Random();
            var baseId = HexTimestamp();
            var randomPadding = "";

            for (int i = 0; i < padding; i++)
            {
                var randomHexDigit = random.Next(0, 16).ToString("x");
                randomPadding += randomHexDigit;
            }

            return baseId + randomPadding;
        }

        public static string Custom(string id)
        {
            return id;
        }
    }
}
