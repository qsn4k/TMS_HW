using lesson_23.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
namespace lesson_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var contex = new AppContext())
            {
                var Readers = contex.Readers.ToList();
                foreach (var reader in Readers)
                {
                    Console.WriteLine(reader);
                }
            }
        }
    }
}