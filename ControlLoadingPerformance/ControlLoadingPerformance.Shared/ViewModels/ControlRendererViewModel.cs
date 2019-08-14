using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using ControlLoadingPerformance.Shared.Models;

namespace ControlLoadingPerformance.Shared.ViewModels
{
    public class ControlRendererViewModel : ViewModelBase
    {
        public ControlRendererViewModel(int contolsAmount)
        {
            Load(contolsAmount);
        }

        public void ReportButtonClick(Button button)
        {
            Console.WriteLine("This is loading something");
        }

        void Load(int maxKey)
        {
            var reportsToAdd = new List<ReportEntity>();
            for (int key = 1; key <= maxKey; key++)
            {
                reportsToAdd.Add(new ReportEntity
                {
                    Code = "Report" + key,
                    Key = key,
                    Name = "Report" + key,
                    ReportPath = "ReportPath" + key,
                    RoleCode = "RoleCode" + key,
                    ShowInReportMenu = true
                });
            }
            Reports = reportsToAdd;
        }

        private IEnumerable<ReportEntity> reports;
        public IEnumerable<ReportEntity> Reports
        {
            get => reports;
            set
            {
                reports = value;
                RaiseChanged();
            }
        }
    }
}
