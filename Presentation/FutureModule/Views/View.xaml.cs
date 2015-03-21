using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureModule.Views
{
    partial class View
    {
        private void MainGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            var context = this.DataContext as FutureModule.ViewModels.FutureViewModel;
            var args = new WPF.RealTime.Infrastructure.AttachedCommand.EventToCommandArgs(sender, context.CreateColumnsCommand, null, e);
            context.CreateColumnsCommand.Execute(args);
        }
    }
}
