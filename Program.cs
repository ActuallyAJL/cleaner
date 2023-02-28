using iTextSharp.text.pdf;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Count() != 1)
            {
                Console.WriteLine("This function can only accept a single argument. Please call again with a single argument indicating the file path to clean.");
            }
            else
            {
                recursivelyDeleteEmptyFolders(args[0]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static void recursivelyDeleteEmptyFolders(string startLocation)
    {
        int i = 0;
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            recursivelyDeleteEmptyFolders(directory);
            if (Directory.GetFiles(directory).Length == 0 &&
                Directory.GetDirectories(directory).Length == 0)
            {
                Directory.Delete(directory, false);
                Console.WriteLine($"Deleting {directory}");
                i++;
            }
        }
        Console.WriteLine($"Cleaning Complete. Successfully deleted {i} empty folders recursively.");
    }
}