﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	public interface IGetDatafeedStatsResponse : IResponse
	{
		[JsonProperty("count")]
		long Count { get; }

		[JsonProperty("datafeeds")]
		IReadOnlyCollection<DatafeedStats> Datafeeds { get; }
	}

	public class GetDatafeedStatsResponse : ResponseBase, IGetDatafeedStatsResponse
	{
		public long Count { get; internal set; }

		public IReadOnlyCollection<DatafeedStats> Datafeeds { get; internal set; } = EmptyReadOnly<DatafeedStats>.Collection;
	}

	[JsonObject]
	public class DiscoveryNode
	{
		/// <summary>
		/// The unique identifier of the node.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; internal set; }

		/// <summary>
		/// The node name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; internal set; }

		/// <summary>
		/// The ephemeral id of the node.
		/// </summary>
		[JsonProperty("ephemeral_id")]
		public string EphemeralId { get; internal set; }

		/// <summary>
		/// The host and port where transport HTTP connections are accepted.
		/// </summary>
		[JsonProperty("transport_address")]
		public string TransportAddress { get; internal set; }

		/// <summary>
		/// The node attributes
		/// </summary>
		[JsonProperty("attributes")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, string>))]
		public Dictionary<string, string> Attributes { get; internal set; }
	}
}