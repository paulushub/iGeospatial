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

using iGeospatial.Coordinates;
using iGeospatial.Geometries.Graphs;

namespace iGeospatial.Geometries.Operations.Overlay
{
	/// <summary> 
	/// Creates nodes for use in the <see cref="PlanarGraph"/>s 
	/// constructed during overlay operations.
	/// </summary>
	internal class OverlayNodeFactory : NodeFactory
	{
		public override Node CreateNode(Coordinate coord)
		{
			return new Node(coord, new DirectedEdgeStar());
		}
	}
}