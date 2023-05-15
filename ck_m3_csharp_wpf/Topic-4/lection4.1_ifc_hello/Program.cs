using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GeometryGym.Ifc;


namespace lection4._1_ifc_hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ifc_path = @"C:\Users\Georg\Documents\GitHub\bim_platform_programming_spbstu_2022_2023_cource\ck_m3_csharp_wpf\Topic-4\Maisonette.ifc";
            DatabaseIfc ifc = new DatabaseIfc(ifc_path);

            IfcBuilding building = ifc.Where(a => a.StepClassName == "IfcBuilding").First() as IfcBuilding;
            foreach (var build_elem in building.ReferencesElements)
            {
                Console.WriteLine(build_elem.Name);
            }


            Console.WriteLine("\n End!");
            Console.ReadKey();
        }
    }
}
