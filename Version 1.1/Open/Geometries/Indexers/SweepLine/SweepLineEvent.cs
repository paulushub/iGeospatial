#region License
// <copyright>
//         iGeospatial Geometries Package
//       
// This is part of the Open Geospatial Library for .NET.
// 
// Package Description:
// This is a collection of C# classes that implement the fundamental 
// operations required to validate a given geo-spatial data set to 
// a known topological specification.
// It aims to provide a complete implementation of the Open Geospatial
// Consortium (www.opengeospatial.org) specifications for Simple 
// Feature Geometry.
// 
// Contact Information:
//     Paul Selormey (paulselormey@gmail.com or paul@toolscenter.org)
//     
// Credits:
// This library is based on the JTS Topology Suite, a Java library by
// 
//     Vivid Solutions Inc. (www.vividsolutions.com)  
//     
// License:
// See the license.txt file in the package directory.   
// </copyright>
#endregion

using System;

namespace iGeospatial.Geometries.Indexers.SweepLine
{
	internal class SweepLineEvent : System.IComparable
	{
        private enum SweepLineEventType
        {
            INSERT = 1,
            DELETE = 2
        }
                                     
		private double             xValue;
		private SweepLineEventType eventType;
		private SweepLineEvent     insertEvent; // null if this is an INSERT event
		private int                deleteEventIndex;
		private SweepLineInterval  sweepInt;

		public SweepLineEvent(double x, SweepLineEvent insertEvent, SweepLineInterval sweepInt)
		{
			this.xValue      = x;
			this.insertEvent = insertEvent;
			this.eventType   = SweepLineEventType.INSERT;
			if (insertEvent != null)
				this.eventType = SweepLineEventType.DELETE;
			this.sweepInt    = sweepInt;
		}
		
		public bool IsInsert
		{
			get
			{
				return insertEvent == null;
			}
		}

		public bool IsDelete
		{
			get
			{
				return insertEvent != null;
			}
		}

		public SweepLineEvent InsertEvent
		{
			get
			{
				return insertEvent;
			}
		}

		public int DeleteEventIndex
		{
			get
			{
				return deleteEventIndex;
			}
			
			set
			{
				this.deleteEventIndex = value;
			}
		}

		internal SweepLineInterval Interval
		{
			get
			{
				return sweepInt;
			}
		}
		
		/// <summary> 
		/// ProjectionEvents are ordered first by their x-value, and then by their eventType.
		/// It is important that Insert events are sorted before Delete events, so that
		/// items whose Insert and Delete events occur at the same x-value will be
		/// correctly handled.
		/// </summary>
		public int CompareTo(SweepLineEvent pe)
		{
            if (xValue < pe.xValue)
				return - 1;
			if (xValue > pe.xValue)
				return 1;
			if (eventType < pe.eventType)
				return - 1;
			if (eventType > pe.eventType)
				return 1;
			return 0;
		}

        public int CompareTo(object o)
        {
            return CompareTo((SweepLineEvent)o);
        }
	}
}