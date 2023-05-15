using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renga_alignments
{
    public partial class AlignmentsWatcher : Form
    {
        private List<Renga.IModelObject> routes;
        private List<int> ids;
        public AlignmentsWatcher()
        {
            InitializeComponent();
            ShowData();
        }
        private void ShowData()
        {
            this.alignm_form.Nodes.Clear();
            ids = new List<int>();
            routes = new List<Renga.IModelObject>();
            Renga.Application app = new Renga.Application();
            var project = app.Project;
            if (project != null )
            {
                Renga.IModelObjectCollection coll = project.Model.GetObjects();
                for (int o_counter = 0; o_counter < coll.Count; o_counter++)
                {
                    Renga.IModelObject obj = coll.GetByIndex(o_counter);
                    ids.Add(obj.Id);

                    var as_route = obj as Renga.IRouteParams;
                    if (as_route != null)
                    {
                        TreeNode node = new TreeNode(obj.Name);
                        for (int obj_at_route = 0; 
                            obj_at_route < as_route.GetObjectOnRouteCount(); obj_at_route++)
                        {
                            Renga.IObjectOnRoutePlacement one_object = as_route.GetObjectOnRoutePlacement(obj_at_route);
                            Renga.IModelObject obj_at_route_2 = coll.GetById(one_object.Id);
                            node.Nodes.Add(obj_at_route_2.Name);
                        }
                        routes.Add(obj);
                        this.alignm_form.Nodes.Add(node);
                    }
                }
            }
        }

        private void alignm_form_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string route_name = this.alignm_form.SelectedNode.Text;
            int index = this.alignm_form.SelectedNode.Index;
            if (index > -1 && index <= this.routes.Count)
            {
                IEnumerable<Renga.IModelObject> objs = this.routes.
                    Where(a => a.Name == route_name);
                if (objs.Any())
                {
                    
                    Renga.IModelObject selected_object = objs.First();
                    Renga.Application app = new Renga.Application();
                    Renga.IModelView view = app.ActiveView as Renga.IModelView;
                    var objects_to_hide =
                        this.ids.Except(new List<int>(1) { selected_object.Id }).ToArray();
                    view.SetObjectsVisibility(objects_to_hide, false);
                    app.Selection.SetSelectedObjects(new List<int>(1) { selected_object.Id }.ToArray());
                }
                
            }
        }

        private void update_routes_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
