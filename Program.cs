using iTextSharp.text.pdf;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Count() != 1)
        {
            Console.WriteLine("This function can only accept a single argument. Please call again with a single argument indicating the file path to clean.");
        }
        else
        {
            int i = 1;
            i = recursivelyDeleteEmptyFolders(args[0], i);
            Console.WriteLine($"Cleaning Complete. Successfully deleted {i} empty folders recursively.");
        }
    }

    public static int recursivelyDeleteEmptyFolders(string startLocation, int i)
    {
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            try
            {
                recursivelyDeleteEmptyFolders(directory, i);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                    Console.WriteLine($"Deleting {directory}");
                    i++;
                }
            }
            catch
            {
                Console.WriteLine($"Unable to delete {directory}");
            }
        }
        return i;
    }
}