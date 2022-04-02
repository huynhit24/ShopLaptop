using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShopLaptop.Common
{
    [DataContract]
    public class DataPoint
    {
		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		[DataMember(Name = "label")]
		public string Label = "";

		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
		public DataPoint(double x, double y1)
		{
			this.x = x;
			this.Y1 = y1;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "x")]
		public Nullable<double> x = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y1")]
		public Nullable<double> Y1 = null;
	}
}