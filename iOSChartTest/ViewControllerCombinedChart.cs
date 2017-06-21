using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using iOSCharts;
using UIKit;

namespace iOSChartTest
{
    public partial class ViewControllerCombinedChart : UIViewController, IChartViewDelegate
    {
        //LineChartView _mChart;
        CombinedChartView _chart;

        protected ViewControllerCombinedChart(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            var axisTextSize = 14;
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            _chart = new CombinedChartView();
            _chart.Frame = new CGRect(0, 10, 300, 200);
            _chart.ChartDescription.Enabled = false;
            _chart.DragEnabled = true;
            _chart.PinchZoomEnabled = false;
            _chart.SetScaleEnabled(false);
            _chart.DrawGridBackgroundEnabled = false;
            _chart.Legend.Enabled = false;
            _chart.RightAxis.Enabled = false;
            //_chart.Delegate = _delegate;
            _chart.HighlightPerDragEnabled = false;
            _chart.DrawOrder = new NSNumber[] { 0, 2 };

            ChartYAxis yAxis = _chart.LeftAxis;
            var leftAxisLimitLine = new ChartLimitLine(0);
            leftAxisLimitLine.LineColor = UIColor.FromRGB(147, 164, 172);
            leftAxisLimitLine.LineWidth = 2;
            yAxis.AddLimitLine(leftAxisLimitLine);

            //_yAxisValueFormater = new ForecastChartAxisUnitValueFormatter();
            //yAxis.LabelTextColor = Styles.Colors.DarkAqua;
            yAxis.LabelPosition = YAxisLabelPosition.OutsideChart;
            yAxis.DrawGridLinesEnabled = true;
            yAxis.AxisLineWidth = 0;
            yAxis.Granularity = 1;
            yAxis.GranularityEnabled = true;
            yAxis.LabelFont = UIFont.SystemFontOfSize(12);
            //yAxis.ValueFormatter = _yAxisValueFormater;

            //_xAxisValueFormater = new ForecastWeatherChartXAxisValueFormatter();
            ChartXAxis xAxis = _chart.XAxis;
            //xAxis.LabelTextColor = Styles.Colors.DarkAqua;
            xAxis.LabelPosition = XAxisLabelPosition.Bottom;
            xAxis.DrawGridLinesEnabled = false;
            xAxis.AxisLineWidth = 0;
            xAxis.LabelFont = UIFont.FromName("WeatherIcons-Regular", 10);
            xAxis.Granularity = 1.0f;
            xAxis.GranularityEnabled = true;
            //xAxis.ValueFormatter = _xAxisValueFormater;
            Add(_chart);

            var label = new UILabel() { Frame = new CGRect(_chart.Bounds.Left + 30, _chart.Bounds.Bottom - 100, 40, 140) };
            label.Text = "PREC\nHUM\nPRES";
            label.Lines = 3;
            label.Font = UIFont.FromName("WeatherIcons-Regular", 10);
            label.TextColor = UIColor.White;
            View.Add(label);

            SetData();
            _chart.MoveViewToX(10.0);

            //_mChart = new BarChartView();

            //_mChart.MaxVisibleCount = 60;
            //_mChart.PinchZoomEnabled = false;
            //var description = _mChart.Description;
            //description = null;
            //_mChart.DrawGridBackgroundEnabled = false;
            //_mChart.SetExtraOffsetsWithLeft(5, 5, 5, 5);

            //ChartLegend legend = _mChart.Legend;
            //legend.Enabled = false;

            //ChartYAxis rightAxis = _mChart.RightAxis;
            //rightAxis.Enabled = false;

            //ChartYAxis leftAxis = _mChart.LeftAxis;
            //leftAxis.LabelTextColor = UIColor.White;
            //leftAxis.LabelFont = UIFont.SystemFontOfSize(axisTextSize);
            //leftAxis.LabelPosition = YAxisLabelPosition.OutsideChart;
            //leftAxis.DrawGridLinesEnabled = false;
            //leftAxis.SpaceMin = 20;
            //leftAxis.ValueFormatter = new MyCustomFormatter();
            //leftAxis.DrawGridLinesEnabled = true;
            //leftAxis.GridLineWidth = 1;
            //leftAxis.GridColor = UIColor.FromRGB(147, 164, 173);

            //ChartXAxis bottomAxis = _mChart.XAxis;
            //bottomAxis.LabelTextColor = UIColor.White;
            //bottomAxis.LabelFont = UIFont.SystemFontOfSize(axisTextSize);
            //bottomAxis.LabelPosition = XAxisLabelPosition.Bottom;
            //bottomAxis.DrawGridLinesEnabled = false;

            //_mChart.Data = GenerateBarData();

            //_mChart.Frame = new CoreGraphics.CGRect(15, 80, 300, 300);
            //View.Add(_mChart);

        }

        BarChartData GenerateBarData()
        {
            List<BarChartDataEntry> greenEntries = new List<BarChartDataEntry>();
            List<BarChartDataEntry> blueEntries = new List<BarChartDataEntry>();
            List<BarChartDataEntry> yellowEntries = new List<BarChartDataEntry>();
            List<BarChartDataEntry> orangeEntries = new List<BarChartDataEntry>();
            List<BarChartDataEntry> redEntries = new List<BarChartDataEntry>();

            //Green
            greenEntries.Add(new BarChartDataEntry(0, 8f));
            greenEntries.Add(new BarChartDataEntry(1, 3));
            greenEntries.Add(new BarChartDataEntry(2, 1));
            greenEntries.Add(new BarChartDataEntry(3, -1));

            BarChartDataSet set1 = new BarChartDataSet(greenEntries.ToArray(), string.Empty);
            set1.DrawValuesEnabled = false;
            set1.SetColor(UIColor.Green);
            set1.ValueTextColor = UIColor.White;
            set1.ValueFont = UIFont.SystemFontOfSize(15);
            //Blue
            blueEntries.Add(new BarChartDataEntry(3, -1f));
            blueEntries.Add(new BarChartDataEntry(4, -7f));
            blueEntries.Add(new BarChartDataEntry(5, -2f));
            blueEntries.Add(new BarChartDataEntry(6, -3f));
            blueEntries.Add(new BarChartDataEntry(7, -4f));

            BarChartDataSet set2 = new BarChartDataSet(blueEntries.ToArray(), string.Empty);
            set2.DrawValuesEnabled = false;
            set2.SetColor(UIColor.Red);
            set2.ValueTextColor = UIColor.White;
            set2.ValueFont = UIFont.SystemFontOfSize(15);
            //Yellow

            List<IInterfaceChartDataSet> dataSets = new List<IInterfaceChartDataSet>();
            dataSets.Add(set1);
            dataSets.Add(set2);
            BarChartData barData = new BarChartData(dataSets.ToArray());
            barData.BarWidth = 0.7f;

            return barData;
        }

        void SetData()
        {
            List<ChartDataEntry> entries = new List<ChartDataEntry>();
            List<ChartDataEntry> secondEntries = new List<ChartDataEntry>();
            List<ChartDataEntry> thirdEntries = new List<ChartDataEntry>();
            List<ChartDataEntry> fourthEntries = new List<ChartDataEntry>();

            entries.Add(new ChartDataEntry(0, 8));
            entries.Add(new ChartDataEntry(1, 3));
            entries.Add(new ChartDataEntry(2, 1));
            entries.Add(new ChartDataEntry(3, -1));
            secondEntries.Add(new ChartDataEntry(3, -1));
            secondEntries.Add(new ChartDataEntry(4, -7));
            secondEntries.Add(new ChartDataEntry(5, -2));
            secondEntries.Add(new ChartDataEntry(6, -3));
            secondEntries.Add(new ChartDataEntry(7, -4));
            thirdEntries.Add(new ChartDataEntry(7, 2));
            thirdEntries.Add(new ChartDataEntry(8, 2.6f));
            thirdEntries.Add(new ChartDataEntry(9, 3.6f));
            thirdEntries.Add(new ChartDataEntry(10, 2.8f));
            thirdEntries.Add(new ChartDataEntry(11, 3.8f));

            LineChartDataSet set1 = null;
            set1 = new LineChartDataSet(entries.ToArray(), " ");
            set1.LineWidth = 3f;
            set1.CircleRadius = 5f;
            set1.Mode = LineChartMode.CubicBezier;
            set1.DrawValuesEnabled = false;
            set1.SetColor(UIColor.White);
            set1.DrawFilledEnabled = true;
            set1.CircleHoleColor = UIColor.White;
            set1.SetCircleColor(UIColor.White);
            set1.DrawHorizontalHighlightIndicatorEnabled = false;

            LineChartDataSet set2 = null;
            set2 = new LineChartDataSet(secondEntries.ToArray(), " ");
            set2.LineWidth = 3f;
            set2.CircleRadius = 5f;
            set2.Mode = LineChartMode.CubicBezier;
            set2.DrawValuesEnabled = false;
            set2.SetColor(UIColor.White);
            set2.DrawFilledEnabled = true;
            set2.CircleHoleColor = UIColor.White;
            set2.SetCircleColor(UIColor.White);
            set2.DrawHorizontalHighlightIndicatorEnabled = false;

            LineChartDataSet set3 = null;
            set3 = new LineChartDataSet(thirdEntries.ToArray(), " ");
            set3.LineWidth = 3f;
            set3.CircleRadius = 5f;
            set3.Mode = LineChartMode.CubicBezier;
            set3.DrawValuesEnabled = false;
            set3.SetColor(UIColor.White);
            set3.DrawFilledEnabled = true;
            set3.CircleHoleColor = UIColor.White;
            set3.SetCircleColor(UIColor.White);
            set3.DrawHorizontalHighlightIndicatorEnabled = false;

            LineChartDataSet set4 = null;
            set4 = new LineChartDataSet(fourthEntries.ToArray(), " ");
            set4.LineWidth = 3f;
            set4.Mode = LineChartMode.CubicBezier;
            set4.DrawValuesEnabled = false;
            set4.DrawCirclesEnabled = false;
            set4.SetColor(UIColor.White);
            set4.DrawFilledEnabled = true;
            set4.CircleHoleColor = UIColor.White;
            set4.SetCircleColor(UIColor.Red);
            set4.DrawHorizontalHighlightIndicatorEnabled = false;

            List<LineChartDataSet> dataSets = new List<LineChartDataSet>();
            dataSets.Add(set1);
            dataSets.Add(set2);
            dataSets.Add(set3);
            dataSets.Add(set4);
            var t = (IInterfaceChartDataSet[])dataSets.ToArray();
            var lineChartData = new LineChartData(t);
            var barChartData = GenerateBarData();

            var data = new CombinedChartData();
            data.LineData = lineChartData;
            data.BarData = barChartData;

            _chart.Data = data;

            _chart.SetVisibleXRangeMaximum(7);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
