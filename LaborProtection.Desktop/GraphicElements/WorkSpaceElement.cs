﻿using LaborProtection.Calculation.Constants;
using LaborProtection.Services.TransponeServices;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class WorkSpaceElement
	{
		public static Rectangle MonitorElement { get; set; }
		public static Rectangle TableElement { get; set; }
		public static Rectangle WorkAreaElement { get; set; }
		private static TransponeService TransponeServiceWeight { get; set; }
		private static TransponeService TransponeServiceHeight { get; set; }
		public WorkSpaceElement(TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, Canvas roomCanvas, Func<double> SetLeft, Func<double> SetTop)
		{
			TransponeServiceWeight = transponeServiceWidth;
			TransponeServiceHeight = transponeServiceHeight;
			CreateTable(roomCanvas, SetLeft, SetTop);
		}
		public void CreateTable(Canvas roomCanvas, Func<double> SetLeft, Func<double> SetTop)
		{
			double r = TransponeServiceHeight.ConditionalUnit * Limitations.MINIMAL_WIDTH;
			Canvas WorkSpaceCanvas = new Canvas()
			{
				Width = TransponeServiceWeight.ConditionalUnit * Limitations.MINIMUM_TABLE_WIDTH / 100,/////////////////////////////////////////
				Height = TransponeServiceHeight.ConditionalUnit * Limitations.MINIMAL_WIDTH,
			};

			Canvas.SetLeft(WorkSpaceCanvas, SetLeft());
			Canvas.SetTop(WorkSpaceCanvas, SetTop());

			MonitorElement = new Rectangle()
			{
				Height = TransponeServiceHeight.ConditionalUnit * 0.1,
				Width = TransponeServiceWeight.ConditionalUnit * 0.2,
				Stroke = Brushes.Black,
				Fill = Brushes.White,

			};
			Canvas.SetLeft(MonitorElement, WorkSpaceCanvas.Width / 2 - MonitorElement.Width);
			TableElement = new Rectangle()
			{
				Height = TransponeServiceHeight.ConditionalUnit * Limitations.MINIMUM_TABLE_LENGTH / 100,/////////////////////////////////////////
				Width = TransponeServiceWeight.ConditionalUnit * Limitations.MINIMUM_TABLE_WIDTH / 100,/////////////////////////////////////////
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};

			WorkAreaElement = new Rectangle()
			{
				Height = Limitations.MINIMAL_WIDTH,
				Width = Limitations.MINIMUM_TABLE_WIDTH,
				Stroke = Brushes.Wheat,
				Fill = Brushes.White
			};

			WorkSpaceCanvas.Children.Add(WorkAreaElement);
			WorkSpaceCanvas.Children.Add(TableElement);
			WorkSpaceCanvas.Children.Add(MonitorElement);
			roomCanvas.Children.Add(WorkSpaceCanvas);
		}
	}
}