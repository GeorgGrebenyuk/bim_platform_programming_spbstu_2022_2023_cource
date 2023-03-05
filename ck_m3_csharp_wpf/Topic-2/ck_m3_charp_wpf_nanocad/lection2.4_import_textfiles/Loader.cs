using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HostMgd.Runtime;
using Teigha.Runtime;
using System.Windows.Forms;

namespace lection2._4_import_textfiles
{
    public class Loader
    {
        [CommandMethod("run_text_files_import")]
        public void start_importer()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = false;
            of.Title = "Выбор текстовых файлов для импорта";
            of.Filter = "Текстовые файла (.txt, .csv, .xyz, ...)|*.*";

            DialogResult dr = of.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var form = new ImporterDialog1(of.FileName);
                HostMgd.ApplicationServices.Application.ShowModelessDialog(form);
            }

		}
    }
}
