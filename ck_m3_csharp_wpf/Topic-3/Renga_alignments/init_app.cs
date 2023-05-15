using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;

namespace Renga_alignments
{
    public class init_app : Renga.IPlugin
    {
        Renga.ActionEventSource follow_action;
        public bool Initialize(string pluginFolder)
        {
            Renga.Application renga_app = new Renga.Application();
            if (renga_app != null)
            {
                Renga.IUI ui = renga_app.UI;
                Renga.IUIPanelExtension panel = ui.CreateUIPanelExtension();

                Renga.IAction button = ui.CreateAction();
                button.ToolTip = "Показать трассы";
                button.DisplayName = "Показать трассы";

                Renga.IImage icon = ui.CreateImage();
                icon.LoadFromFile(Path.Combine(pluginFolder, "logo.png"));
                button.Icon = icon;

                follow_action = new Renga.ActionEventSource(button);
                follow_action.Triggered += (sender, args) =>
                {
                    var form = new AlignmentsWatcher();
                    System.Windows.Forms.Application.Run(form);
                };
                panel.AddToolButton(button);
                ui.AddExtensionToPrimaryPanel(panel);
                return true;
            }
            else return false;
        }

        public void Stop()
        {
            follow_action.Dispose();
        }
    }
}
