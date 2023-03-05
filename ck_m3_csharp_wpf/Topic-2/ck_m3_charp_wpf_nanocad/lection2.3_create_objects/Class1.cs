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

namespace lection2._3_create_objects
{
    public class Class1
    {
		private Point3d ByExtends(Extents3d ext)
		{
			double x = (ext.MaxPoint.X + ext.MinPoint.X) / 2;
			double y = (ext.MaxPoint.Y + ext.MinPoint.Y) / 2;
			return new Point3d(x, y, 0.0);
		}

		[CommandMethod("ncad_create_objects")]
        public void create_objects()
        {
            Document nc_doc = Application.DocumentManager.MdiActiveDocument;
            using (DocumentLock ncDocLock = nc_doc.LockDocument())
            {
                using (Transaction ncTrans = nc_doc.Database.TransactionManager.StartTransaction())
                {
                    BlockTable nc_doc_table = ncTrans.GetObject(nc_doc.Database.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord model_space = ncTrans.GetObject(nc_doc_table[BlockTableRecord.ModelSpace], OpenMode.ForWrite)
                        as BlockTableRecord;

                    //Получить объект выделенный пользователем в модели
                    PromptSelectionResult nc_prompt = nc_doc.Editor.GetSelection();
                    if (nc_prompt.Status == PromptStatus.OK)
                    {
                        SelectionSet sset = nc_prompt.Value;
                        SelectedObject sset_1 = sset[0];

                        if (sset_1 != null)
                        {
                            Entity nc_ent = ncTrans.GetObject(sset_1.ObjectId, OpenMode.ForRead) as Entity;
                            if (nc_ent != null)
                            {
                                Point3d p = ByExtends(nc_ent.GeometricExtents);

                                PromptStringOptions opts = new PromptStringOptions("\n Выберите тип создаваемого объекта (0: Точка, " +
                                    "1: Полилиния, 2: Штриховка)");

                                PromptResult res_input = nc_doc.Editor.GetString(opts);
                                string result_as_string = res_input.StringResult;
                                if (result_as_string == "0")
                                {
                                    DBPoint p2 = new DBPoint(p);
									p2.SetDatabaseDefaults();
									model_space.AppendEntity(p2);
									ncTrans.AddNewlyCreatedDBObject(p2, true);

                                }
                                else if (result_as_string == "1")
                                {
									List<double[]> coords = new List<double[]>()
									{
											new double[2]{p.X + 10, p.Y },
											new double[2]{p.X, p.Y- 10},
											new double[2]{p.X - 10, p.Y },
											new double[2]{p.X, p.Y+10 },
									};
                                    Polyline ncPoly = new Polyline();
                                    ncPoly.SetDatabaseDefaults();

                                    int counter_points = 0;
                                    foreach (var row_point in coords)
                                    {
                                        ncPoly.AddVertexAt(counter_points, new Point2d(row_point[0], row_point[1]), 0, 0, 0);
										counter_points++;

									}
                                    ncPoly.Closed = true;
									model_space.AppendEntity(ncPoly);
									ncTrans.AddNewlyCreatedDBObject(ncPoly, true);

								}
                                else if (result_as_string == "2")
								{
									Hatch acHatch = new Hatch();
									acHatch.SetDatabaseDefaults();
									Vector3d normal = new Vector3d(0.0, 0.0, 1.0);

									acHatch.HatchObjectType = HatchObjectType.HatchObject;
									acHatch.Normal = normal;
									acHatch.Elevation = 0.0;
									acHatch.PatternScale = 0.5;

									acHatch.SetHatchPattern(HatchPatternType.PreDefined, "BRASS");

									model_space.AppendEntity(acHatch);
									ncTrans.AddNewlyCreatedDBObject(acHatch, true);

									List<double[]> coords = new List<double[]>()
										{
											new double[2]{p.X + 15, p.Y },
											new double[2]{p.X, p.Y- 15},
											new double[2]{p.X - 15, p.Y },
											new double[2]{p.X, p.Y+15 },
											//new double[2]{p.X + 15, p.Y },
										};
									Point2dCollection p2d_coll = new Point2dCollection(coords.Count);
									DoubleCollection b_coll = new DoubleCollection(coords.Count);

									for (int part_counter = 0; part_counter < coords.Count; part_counter++)
									{
										var point_geometry = coords[part_counter];
										p2d_coll.Add(new Point2d(point_geometry[0], point_geometry[1]));
										b_coll.Add(0);
									}

									acHatch.Associative = true;
									acHatch.AppendLoop(HatchLoopTypes.Default, p2d_coll, b_coll);
									acHatch.EvaluateHatch(true);
								}

							}
                        }
                    }

					ncTrans.Commit();
                }
            }
        }
    }
}
