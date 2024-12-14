using System;
using System.Collections.Generic;

namespace Prototype
{
    // Prototype Interface
    public interface ICloneableDisk
    {
        ICloneableDisk Clone();
    }

    // Concrete Prototype
    public class DiskImage : ICloneableDisk
    {
        public string OS { get; set; }
        public List<string> InstalledApplications { get; set; }

        // Deep Clone Method
        public ICloneableDisk Clone()
        {
            return new DiskImage
            {
                OS = this.OS,
                InstalledApplications = new List<string>(this.InstalledApplications)
            };
        }

        public override string ToString()
        {
            return $"OS: {OS}, Applications: {string.Join(", ", InstalledApplications)}";
        }
    }

    // Client Code
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Master Disk Image
            var masterDisk = new DiskImage
            {
                OS = "Windows XP",
                InstalledApplications = new List<string> { "Firefox", "Internet Explorer", "Counter-Strike 1.6" }
            };

            Console.WriteLine("Master Disk Image:");
            Console.WriteLine(masterDisk);

            // Cloning Disk Image for Computers
            var computer1Disk = masterDisk.Clone() as DiskImage;
            var computer2Disk = masterDisk.Clone() as DiskImage;

            // Customizing Individual Clones
            computer1Disk.InstalledApplications.Add("Frozen Throne");
            computer2Disk.InstalledApplications.Add("WOW");

            Console.WriteLine("\nComputer 1 Disk:");
            Console.WriteLine(computer1Disk);

            Console.WriteLine("\nComputer 2 Disk:");
            Console.WriteLine(computer2Disk);

            Console.WriteLine("\nMaster Disk Image Remains Unchanged:");
            Console.WriteLine(masterDisk);
        }
    }
}
