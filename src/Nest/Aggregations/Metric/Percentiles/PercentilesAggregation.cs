using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<PercentilesAggregator>))]
	public interface IPercentilesAggregator : IMetricAggregator
	{
		[JsonProperty("percents")]
		IEnumerable<double> Percentages { get; set; }

		[JsonProperty("compression")]
		int? Compression { get; set; }
	}

	public class PercentilesAggregator : MetricAggregator, IPercentilesAggregator
	{
		public IEnumerable<double> Percentages { get; set; }
		public int? Compression { get; set; }
	}

	public class PercentilesAgg : MetricAgg, IPercentilesAggregator
	{
		public IEnumerable<double> Percentages { get; set; }
		public int? Compression { get; set; }

		public PercentilesAgg(string name, FieldName field) : base(name, field) { } 

		internal override void WrapInContainer(AggregationContainer c) => c.Percentiles = this;
	}

	public class PercentilesAggregatorDescriptor<T> 
		: MetricAggregationBaseDescriptor<PercentilesAggregatorDescriptor<T>, IPercentilesAggregator, T>
			, IPercentilesAggregator 
		where T : class
	{
		IEnumerable<double> IPercentilesAggregator.Percentages { get; set; }

		int? IPercentilesAggregator.Compression { get; set; }

		public PercentilesAggregatorDescriptor<T> Percentages(params double[] percentages) => Assign(a => a.Percentages = percentages);

		public PercentilesAggregatorDescriptor<T> Compression(int compression) => Assign(a => a.Compression = compression);

	}
}