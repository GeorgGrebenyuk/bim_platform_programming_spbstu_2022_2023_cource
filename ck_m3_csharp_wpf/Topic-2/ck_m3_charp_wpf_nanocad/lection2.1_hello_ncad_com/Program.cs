using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lection2._1_hello_ncad_com
{
	internal class Program
	{
		static void Main(string[] args)
		{
			nanoCAD.Application nc_app = Marshal.GetActiveObject("nanoCADx64.Application.22.0") 
				as nanoCAD.Application;
			Console.WriteLine(nc_app.Caption);

			nanoCAD.Document nc_doc = nc_app.ActiveDocument;
			Console.WriteLine(nc_doc.Name);

			OdaX.AcadModelSpace nc_modelSpace = nc_doc.ModelSpace;
			Console.WriteLine(nc_modelSpace.Count);

			foreach (OdaX.AcadEntity model_object in nc_modelSpace)
			{
				if (model_object.EntityName == "AcDbBlockReference")
				{
					OdaX.AcadBlockReference block_ref = model_object as OdaX.AcadBlockReference;
					Console.WriteLine("block name " + block_ref.EffectiveName);
				}
				
			}


			Console.ReadKey();
		}
	}
}
