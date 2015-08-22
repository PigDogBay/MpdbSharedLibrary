using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Collections;

namespace MpdBaileyTechnology.Shared.WPF.Model
{
    public class RollingSeries
    {
        ChartSeries _Source;
        public ChartSeries Rolled {get;private set;}
        public int Max { get; set; }
        public int Step { get; set; }

        public RollingSeries(ChartSeries source, int max, int step)
        {
            _Source = source;
            Max = max;
            Step = step;
            Rolled = new ChartSeries(_Source.Name);
            _Source.Points.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Points_CollectionChanged);
            Roll();
        }

        void Points_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action!=System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Roll();
                return;
            }
            var rolled = Rolled.Points;
            rolled.SuspendCollectionChangeNotification();
            rolled.AddItems(e.NewItems);
            if (rolled.Count>=Max)
            {
                Roll();
            }
            rolled.NotifyChanges();
        }

        void Roll()
        {
            var rolled = Rolled.Points;
            var source = _Source.Points;
            rolled.SuspendCollectionChangeNotification();
            rolled.Clear();
            int skip = source.Count - Max + Step;
            rolled.AddItems(source.Skip(skip).ToList());
            rolled.ResumeCollectionChangeNotification();
        }
    }
}
