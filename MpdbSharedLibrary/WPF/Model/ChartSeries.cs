using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MpdBaileyTechnology.Shared.WPF.Collections;

namespace MpdBaileyTechnology.Shared.WPF.Model
{
    /// <summary>
    /// Holds the data for the points in a chart series
    /// </summary>
    public class ChartSeries
    {
        private ObservableCollectionEx<KeyValuePair<double,double>> _Points = new ObservableCollectionEx<KeyValuePair<double,double>>();

        /// <summary>
        /// Collection of XY Points that implements the INotifyCollectionChanged Interface
        /// A point is stored as a KeyValuePair, X is the Name and Y is the Value
        /// </summary>
        public ObservableCollectionEx<KeyValuePair<double, double>> Points { get { return _Points; } }
        /// <summary>
        /// Gets the series name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Create a chart series with no points
        /// </summary>
        /// <param name="name">Series name</param>
        public ChartSeries(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// Creates a KeyValuePair and adds it to the Points collection
        /// </summary>
        /// <param name="x">X co-ordinate of the point</param>
        /// <param name="y">Y co-ordinate of the point</param>
        public void AddPoint(double x, double y)
        {
            _Points.Add(new KeyValuePair<double, double>(x, y));
        }

    }
}
