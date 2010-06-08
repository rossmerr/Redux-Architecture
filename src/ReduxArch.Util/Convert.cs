using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Util
{
    public static class Convert
    {
        //Bytes to ...
        private const double BToKbFactor = 1d / 1024;
        private const double BToMbFactor = 1d / 1024 / 1024;
        private const double BToGbFactor = 1d / 1024 / 1024 / 1024;

        //Kilobytes to ...
        private const double KbToMbFactor = 1d / 1024;
        private const double KbToGbFactor = 1d / 1024 / 1024;

        //Megabyte to ...
        private const double MbToGbFactor = 1d / 1024;

        public static double BytesToKiloBytes(int bytes)
        {
            return BytesToKiloBytes(System.Convert.ToInt64(bytes));
        }

        public static double BytesToKiloBytes(long bytes)
        {
            return bytes * BToKbFactor;
        }

        public static double BytesToMegabytes(int bytes)
        {
            return BytesToMegabytes(System.Convert.ToInt64(bytes));
        }

        public static double BytesToMegabytes(long bytes)
        {
            return bytes * BToMbFactor;
        }

        public static double BytesToGigabytes(int bytes)
        {
            return BytesToGigabytes(System.Convert.ToInt64(bytes));
        }

        public static double BytesToGigabytes(long bytes)
        {
            return bytes * BToGbFactor;
        }



        public static double KilobytesToMegabytes(int kilobytes)
        {
            return KilobytesToMegabytes(System.Convert.ToInt64(kilobytes));
        }

        public static double KilobytesToMegabytes(long kilobytes)
        {
            return kilobytes * KbToMbFactor;
        }

        public static double KilobytesToGigabytes(int kilobytes)
        {
            return KilobytesToGigabytes(System.Convert.ToInt64(kilobytes));
        }

        public static double KilobytesToGigabytes(long kilobytes)
        {
            return kilobytes * KbToGbFactor;
        }



        public static double MegabyteToGigabytes(int megabyte)
        {
            return MegabyteToGigabytes(System.Convert.ToInt64(megabyte));
        }

        public static double MegabyteToGigabytes(long megabyte)
        {
            return megabyte * MbToGbFactor;
        }

    }
}
