using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MpdBaileyTechnology.Shared.WPF.Model;
using System.Drawing;

namespace MpdBaileyTechnology.Shared.WPF.UserControls
{
    /// <summary>
    /// WPF Wrapper for WinForms MSChart
    /// The chart has one set of axes, one chart area and a legend. 
    /// The control supports WPF data binding for the series data and many
    /// properties are exposed as dependency properties for ease of use
    /// </summary>
    public partial class LineChartControl : UserControl, IDisposable
    {
        /// <summary>
        /// Gets the underlying MSChart control
        /// </summary>
        public Chart Chart { get { return _Chart; } }
        /// <summary>
        /// Gets the chart's X Axis
        /// </summary>
        public Axis XAxis { get { return _XAxis; } }
        /// <summary>
        /// Gets the chart's Y Axis
        /// </summary>
        public Axis YAxis { get { return _YAxis; } }
        /// <summary>
        /// Gets the chart's legend
        /// </summary>
        public Legend Legend { get { return _Legend; } }
        /// <summary>
        /// Get / sets the charts X Axis title font
        /// </summary>
        public Font XAxisTitleFont
        {
            get { return _XAxis.TitleFont; }
            set { _XAxis.TitleFont = value; }
        }
        /// <summary>
        /// Get / sets the charts Y Axis title font
        /// </summary>
        public Font YAxisTitleFont
        {
            get { return _YAxis.TitleFont; }
            set { _YAxis.TitleFont = value; }
        }
        /// <summary>
        /// Tool tip formatter for each data point
        /// Example: #SERIESNAME: #VALY{F2}°C, #VALX{F1} seconds
        /// Apply this setting before adding any series / points
        /// </summary>
        public string PointToolTip { get; set; }
        /// <summary>
        /// Gets / sets the chart type, eg Line
        /// Apply this setting before adding any series / points
        /// </summary>
        public SeriesChartType ChartType { get; set; }
        /// <summary>
        /// Gets / sets the marker style for each point
        /// The markers style will change when a new series is added
        /// Apply this setting before adding any series / points
        /// </summary>
        public MarkerStyle MarkerStyle { get;set;}
        /// <summary>
        /// Gets / sets the marker style for each point
        /// Apply this setting before adding any series / points
        /// </summary>
        public int MarkerSize { get; set; }

        /// <summary>
        /// Creates an instance of the LineChartControl
        /// </summary>
        public LineChartControl()
        {
            InitializeComponent();
            this.ChartType = SeriesChartType.Line;
            this.PointToolTip = string.Empty;
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            this.MarkerSize = 4;
        }

        #region Dependency Properties
        public static readonly DependencyProperty XAxisTitleProperty =
            DependencyProperty.Register(
                "XAxisTitle",
                typeof(String),
                typeof(LineChartControl));
        public static readonly DependencyProperty XAxisIntervalProperty =
            DependencyProperty.Register(
                "XAxisInterval",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty XAxisMinimumProperty =
            DependencyProperty.Register(
                "XAxisMinimum",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty XAxisMaximumProperty =
            DependencyProperty.Register(
                "XAxisMaximum",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty XAxisIsStartedFromZeroProperty =
            DependencyProperty.Register(
                "XAxisIsStartedFromZero",
                typeof(bool),
                typeof(LineChartControl));
        public static readonly DependencyProperty YAxisTitleProperty =
            DependencyProperty.Register(
                "YAxisTitle",
                typeof(String),
                typeof(LineChartControl));
        public static readonly DependencyProperty YAxisIntervalProperty =
            DependencyProperty.Register(
                "YAxisInterval",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty YAxisMinimumProperty =
            DependencyProperty.Register(
                "YAxisMinimum",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty YAxisMaximumProperty =
            DependencyProperty.Register(
                "YAxisMaximum",
                typeof(double),
                typeof(LineChartControl));
        public static readonly DependencyProperty YAxisIsStartedFromZeroProperty =
            DependencyProperty.Register(
                "YAxisIsStartedFromZero",
                typeof(bool),
                typeof(LineChartControl));
        public static readonly DependencyProperty SeriesProperty =
            DependencyProperty.Register(
                "Series",
                typeof(ObservableCollection<ChartSeries>),
                typeof(LineChartControl));
        public static readonly DependencyProperty ShowLegendProperty =
            DependencyProperty.Register(
                "ShowLegend",
                typeof(bool),
                typeof(LineChartControl));

        public Axis XAxisTitle
        {
            get { return (Axis)GetValue(XAxisTitleProperty); }
            set { SetValue(XAxisTitleProperty, value); }
        }
        public double XAxisInterval
        {
            get { return (double)GetValue(XAxisIntervalProperty); }
            set { SetValue(XAxisIntervalProperty, value); }
        }
        public double XAxisMinimum
        {
            get { return (double)GetValue(XAxisMinimumProperty); }
            set { SetValue(XAxisMinimumProperty, value); }
        }
        public double XAxisMaximum
        {
            get { return (double)GetValue(XAxisMaximumProperty); }
            set { SetValue(XAxisMaximumProperty, value); }
        }
        public bool XAxisIsStartedFromZero
        {
            get { return (bool)GetValue(XAxisIsStartedFromZeroProperty); }
            set { SetValue(XAxisIsStartedFromZeroProperty, value); }
        }
        public Axis YAxisTitle
        {
            get { return (Axis)GetValue(XAxisTitleProperty); }
            set { SetValue(XAxisTitleProperty, value); }
        }
        public double YAxisInterval
        {
            get { return (double)GetValue(YAxisIntervalProperty); }
            set { SetValue(YAxisIntervalProperty, value); }
        }
        public double YAxisMinimum
        {
            get { return (double)GetValue(YAxisMinimumProperty); }
            set { SetValue(YAxisMinimumProperty, value); }
        }
        public double YAxisMaximum
        {
            get { return (double)GetValue(YAxisMaximumProperty); }
            set { SetValue(YAxisMaximumProperty, value); }
        }
        public bool YAxisIsStartedFromZero
        {
            get { return (bool)GetValue(YAxisIsStartedFromZeroProperty); }
            set { SetValue(YAxisIsStartedFromZeroProperty, value); }
        }
        public ObservableCollection<ChartSeries> Series
        {
            get { return (ObservableCollection<ChartSeries>)GetValue(SeriesProperty); }
            set { SetValue(SeriesProperty, value); }
        }
        public bool ShowLegend
        {
            get { return (bool)GetValue(ShowLegendProperty); }
            set { SetValue(ShowLegendProperty, value); }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == XAxisTitleProperty) { _XAxis.Title = e.NewValue as String; }
            else if (e.Property == XAxisIntervalProperty) { _XAxis.Interval = (double)e.NewValue; }
            else if (e.Property == XAxisMinimumProperty) { _XAxis.Minimum = (double)e.NewValue; }
            else if (e.Property == XAxisMaximumProperty) { _XAxis.Maximum = (double)e.NewValue; }
            else if (e.Property == XAxisIsStartedFromZeroProperty) { _XAxis.IsStartedFromZero = (bool)e.NewValue; }
            else if (e.Property == YAxisTitleProperty) { _YAxis.Title = e.NewValue as String; }
            else if (e.Property == YAxisIntervalProperty) { _YAxis.Interval = (double)e.NewValue; }
            else if (e.Property == YAxisMinimumProperty) { _YAxis.Minimum = (double)e.NewValue; }
            else if (e.Property == YAxisMaximumProperty) { _YAxis.Maximum = (double)e.NewValue; }
            else if (e.Property == YAxisIsStartedFromZeroProperty) { _YAxis.IsStartedFromZero = (bool)e.NewValue; }
            else if (e.Property == ShowLegendProperty) { _Legend.Enabled = (bool)e.NewValue; }
            else if (e.Property == SeriesProperty)
            {
                if (e.OldValue != null)
                {
                    ((ObservableCollection<ChartSeries>)e.OldValue).CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(LineChartControl_CollectionChanged);
                    RemoveAll((ObservableCollection<ChartSeries>)e.OldValue);
                }
                if (e.NewValue != null)
                {
                    this.Series.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(LineChartControl_CollectionChanged);
                    AddAll();
                }
            }
        }
        #endregion

        #region Series Collection changed code
        /// <summary>
        /// Series collection changed event handler
        /// </summary>
        /// <param name="sender">ChartSeries collection, Series</param>
        /// <param name="e">change details</param>
        void LineChartControl_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var cs in e.NewItems)
                    {
                        AddChartSeries((ChartSeries)cs);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var cs in e.OldItems)
                    {
                        RemoveChartSeries((ChartSeries)cs);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    if (this.Series.Count == 0)
                    {
                        this.Chart.Series.Clear();
                    }
                    break;
                default:
                    Debug.Fail("Unexpected Action", e.Action.ToString());
                    break;
            }
        }

        private void AddAll()
        {
            foreach (var cs in this.Series)
            {
                AddChartSeries(cs);
            }
        }
        private void RemoveAll(ObservableCollection<ChartSeries> seriesCollection)
        {
            if (seriesCollection == null) { return; }
            foreach (var cs in seriesCollection)
            {
                RemoveChartSeries(cs);
            }
        }

        private void AddChartSeries(ChartSeries chartSeries)
        {
            AddSeries(chartSeries.Name);
            AddPoints(chartSeries);
            chartSeries.Points.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Points_CollectionChanged);
        }
        private void RemoveChartSeries(ChartSeries chartSeries)
        {
            chartSeries.Points.CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Points_CollectionChanged);
            Series series = this.Chart.Series[chartSeries.Name];
            this.Chart.Series.Remove(series);
            series.Dispose();
        }

        private void AddSeries(string seriesName)
        {
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.ChartType = this.ChartType;
            series.Name = seriesName;
            series.MarkerSize = this.MarkerSize;
            series.MarkerStyle = this.MarkerStyle;
            this.MarkerStyle++;
            if (this.MarkerStyle > System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle)
            {
                this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            }
            series.ToolTip = this.PointToolTip;
            this.Chart.Series.Add(series);
        }
        #endregion

        #region ChartSeries Points collection changed code
        void Points_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ChartSeries chartSeries = this.Series.First((cs) => cs.Points.Equals(sender)); ;
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    AddPoints(chartSeries, e);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RemovePoints(chartSeries, e);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    ResetPoints(chartSeries, e);
                    break;
                default:
                    Debug.Fail("Unexpected Action", e.Action.ToString());
                    break;
            }
        }

        private void AddPoints(ChartSeries chartSeries)
        {
            foreach (var p in chartSeries.Points)
            {
                this.Chart.Series[chartSeries.Name].Points.AddXY(p.Key, p.Value);
            }
        }
        private void AddPoints(ChartSeries chartSeries, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var p in e.NewItems)
            {
                KeyValuePair<double, double> value = (KeyValuePair<double, double>)p;
                this.Chart.Series[chartSeries.Name].Points.AddXY(value.Key, value.Value);
            }
        }
        private void RemovePoints(ChartSeries chartSeries, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int startIndex = e.OldStartingIndex;
            int endIndex = startIndex + e.OldItems.Count - 1;
            for (; endIndex >= startIndex; endIndex--)
            {
                this.Chart.Series[chartSeries.Name].Points.RemoveAt(endIndex);
            }

        }

        private void ResetPoints(ChartSeries chartSeries, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Chart.Series[chartSeries.Name].Points.Clear();
            AddPoints(chartSeries);
        }
        #endregion

        #region Clean up

        private bool disposed = false;
        ~LineChartControl()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                this.disposed = true;
                if (disposing)
                {
                    //dispose all managed resources
                    RemoveAll(this.Series);
                    _Chart.Dispose();
                    _Host.Dispose();
                }
                //Clean up unmanaged resources

                //Disposal has been done
                disposed = true;
            }
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        #endregion
    }
}
