using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using iOSCharts;
using UIKit;

namespace iOSChartTest
{
	public class MyCustomFormatter : NSObject, IInterfaceChartAxisValueFormatter
	{
		public string Axis(double value, ChartAxisBase axis)
		{
			return value + " ft     ";
		}
	}
	
    public partial class ViewController : UIViewController, IChartViewDelegate
	{
		//LineChartView _chart;
        LineChartView _chart;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Perform any additional setup after loading the view, typically from a nib.

            _chart = new LineChartView();
            _chart.Frame = new CGRect(0, 10, 350, 200);
            _chart.ChartDescription.Enabled = false;
            _chart.DragEnabled = true;
            _chart.PinchZoomEnabled = false;
            _chart.SetScaleEnabled(false);
            _chart.DrawGridBackgroundEnabled = false;
            _chart.Legend.Enabled = false;
            _chart.RightAxis.Enabled = false;
            _chart.HighlightPerDragEnabled = false;

            ChartYAxis yAxis = _chart.LeftAxis;
            var leftAxisLimitLine = new ChartLimitLine(0);
            leftAxisLimitLine.LineColor = UIColor.FromRGB(147, 164, 172);
            leftAxisLimitLine.LineWidth = 2;
            yAxis.AddLimitLine(leftAxisLimitLine);

            yAxis.LabelPosition = YAxisLabelPosition.OutsideChart;
            yAxis.DrawGridLinesEnabled = true;
            yAxis.AxisLineWidth = 0;
            yAxis.GranularityEnabled = true;

            ChartXAxis xAxis = _chart.XAxis;
            xAxis.LabelPosition = XAxisLabelPosition.Bottom;
            xAxis.DrawGridLinesEnabled = false;
            xAxis.LabelTextColor = UIColor.White;
            xAxis.GranularityEnabled = true;
            Add(_chart);

            var label = new UILabel() { Frame = new CGRect(_chart.Bounds.Left + 30, _chart.Bounds.Bottom - 100, 40, 140) };
            label.Text = "PREC\nHUM\nPRES";
            label.Lines = 3;
            label.Font = UIFont.FromName("WeatherIcons-Regular", 10);
            label.TextColor = UIColor.White;

            SetData();

            _chart.SetVisibleXRangeMaximum(8);

			View.Add(_chart);
		}

		void SetData()
		{
			List<ChartDataEntry> entries = new List<ChartDataEntry>();
			List<ChartDataEntry> secondEntries = new List<ChartDataEntry>();
			List<ChartDataEntry> thirdEntries = new List<ChartDataEntry>();
            List<ChartDataEntry> fourthEntries = new List<ChartDataEntry>();

			entries.Add(new ChartDataEntry(0, 0.613));
			entries.Add(new ChartDataEntry(1, 0.365));
			entries.Add(new ChartDataEntry(2, 0.334));
			entries.Add(new ChartDataEntry(3, 0.538));
			secondEntries.Add(new ChartDataEntry(3, 0.538));
            secondEntries.Add(new ChartDataEntry(4, 0.932));
			secondEntries.Add(new ChartDataEntry(5, 1.421));
			secondEntries.Add(new ChartDataEntry(6, 1.891));
			secondEntries.Add(new ChartDataEntry(7, 2.241));
			thirdEntries.Add(new ChartDataEntry(7, 2.241));
			thirdEntries.Add(new ChartDataEntry(8, 2.397));
            thirdEntries.Add(new ChartDataEntry(9, 2.327));
            thirdEntries.Add(new ChartDataEntry(10, 2.047));
            thirdEntries.Add(new ChartDataEntry(11, 1.618));
            thirdEntries.Add(new ChartDataEntry(12, 1.146));
            thirdEntries.Add(new ChartDataEntry(13, 0.753));
            thirdEntries.Add(new ChartDataEntry(14, 0.542));
            thirdEntries.Add(new ChartDataEntry(15, 0.562));
            thirdEntries.Add(new ChartDataEntry(16, 0.797));
            thirdEntries.Add(new ChartDataEntry(17, 1.169));
            fourthEntries.Add(new ChartDataEntry(18, 1.574));

			LineChartDataSet set1 = null;
			set1 = new LineChartDataSet(entries.ToArray(), " ");
			set1.LineWidth = 3f;
			set1.CircleRadius = 5f;
            set1.Mode = LineChartMode.CubicBezier;
			set1.DrawValuesEnabled = false;
			set1.SetColor(UIColor.White);
			set1.DrawFilledEnabled = true;
			set1.FillColor = UIColor.FromRGB(13, 168, 83);
			set1.FillAlpha = 255;
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
			set2.FillColor = UIColor.FromRGB(165, 43, 38);
			set2.FillAlpha = 255;
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
			set3.FillColor = UIColor.FromRGB(13, 168, 83);
			set3.FillAlpha = 255;
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
            set4.FillColor = UIColor.FromRGB(13, 168, 83);
            set4.FillAlpha = 255;
            set4.CircleHoleColor = UIColor.White;
            set4.SetCircleColor(UIColor.Red);
            set4.DrawHorizontalHighlightIndicatorEnabled = false;

			List<LineChartDataSet> dataSets = new List<LineChartDataSet>();
			dataSets.Add(set1);
			dataSets.Add(set2);
			dataSets.Add(set3);
            dataSets.Add(set4);
			var t = (IInterfaceChartDataSet[])dataSets.ToArray();
			LineChartData data = new LineChartData(t);
			_chart.Data = data;           
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
