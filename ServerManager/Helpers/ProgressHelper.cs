using System;

namespace ServerManager.Helpers
{
    public static class ProgressHelper
    {
        public static int GetProgressPercentage(long processed, long total)
        {
            if (processed < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(processed), "Value must be greater than or equal to 0.");
            }

            if (processed > total)
            {
                throw new ArgumentOutOfRangeException(nameof(total), $"Value must be greater than or equal to {nameof(processed)}.");
            }

            int progressPercentage = 0;

            if (total > 0)
            {
                progressPercentage = (int)(processed * 100 / total);
            }

            return progressPercentage;
        }

        public static string FormatSize(long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Value must be greater than or equal to 0.");
            }

            if (size < 1024)
            {
                return size.ToString("#,##0 " + (size == 1 ? "byte" : "bytes"));
            }
            else if (size < 1024 * 1024)
            {
                return (size / 1024d).ToString("#,##0.00 KB");
            }
            else if (size < 1024 * 1024 * 1024)
            {
                return (size / 1024d / 1024).ToString("#,##0.00 MB");
            }
            else if (size < 1024L * 1024 * 1024 * 1024)
            {
                return (size / 1024d / 1024 / 1024).ToString("#,##0.00 GB");
            }

            return (size / 1024d / 1024 / 1024 / 1024).ToString("#,##0.00 TB");
        }

        public static string FormatProgressPercentage(long processed, long total)
        {
            if (processed < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(processed), "Value must be greater than or equal to 0.");
            }

            if (processed > total)
            {
                throw new ArgumentOutOfRangeException(nameof(total), $"Value must be greater than or equal to {nameof(processed)}.");
            }

            double progressPercentage = 0;

            if (total > 0)
            {
                progressPercentage = processed / (double)total;
            }

            return progressPercentage.ToString("0.0 %");
        }

        public static string FormatProgressLine(long processed, long total)
        {
            return $"{FormatSize(processed)} / {FormatSize(total)} - {FormatProgressPercentage(processed, total)}";
        }
    }
}
