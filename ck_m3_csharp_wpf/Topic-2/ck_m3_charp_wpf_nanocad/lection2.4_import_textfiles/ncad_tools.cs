using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HostMgd.Runtime;
using Teigha.Geometry;
using HostMgd.ApplicationServices;
using Teigha.Runtime;
using Teigha.DatabaseServices;
using HostMgd.EditorInput;

namespace lection2._4_import_textfiles
{
	internal static class ncad_tools
	{
		/// <summary>
		/// Получение имен блоков чертежа
		/// </summary>
		/// <returns></returns>
		public static Dictionary<ObjectId,string> GetBlockNames()
		{
			Dictionary<ObjectId, string> blocks_data = new Dictionary<ObjectId, string>(0);
		   Document nc_doc = Application.DocumentManager.MdiActiveDocument;
			using (DocumentLock ncDocLock = nc_doc.LockDocument())
			{
				using (Transaction ncTrans = nc_doc.Database.TransactionManager.StartTransaction())
				{
					BlockTable nc_doc_table = ncTrans.GetObject(nc_doc.Database.BlockTableId, 
						OpenMode.ForRead) as BlockTable;

					foreach (ObjectId block_t_id in nc_doc_table)
					{
						BlockTableRecord bt_r = ncTrans.GetObject(block_t_id, 
							OpenMode.ForRead) as BlockTableRecord;
						string temp_name = bt_r.Name;
						if (temp_name[0] != '*') blocks_data.Add(block_t_id, temp_name);

					}

				}
			}
			 return blocks_data;

		}

		public static void Insertdata(ref List<double[]> coords, bool as_blocks, string name = null)
		{
			Document nc_doc = Application.DocumentManager.MdiActiveDocument;
			var blocks_data = GetBlockNames();
			using (DocumentLock ncDocLock = nc_doc.LockDocument())
			{
				using (Transaction ncTrans = nc_doc.Database.TransactionManager.StartTransaction())
				{
					BlockTable nc_doc_table = ncTrans.GetObject(nc_doc.Database.BlockTableId,
						OpenMode.ForRead) as BlockTable;

					BlockTableRecord model_space = ncTrans.
						GetObject(nc_doc_table[BlockTableRecord.ModelSpace], OpenMode.ForWrite)
						as BlockTableRecord;

					

					foreach (double[] coord in coords)
					{
						if (as_blocks) as_block();
						else as_point();

						void as_point()
						{
							DBPoint p = new DBPoint(new Point3d(coord[0], coord[1], 0.0));
							p.SetDatabaseDefaults();
							model_space.AppendEntity(p);
							ncTrans.AddNewlyCreatedDBObject(p, true);
						}
						void as_block()
						{
							ObjectId parent_block = blocks_data.Where(a => a.Value == name).First().Key;
							BlockReference bl = new BlockReference(new Point3d(coord[0], coord[1], 0.0),
								parent_block);

							bl.SetDatabaseDefaults();
							model_space.AppendEntity(bl);
							ncTrans.AddNewlyCreatedDBObject(bl, true);
						}


					}
					

					ncTrans.Commit();
				}
			}
		}
	}
}
